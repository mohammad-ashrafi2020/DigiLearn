using DigiLearn.WebApi.Infrastructure;
using DigiLearn.WebApi.Models.Ticket;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketModule.Core.DTOs.Tickets;
using TicketModule.Core.Services;

namespace DigiLearn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ApiController
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        [HttpPost("CreateTicket")]
        public async Task<ApiResult<Guid>> CreateTicket(CreateTicketViewModel command)
        {
            var result = await _service.CreateTicket(
                new CreateTicketCommand
                {
                    OwnerFullName = command.OwnerFullName,
                    PhoneNumber = command.PhoneNumber,
                    Text = command.Text,
                    Title = command.Title,
                    UserId = User.GetUserId(),
                });
            return CommandResult<Guid>(result);
        }
        [HttpPost("SendTicketMessage")]
        public async Task<ApiResult> SendMessageInTicket(SendTicketMessageViewModel command)
        {
            var result = await _service.SendMessageInTicket(
                new SendTicketMessageCommand
                {
                    OwnerFullName = command.OwnerFullName,
                    Text = command.Text,
                    TicketId = command.TicketId,
                    UserId = User.GetUserId(),
                });
            return CommandResult(result);
        }
        [HttpPost("CloseTicket")]
        public async Task<ApiResult> CloseTicket(Guid ticketId)
        {
            var result = await _service.CloseTicket(ticketId);
            return CommandResult(result);
        }
        [HttpGet("GetTicket")]
        public async Task<ApiResult<TicketDto?>> GetTicket(Guid ticketId)
        {
            var result = await _service.GetTicket(ticketId);
            return QueryResult(result);
        }
        [HttpGet("GetTicketByFilter")]
        public async Task<ApiResult<TicketFilterResult>> GetTicketsByFilter
            ([FromQuery] TicketFilterParams filterParams)
        {
            var result = await _service.GetTicketsByFilter(filterParams);
            return QueryResult(result);
        }
    }
}
