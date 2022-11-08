using BlogModule.Context;
using BlogModule.Domain;
using Common.Domain.Repository;
using Common.Infrastructure.Repository;

namespace BlogModule.Repositories.Posts;

interface IPostRepository : IBaseRepository<Post>
{

}

class PostRepository : BaseRepository<Post, BlogContext>, IPostRepository
{
    public PostRepository(BlogContext context) : base(context)
    {
    }
}