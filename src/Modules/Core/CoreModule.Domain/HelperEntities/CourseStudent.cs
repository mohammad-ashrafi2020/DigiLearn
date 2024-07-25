using Common.Domain;

namespace CoreModule.Domain.HelperEntities;

public class CourseStudent : BaseEntity
{
    public Guid CourseId { get; set; }
    public Guid UserId { get; set; }
}