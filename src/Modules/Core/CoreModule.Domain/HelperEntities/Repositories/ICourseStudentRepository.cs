using Common.Domain.Repository;

namespace CoreModule.Domain.HelperEntities.Repositories;

public interface ICourseStudentRepository : IBaseRepository<CourseStudent>
{
    Task<CourseStudent?> GetCourseStudent(Guid courseId, Guid userId);
    void Delete(CourseStudent student);
}