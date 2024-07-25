using Common.Infrastructure.Repository;
using CoreModule.Domain.HelperEntities;
using CoreModule.Domain.HelperEntities.Repositories;

namespace CoreModule.Infrastructure.Persistent.HelperEntities.Repositories;

public class CourseStudentRepository : BaseRepository<CourseStudent, CoreModuleEfContext>, ICourseStudentRepository
{
    public CourseStudentRepository(CoreModuleEfContext context) : base(context)
    {
    }
}