using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain;
using CoreModule.Domain.Order.Models;

namespace CoreModule.Query._Data.Entities;

class OrderQueryModel : BaseEntity
{
    public Guid UserId { get; set; }
    public bool IsPay { get; set; }
    public int Discount { get; set; }
    public string? DiscountCode { get; set; }
    public DateTime? PaymentDate { get; set; }


    public List<OrderItemQueryModel> OrderItems { get; set; }

    [ForeignKey("UserId")]
    public UserQueryModel User { get; set; }
}
class OrderItemQueryModel : BaseEntity
{
    public Guid CourseId { get; set; }
    public Guid OrderId { get; set; }
    public int Price { get; set; }


    [ForeignKey("OrderId")]
    public OrderQueryModel Order { get; set; }
    public CourseQueryModel Course { get; set; }
}