using Common.Domain.Repository;
using CoreModule.Domain.Category.Models;

namespace CoreModule.Domain.Category.Repository;

public interface ICategoryRepository : IBaseRepository<CourseCategory>
{
    Task Delete(CourseCategory category);
}