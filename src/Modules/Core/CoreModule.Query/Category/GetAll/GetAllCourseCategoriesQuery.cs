using Common.Query;
using CoreModule.Query._Data;
using CoreModule.Query.Category._DTOs;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Query.Category.GetAll;

public class GetAllCourseCategoriesQuery : IQuery<List<CourseCategoryDto>>
{

}
class GetAllCourseCategoriesQueryHandler : IQueryHandler<GetAllCourseCategoriesQuery, List<CourseCategoryDto>>
{
    private readonly QueryContext _context;

    public GetAllCourseCategoriesQueryHandler(QueryContext context)
    {
        _context = context;
    }

    public async Task<List<CourseCategoryDto>> Handle(GetAllCourseCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _context.CourseCategories
            .Where(r => r.ParentId == null)
            .OrderByDescending(d => d.CreationDate)
            .Select(s => new CourseCategoryDto
            {
                Id = s.Id,
                CreationDate = s.CreationDate,
                Title = s.Title,
                Slug = s.Slug,
                ParentId = s.ParentId
            }).ToListAsync(cancellationToken);
    }
}