using System.ComponentModel.DataAnnotations;
using Common.Application;
using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketModule.Core.DTOs.Tickets;
using TicketModule.Core.Services;
using UserModule.Core.Services;

namespace DigiLearn.Web.Areas.Admin.Pages.Tickets
{
    public class ShowModel : BaseRazor
    {
        private readonly ITicketService _ticketService;
        public readonly IUserFacade _userFacade;
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
        public async Task<IActionResult> OnGet(Guid id)
        {
            var ticket = await _ticketService.GetTicket(id);
            if (ticket == null )
                return RedirectToPage("Index");


            Ticket = ticket;
            return Page();
        }

        public async Task<IActionResult> OnPost(Guid id)
        {
            var user = await _userFacade.GetUserByPhoneNumber(User.GetPhoneNumber());
            var message = new SendTicketMessageCommand()
            {
                OwnerFullName = $"{user.Name} {user.Family}",
                Text = Text,
                TicketId = id,
                UserId = User.GetUserId()
            };
            var result = await _ticketService.SendMessageInTicket(message);
            return RedirectAndShowAlert(result, RedirectToPage("Show", new { id }));
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
