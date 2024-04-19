namespace CoreModule.Domain.Order.DomainServices;

public interface IOrderDomainService
{
    Task<int> GetCoursePriceById(Guid courseId);
}