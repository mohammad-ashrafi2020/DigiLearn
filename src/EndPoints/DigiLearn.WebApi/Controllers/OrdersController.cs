using CoreModule.Application.Order.AddItem;
using CoreModule.Application.Order.RemoveItem;
using CoreModule.Facade.Orders;
using CoreModule.Query.Order._DTOs;
using DigiLearn.WebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiLearn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ApiController
    {
        private readonly IOrderFacade _orderFacade;

        public OrdersController(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        [HttpPost("AddOrderItem")]
        public async Task<ApiResult> AddItem(AddOrderItemCommand command)
        {
            return CommandResult(await _orderFacade.AddItem(command));
        }
        
        [HttpDelete("RemoveOrderItem")]
        public async Task<ApiResult> RemoveItem(RemoveOrderItemCommand command)
        {
            return CommandResult(await _orderFacade.RemoveItem(command));
        }
        
        [HttpPatch("FinallyOrder")]
        public async Task<ApiResult> FinallyOrder(Guid orderId)
        {
            return CommandResult(await _orderFacade.FinallyOrder(orderId));
        }

        [HttpGet("GetCurrentOrder")]
        [Authorize]
        public async Task<ApiResult<OrderDto?>> GetCurrentOrder()
        {
            return QueryResult(await _orderFacade.GetCurrentOrder(User.GetUserId()));
        }
    }
}
