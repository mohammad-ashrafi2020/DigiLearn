using Common.Query;
using CoreModule.Query._Data;
using CoreModule.Query.Course._DTOs;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Query.Course.GetByFilter;

public class GetCoursesByFilterQuery : QueryFilter<CourseFilterResult, CourseFilterParams>
{
    public GetCoursesByFilterQuery(CourseFilterParams filterParams) : base(filterParams)
    {
    }
}

class GetCoursesByFilterQueryHandler : IQueryHandler<GetCoursesByFilterQuery, CourseFilterResult>
{
    private readonly QueryContext _context;

    public GetCoursesByFilterQueryHandler(QueryContext context)
    {
        _context = context;
    }

    public async Task<CourseFilterResult> Handle(GetCoursesByFilterQuery request, CancellationToken cancellationToken)
    {
        var result = _context.Courses
            .Include(c => c.Teacher.User)
            .Include(c => c.Category)
            .Include(c => c.SubCategory)
            .Include(c => c.Sections)
            .ThenInclude(c => c.Episodes)
            .AsQueryable();

        switch (request.FilterParams.FilterSort)
        {
            case CourseFilterSort.Latest:
                result = result.OrderByDescending(d => d.LastUpdate);
                break;
            case CourseFilterSort.Expensive:
                result = result.OrderByDescending(d => d.Price);
                break;
            case CourseFilterSort.Oldest:
                result = result.OrderBy(d => d.LastUpdate);
                break;
        }
        switch (request.FilterParams.SearchByPrice)
        {
            case SearchByPrice.Free:
                result = result.Where(r => r.Price == 0);
                break;
            case SearchByPrice.NotFree:
                result = result.Where(r => r.Price > 0);
                break;
        }

        if (request.FilterParams.CourseStatus != null)
        {
            result = result.Where(r => r.CourseStatus == request.FilterParams.CourseStatus);

        }
        if (request.FilterParams.CourseLevel != null)
        {
            result = result.Where(r => r.CourseLevel == request.FilterParams.CourseLevel);

        }
        if (string.IsNullOrWhiteSpace(request.FilterParams.CategorySlug) == false)
        {
            result = result.Where(r => r.Category.Slug == request.FilterParams.CategorySlug ||
                                       r.SubCategory.Slug == request.FilterParams.CategorySlug);

        }

        if (string.IsNullOrWhiteSpace(request.FilterParams.Search) == false)
        {
            result = result.Where(r => r.Slug.Contains(request.FilterParams.Search) ||
                                       r.Title.Contains(request.FilterParams.Search));
        }

        if (request.FilterParams.TeacherId != null)
            result = result.Where(r => r.TeacherId == request.FilterParams.TeacherId);
        if (request.FilterParams.ActionStatus != null)
        {
            result = result.Where(r => r.Status == request.FilterParams.ActionStatus);
        }




        var skip = (request.FilterParams.PageId - 1) * request.FilterParams.Take;

        var data = await result.Skip(skip).Take(request.FilterParams.Take)
            .ToListAsync(cancellationToken);

        var model = new CourseFilterResult()
        {
            Data =
                data.Select(s => new CourseFilterData
                {
                    Id = s.Id,
                    CreationDate = s.CreationDate,
                    ImageName = s.ImageName,
                    Title = s.Title,
                    Slug = s.Slug,
                    Price = s.Price,
                    CourseStatus = s.Status,
                    Teacher = $"{s.Teacher.User.Name} {s.Teacher.User.Family}",
                    Sections = s.Sections.Select(r => new CourseSectionDto
                    {
                        Id = r.Id,
                        CreationDate = r.CreationDate,
                        CourseId = r.CourseId,
                        Title = r.Title,
                        DisplayOrder = r.DisplayOrder,
                        Episodes = r.Episodes.Select(e => new EpisodeDto
                        {
                            Id = e.Id,
                            CreationDate = e.CreationDate,
                            SectionId = e.SectionId,
                            Title = e.Title,
                            EnglishTitle = e.EnglishTitle,
                            Token = e.Token,
                            TimeSpan = e.TimeSpan,
                            VideoName = e.VideoName,
                            AttachmentName = e.AttachmentName,
                            IsActive = e.IsActive,
                            IsFree = e.IsFree
                        }).ToList()
                    }).ToList()

                }).ToList()
        };

        model.GeneratePaging(result, request.FilterParams.Take, request.FilterParams.PageId);
        return model;
    }
}