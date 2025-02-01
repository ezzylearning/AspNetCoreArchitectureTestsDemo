namespace OnlineBlog.Domain.Articles
{
    public interface IArticleRepository : IRepository
    {
        void Add(Article article);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
