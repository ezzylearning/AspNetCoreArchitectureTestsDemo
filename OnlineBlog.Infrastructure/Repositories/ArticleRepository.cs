using OnlineBlog.Domain.Articles;

namespace OnlineBlog.Infrastructure.Repositories
{
    public class ArticleRepository(BloggerDbContext bloggerDbContext) : IArticleRepository
    {
        public void Add(Article article)
        {
            bloggerDbContext.Articles.Add(article);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await bloggerDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
