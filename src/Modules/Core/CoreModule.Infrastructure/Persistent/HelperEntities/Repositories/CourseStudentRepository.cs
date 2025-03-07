using Common.Infrastructure.Repository;
using CoreModule.Domain.HelperEntities;
using CoreModule.Domain.HelperEntities.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Infrastructure.Persistent.HelperEntities.Repositories;

public class CourseStudentRepository : BaseRepository<CourseStudent, CoreModuleEfContext>, ICourseStudentRepository
{
    public CourseStudentRepository(CoreModuleEfContext context) : base(context)
    {
    }

    public void Delete(CourseStudent student)
    {
        Context.CourseStudents.Remove(student);
    }

    public async Task<CourseStudent?> GetCourseStudent(Guid courseId, Guid userId)
    {
        return await Context.CourseStudents.FirstOrDefaultAsync(f => f.CourseId == courseId && f.UserId == userId);
    }
}