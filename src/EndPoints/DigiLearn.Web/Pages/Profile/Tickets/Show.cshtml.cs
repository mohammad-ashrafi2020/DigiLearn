using System.ComponentModel.DataAnnotations;
using Common.Application;
using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketModule.Core.DTOs.Tickets;
using TicketModule.Core.Services;
using UserModule.Core.Services;

namespace DigiLearn.Web.Pages.Profile.Tickets
{
    public class ShowModel : BaseRazor
    {
        private ITicketService _ticketService;
        private IUserFacade _userFacade;
        public ShowModel(ITicketService ticketService, IUserFacade userFacade)
        {
            _ticketService = ticketService;
            _userFacade = userFacade;
        }

        public TicketDto Ticket { get; set; }


        [BindProperty]
        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Text { get; set; }
        public async Task<IActionResult> OnGet(Guid ticketId)
        {
            var ticket = await _ticketService.GetTicket(ticketId);
            if (ticket == null || ticket.UserId != User.GetUserId())
                return RedirectToPage("Index");


            Ticket = ticket;
            return Page();
        }

        public async Task<IActionResult> OnPost(Guid ticketId)
        {
            var user = await _userFacade.GetUserByPhoneNumber(User.GetPhoneNumber());
            var message = new SendTicketMessageCommand()
            {
                OwnerFullName = $"{user.Name} {user.Family}",
                Text = Text,
                TicketId = ticketId,
                UserId = User.GetUserId()
            };
            var result = await _ticketService.SendMessageInTicket(message);
            return RedirectAndShowAlert(result, RedirectToPage("Show", new { ticketId }));
        }


        public async Task<IActionResult> OnPostCloseTicket(Guid ticketId)
        {
            return await AjaxTryCatch(async () =>
            {
                var ticket = await _ticketService.GetTicket(ticketId);
                if (ticket == null || ticket.UserId != User.GetUserId())
                    return OperationResult.Error("تیکت یافت نشد");

                return await _ticketService.CloseTicket(ticketId);
            });
        }
    }
}
