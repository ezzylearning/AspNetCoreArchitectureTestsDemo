using MediatR;

namespace OnlineBlog.Application.Articles.CreateArticle
{
    public record CreateArticleCommand(string Title, string Body) : IRequest<bool>;
}
