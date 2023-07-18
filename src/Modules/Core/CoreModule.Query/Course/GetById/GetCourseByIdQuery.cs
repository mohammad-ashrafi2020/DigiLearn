using Common.Query;
using CoreModule.Domain.Course.Enums;
using CoreModule.Query._Data;
using CoreModule.Query.Course._DTOs;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Query.Course.GetById;

public record GetCourseByIdQuery(Guid Id) : IQuery<CourseDto?>;


class GetCourseByIdQueryHandler : IQueryHandler<GetCourseByIdQuery, CourseDto?>
{
    private QueryContext _context;

    public GetCourseByIdQueryHandler(QueryContext context)
    {
        _context = context;
    }

    public async Task<CourseDto?> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await _context.Courses
            .Include(c => c.Sections)
            .ThenInclude(c => c.Episodes)
            .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken: cancellationToken);
        if (course == null)
        {
            return null;
        }

        return new CourseDto
        {
            Id = course.Id,
            CreationDate = course.CreationDate,
            TeacherId = course.TeacherId,
            CategoryId = course.CategoryId,
            SubCategoryId = course.SubCategoryId,
            Title = course.Title,
            Slug = course.Slug,
            Description = course.Description,
            ImageName = course.ImageName,
            VideoName = course.VideoName,
            Price = course.Price,
            LastUpdate = course.LastUpdate,
            SeoData = course.SeoData,
            CourseLevel = course.CourseLevel,
            CourseStatus = course.CourseStatus,
            Status = course.Status,
            Sections = course.Sections.Select(s => new CourseSectionDto()
            {
                Title = s.Title,
                Id = s.Id,
                CourseId = s.CourseId,
                CreationDate = s.CreationDate,
                DisplayOrder = s.DisplayOrder,
                Episodes = s.Episodes.Select(r => new EpisodeDto
                {
                    Id = r.Id,
                    CreationDate = r.CreationDate,
                    SectionId = r.SectionId,
                    Title = r.Title,
                    EnglishTitle = r.EnglishTitle,
                    Token = r.Token,
                    TimeSpan = r.TimeSpan,
                    VideoName = r.VideoName,
                    AttachmentName = r.AttachmentName,
                    IsActive = r.IsActive,
                    IsFree = r.IsFree,
                }).ToList()
            }).ToList()
        };
    }
}
