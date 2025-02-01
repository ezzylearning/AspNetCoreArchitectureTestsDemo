using MediatR;

using OnlineBlog.Domain.Articles;

namespace OnlineBlog.Application.Articles.CreateArticle
{
    public class CreateArticleCommandHandler(IArticleRepository articleRepository) 
        : IRequest<bool>
    {
        public async Task<bool> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = Article.CreateArticle(request.Title, request.Body);

            articleRepository.Add(article);

            await articleRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}