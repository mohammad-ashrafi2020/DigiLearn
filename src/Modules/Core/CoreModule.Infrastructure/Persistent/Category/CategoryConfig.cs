using Common.Infrastructure.Repository;
using CoreModule.Domain.Category.Models;
using CoreModule.Domain.Category.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreModule.Infrastructure.Persistent.Category;

public class CategoryConfig : IEntityTypeConfiguration<CourseCategory>
{
    public void Configure(EntityTypeBuilder<CourseCategory> builder)
    {
        builder.ToTable("Categories");
        builder.HasIndex(b => b.Slug).IsUnique();

        builder.Property(b => b.Slug)
            .IsRequired()
            .HasMaxLength(100)
            .IsUnicode(false);


        builder.HasMany<CourseCategory>()
            .WithOne().OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(f => f.ParentId);
    }
}

public class CourseCategoryRepository : BaseRepository<CourseCategory, CoreModuleEfContext>, ICourseCategoryRepository
{
    public CourseCategoryRepository(CoreModuleEfContext context) : base(context)
    {
    }

    public async Task Delete(CourseCategory category)
    {
        var categoryHasCourse = await Context.Courses
            .AnyAsync(f => f.CategoryId == category.Id || f.SubCategoryId == category.Id);

        if (categoryHasCourse)
        {
            throw new Exception("این دسته بندی دارای چندین دوره است");
        }

        var children = await Context.Categories.Where(r => r.ParentId == category.Id).ToListAsync();
        if (children.Any())
        {
            foreach (var child in children)
            {
                var isAnyCourse = await Context.Courses
                    .AnyAsync(f => f.CategoryId == category.Id || f.SubCategoryId == category.Id);
                if (isAnyCourse)
                {
                    throw new Exception("این دسته بندی دارای چندین دوره است");
                }
                else
                {
                    Context.Remove(child);
                }
            }
        }
        Context.Remove(category);
        await Context.SaveChangesAsync();
    }
}