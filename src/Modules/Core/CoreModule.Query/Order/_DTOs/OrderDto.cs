using Common.Query;
using Common.Query.Filter;
using CoreModule.Query._DTOs;
using CoreModule.Query.Course._DTOs;

namespace CoreModule.Query.Order._DTOs;

public class OrderDto : BaseDto
{
    public Guid UserId { get; set; }
    public bool IsPay { get; set; }
    public int Discount { get; set; }
    public string? DiscountCode { get; set; }
    public DateTime? PaymentDate { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
    public CoreModuleUserDto User { get; set; }

    public int TotalPrice
    {
        get
        {
            return OrderItems.Sum(s => s.Price);
        }
    }
}

public class OrderItemDto : BaseDto
{
    public Guid OrderId { get; set; }
    public Guid CourseId { get; set; }
    public string CourseTitle { get; set; }
    public string TeacherFullName { get; set; }
    public int Price { get; set; }
}

public class OrderFilterParams : BaseFilterParam
{
    public Guid? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public OrderFilterStatus Status { get; set; }
}

public enum OrderFilterStatus
{
    All,
    Pending,
    Completed
}
public class OrderFilterData : BaseDto
{
    public int ItemCount { get; set; }
    public int TotalPrice { get; set; }
    public DateTime? PaymentDate { get; set; }
    public bool IsPay { get; set; }
    public string UserFullName { get; set; }
    public Guid UserId { get; set; }
}
public class OrderFilterResult : BaseFilter<OrderFilterData>
{

}