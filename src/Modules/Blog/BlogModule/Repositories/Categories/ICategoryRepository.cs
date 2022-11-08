using BlogModule.Context;
using BlogModule.Domain;
using Common.Domain.Repository;
using Common.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace BlogModule.Repositories.Categories;

interface ICategoryRepository : IBaseRepository<Category>
{
    void Delete(Category category);
    Task<List<Category>> GetAll();
}
class CategoryRepository : BaseRepository<Category, BlogContext>, ICategoryRepository
{
    public CategoryRepository(BlogContext context) : base(context)
    {
    }

    public void Delete(Category category)
    {
        Context.Categories.Remove(category);
    }

    public async Task<List<Category>> GetAll()
    {
        return await Context.Categories.ToListAsync();
    }
}