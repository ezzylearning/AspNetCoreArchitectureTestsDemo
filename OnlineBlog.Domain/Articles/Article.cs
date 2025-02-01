namespace OnlineBlog.Domain.Articles
{
    public sealed class Article
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        private Article(string title, string body)
        {
            Id = Guid.NewGuid();
            Title = title;
            Body = body;
        }

        private Article() 
        { }

        public static Article CreateArticle(string title, string body)
        {
            return new Article(title, body);
        }
    }
}
