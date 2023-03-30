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
        var mainModel = await _context.CourseCategories
            .Where(c=>c.ParentId==null)
            .Include(c => c.Children)
            .OrderByDescending(d => d.CreationDate)
            .Select(s => new CourseCategoryDto
            {
                Id = s.Id,
                CreationDate = s.CreationDate,
                Title = s.Title,
                Slug = s.Slug,
                ParentId = s.ParentId,
                Children = s.Children.Select(r => new CourseCategoryChild()
                {
                    CreationDate = r.CreationDate,
                    Id = r.Id,
                    ParentId = r.ParentId,
                    Slug = r.Slug,
                    Title = r.Title
                }).ToList()
            }).ToListAsync(cancellationToken);

        return mainModel;
    }
}