using CoreModule.Facade.Course;
using CoreModule.Facade.Orders;
using DigiLearn.Web.Infrastructure;
using Dto.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TransactionModule.Domain;
using TransactionModule.Services;
using TransactionModule.Services.DTOs.Commands;
using TransactionModule.Services.ZarinPal;
using ZarinPal.Class;

namespace DigiLearn.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IOrderFacade _orderFacade;
        private readonly IZarinPalService _zarinPalService;
        private readonly IUserTransactionService _transactionService;
        private readonly ICourseFacade _courseFacade;
        private readonly ILogger<TransactionController> _logger;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        public TransactionController(IZarinPalService zarinPalService, IUserTransactionService transactionService, ILogger<TransactionController> logger, ICourseFacade courseFacade, IOrderFacade orderFacade)
        {
            _zarinPalService = zarinPalService;
            _transactionService = transactionService;
            _logger = logger;
            _courseFacade = courseFacade;
            _orderFacade = orderFacade;

            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }

        [Authorize]
        public async Task<IActionResult> CreateTransaction(CreateTransactionCommand command)
        {
            var order = await _orderFacade.GetCurrentOrder(User.GetUserId());
            if (order == null)
                throw new InvalidDataException("Order Is Null");

            command.PaymentAmount = order.TotalPrice;
            command.UserId = User.GetUserId();
            command.PaymentGateway = PaymentGateway.ZarinPal;
            var transactionId = await _transactionService.CreateTransaction(command);


            var payment = await _zarinPalService.CreatePaymentRequest(
                command.PaymentAmount, $"پرداخت تراکنش شماره {transactionId}",
                $"https://localhost:7197/Transaction/Zarinpal-Verify/{transactionId}");

            if (payment?.Status == 100)
            {
                return Redirect(payment.GateWayUrl);
            }
            return Redirect("/");
        }



        [Route("/Transaction/Zarinpal-Verify/{id}")]
        [Authorize]
        public async Task<IActionResult> ZarinPalVerify(string authority, string status, Guid id)
        {
            if (string.IsNullOrWhiteSpace(status) || status.ToLower() == "nok" || string.IsNullOrWhiteSpace(authority))
            {
                await PayError(new TransactionPaymentErrorCommand()
                {
                    Authority = authority,
                    RefId = 0,
                    ErrorMessage = "Payment Canceled Or Canceled With Error - Status = NOK",
                    TransactionId = id,
                    Canceled = true
                });
                return View("EndTransaction");
            }

            var transaction = await _transactionService.GetTransactionById(id);

            if (transaction == null)
                return NotFound();

            if (User.GetUserId() != transaction.UserId)
                return BadRequest();

            if (transaction.Status == TransactionStatus.PaymentSuccess)
                return BadRequest();

            try
            {
                var result = await _zarinPalService.CreateVerificationRequest(authority, transaction.PaymentAmount);
                if (result.Status == 100)
                {
                    TempData["Success"] = true;
                    await _transactionService.PaymentSuccess(new TransactionPaymentSuccessCommand()
                    {
                        Authority = authority,
                        CardPen = result.CardPan,
                        RefId = result.RefId,
                        TransactionId = id
                    });
                    await FinallyTransaction(transaction);
                }
                else
                {
                    await PayError(new TransactionPaymentErrorCommand
                    {
                        RefId = result.RefId,
                        TransactionId = id,
                        ErrorMessage = result.Message,
                        Authority = authority
                    });
                }
            }
            catch (Exception e)
            {
                await PayError(e, id, authority);
            }
            return View("EndTransaction");
        }

        #region Utilities

        private async Task FinallyTransaction(UserTransaction transaction)
        {
            switch (transaction.TransactionFor)
            {

                case TransactionFor.CourseOrder:
                    {
                        var order = await _orderFacade.GetCurrentOrder(transaction.UserId);
                        if (order.TotalPrice != transaction.PaymentAmount)
                            throw new InvalidDataException("اطلاعات پرداخت با اطلاعات سفارش همخوانی ندارند");

                        //await _courseOrder.FinallyOrder(order);
                        //await AddCourseStudent(order);
                        //await _callCenterProfitService.ProfitCalculation(order);
                        break;
                    }

            }
        }

        private async Task PayError(Exception e, Guid id, string authority)
        {
            TempData["Error"] = true;
            await _transactionService.PaymentError(new TransactionPaymentErrorCommand
            {
                RefId = 0,
                TransactionId = id,
                ErrorMessage = e.Message,
                Authority = authority
            });
            _logger.LogError(e.Message, e);
        }
        private async Task PayError(TransactionPaymentErrorCommand command)
        {
            TempData["Error"] = true;
            await _transactionService.PaymentError(command);
        }

        //private async Task AddCourseStudent(CourseOrder order)
        //{
        //    foreach (var detail in order.CourseOrderDetails)
        //    {
        //        await _courseFacade.AddCourseStudent(
        //            new AddStudentCommand(order.UserId, detail.CourseId, true));
        //    }
        //}
        #endregion
    }
}
