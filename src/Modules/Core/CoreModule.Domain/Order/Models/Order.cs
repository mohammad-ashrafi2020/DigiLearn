using Common.Domain;
using Common.Domain.Exceptions;

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

    public void AddItem(Guid courseId, int price)
    {
        if (price <= 0)
        {
            throw new InvalidDomainDataException("امکان اضافه کردن دوره رایگان به سبد خرید وجود ندارد");
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

    public void RemoveItem(Guid courseId)
    {
        var item = OrderItems.FirstOrDefault(f => f.CourseId == courseId);
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