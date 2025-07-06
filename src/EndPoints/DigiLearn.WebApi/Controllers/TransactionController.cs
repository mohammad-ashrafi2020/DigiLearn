using DigiLearn.WebApi.Infrastructure;
using DigiLearn.WebApi.Models.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionModule.Domain;
using TransactionModule.Services;
using TransactionModule.Services.DTOs.Commands;
using TransactionModule.Services.DTOs.Queries;

namespace DigiLearn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ApiController
    {
        private readonly IUserTransactionService _service;

        public TransactionController(IUserTransactionService service)
        {
            _service = service;
        }
        #region Commands
        [HttpPost("CreateTransaction")]
        public async Task<ApiResult<Guid>> CreateTransaction(CreateTransactionViewModel command)
        {
            try
            {
                Guid transactionId = await _service.CreateTransaction(new CreateTransactionCommand
                {
                    LinkId = command.LinkId,
                    PaymentAmount = command.PaymentAmount,
                    PaymentGateway = command.PaymentGateway,
                    TransactionFor = command.TransactionFor,
                    UserId = User.GetUserId(),
                });
                return CommandResult<Guid>(new Common.Application.OperationResult<Guid>
                {
                    Message = "عملیات با موفقیت انجام شد.",
                    Status = Common.Application.OperationResultStatus.Success,
                    Title = "عملیات موفق",
                    Data = transactionId
                });

            }
            catch (Exception ex)
            {
                return CommandResult<Guid>(new Common.Application.OperationResult<Guid>
                {
                    Message = "خطایی در عملیات رخ داده است!",
                    Status = Common.Application.OperationResultStatus.Error,
                    Title = "عملیات ناموفق"
                });
            }
        }
        [HttpPost("PaymentSuccess")]
        public async Task<ApiResult> PaymentSuccess(TransactionPaymentSuccessCommand command)
        {
            try
            {
                await _service.PaymentSuccess(command);
                return CommandResult(new Common.Application.OperationResult
                {
                    Message = "عملیات با موفقیت انجام شد.",
                    Status = Common.Application.OperationResultStatus.Success,
                    Title = "عملیات موفق"
                });

            }
            catch (Exception ex)
            {
                return CommandResult(new Common.Application.OperationResult
                {
                    Message = "خطایی در عملیات رخ داده است!",
                    Status = Common.Application.OperationResultStatus.Error,
                    Title = "عملیات ناموفق"
                });
            }
        }
        [HttpPost("PaymentError")]
        public async Task<ApiResult> PaymentError(TransactionPaymentErrorCommand command)
        {
            try
            {
                await _service.PaymentError(command);
                return CommandResult(new Common.Application.OperationResult
                {
                    Message = "عملیات با موفقیت انجام شد.",
                    Status = Common.Application.OperationResultStatus.Success,
                    Title = "عملیات موفق"
                });

            }
            catch (Exception ex)
            {
                return CommandResult(new Common.Application.OperationResult
                {
                    Message = "خطایی در عملیات رخ داده است!",
                    Status = Common.Application.OperationResultStatus.Error,
                    Title = "عملیات ناموفق"
                });
            }
        }
        #endregion

        #region Queries


        /// <example>
        /// نمونه ریکوئست  => api/Transaction/GetTransactionById?{transactionId}
        /// </example>
        [HttpGet("GetUserTransaction")]
        public async Task<ApiResult<UserTransaction>> GetTransactionById(Guid transactionId)
        {
            return QueryResult(await _service.GetTransactionById(transactionId));
        }

        [HttpGet("GetTransactionsByFilter")]
        [AllowAnonymous]
        public async Task<ApiResult<UserTransactionFilterDto>> GetTransactionsByFilter
            ([FromQuery] UserTransactionFilterParamsViewModel queryParams)
        {
            return QueryResult(await _service.GetTransactionsByFilter(
                new UserTransactionFilterParams
                {
                    EndDate = queryParams.EndDate,
                    StartDate = queryParams.StartDate,
                    PageId = queryParams.PageId,
                    Status = queryParams.Status,
                    Take = queryParams.Take,
                    TransactionFor = queryParams.TransactionFor,
                    UserId = (User.Identity != null && User.Identity.IsAuthenticated) ? 
                    User.GetUserId() : null,
                    //این میگه که identity مقدارش null نیست
                    //و اگه یه وقتی identity null باشه خطا
                    //NullReferenceException میده 
                    //UserId = User.Identity!.IsAuthenticated ? User.GetUserId() : null,
                }));
        }

        [HttpGet("GetCancelTransactionsCount")]
        public async Task<ApiResult<int>> GetCancelTransactionsCount
            ([FromQuery] string startDate, string endDate,
            TransactionFor transactionFor, TransactionStatus status)
        {
            return QueryResult(await _service.GetCancelTransactionsCount(startDate,
                endDate, transactionFor, status));
        }

        #endregion
    }
}
