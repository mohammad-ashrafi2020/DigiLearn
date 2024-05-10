using CoreModule.Application.Order.AddItem;
using CoreModule.Application.Order.RemoveItem;
using CoreModule.Facade.Orders;
using CoreModule.Query.Order._DTOs;
using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiLearn.Web.Pages;

[Authorize]
public class CartModel : BaseRazor
{
    private readonly IOrderFacade _orderFacade;

    public CartModel(IOrderFacade orderFacade)
    {
        _orderFacade = orderFacade;
    }

    public OrderDto? Order { get; set; }
    public async Task OnGet()
    {
        Order = await _orderFacade.GetCurrentOrder(User.GetUserId());
    }

    public async Task<IActionResult> OnGetAddItem(Guid courseId)
    {
        var result = await _orderFacade.AddItem(new AddOrderItemCommand(User.GetUserId(), courseId));
        return RedirectAndShowAlert(result, RedirectToPage("/cart"));
    }
    public async Task<IActionResult> OnPostDelete(Guid id)
    {
        return await AjaxTryCatch(() => _orderFacade.RemoveItem(new RemoveOrderItemCommand(User.GetUserId(), id)));
    }
}