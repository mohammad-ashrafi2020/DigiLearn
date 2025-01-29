using Common.Domain;
using Common.Domain.Exceptions;
using CoreModule.Domain.Order.DomainServices;
using CoreModule.Domain.Order.Events;

namespace CoreModule.Domain.Order.Models;

public class Order : AggregateRoot
{
    private Order()
    {
    }

    public Order(Guid userId)
    {
        UserId = userId;
        IsPay = false;
        PaymentDate = null;
        Discount = 0;
        OrderItems = new();
        DiscountCode = null;
    }

    public Guid UserId { get; private set; }
    public bool IsPay { get; private set; }
    public int Discount { get; private set; }
    public string? DiscountCode { get; private set; }
    public DateTime? PaymentDate { get; private set; }
    public List<OrderItem> OrderItems { get; private set; } = new();

    public int TotalPrice
    {
        get
        {
            return OrderItems.Sum(s => s.Price) - Discount;
        }
    }

    public async Task AddItem(Guid courseId, IOrderDomainService domainService)
    {
        var price = await domainService.GetCoursePriceById(courseId);
        if (price <= 0)
        {
            throw new InvalidDomainDataException("امکان اضافه کردن این دوره  به سبد خرید وجود ندارد");
        }
        if (OrderItems.Any(f => f.CourseId == courseId))
        {
            return;
        }

        OrderItems.Add(new OrderItem()
        {
            CourseId = courseId,
            Price = price,
            OrderId = Id
        });
    }

    public void FinallyOrder()
    {
        IsPay = true;
        PaymentDate = DateTime.Now;
        AddDomainEvent(new OrderFinallyEvent()
        {
            OrderId = Id,
            UserId = UserId
        });
    }
    public void RemoveItem(Guid id)
    {
        var item = OrderItems.FirstOrDefault(f => f.Id == id);
        if (item != null)
        {
            OrderItems.Remove(item);
        }
    }

}

public class OrderItem : BaseEntity
{
    public Guid CourseId { get; set; }
    public Guid OrderId { get; set; }
    public int Price { get; set; }
}