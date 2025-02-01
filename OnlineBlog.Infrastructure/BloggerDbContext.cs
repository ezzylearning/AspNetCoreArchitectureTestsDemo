using Microsoft.EntityFrameworkCore;

using OnlineBlog.Domain.Articles;

namespace OnlineBlog.Infrastructure
{
    public class BloggerDbContext : DbContext
    {
        public BloggerDbContext(DbContextOptions<BloggerDbContext> dbContextOptions)
                : base(dbContextOptions)
        {

        }

        public DbSet<Article> Articles => Set<Article>();

    }
}
