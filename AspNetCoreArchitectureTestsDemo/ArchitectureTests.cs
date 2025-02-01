using NetArchTest.Rules;

using OnlineBlog.Domain;
using OnlineBlog.Domain.Articles;
using OnlineBlog.Infrastructure.Repositories;

using System.Reflection;

namespace AspNetCoreArchitectureTestsDemo
{
    public class ArchitectureTests
    {
        private Assembly DomainAssembly = typeof(Article).Assembly;
        private Assembly ApplicationAssembly = typeof(IArticleRepository).Assembly;
        private Assembly InfrastructureAssembly = typeof(ArticleRepository).Assembly;

        [Fact]
        public void Domain_Classes_Should_Be_Sealed()
        {
            var result = Types
                .InAssembly(DomainAssembly)
                .That().AreClasses()
                .Should().BeSealed()
                .GetResult();

            Assert.True(result.IsSuccessful, "All Domain classes must be sealed.");
        }

        [Fact]
        public void Repository_Classes_Should_End_With_Repository()
        {
            var result = Types
                .InAssembly(InfrastructureAssembly)
                .That()
                .ResideInNamespace("OnlineBlog.Infrastructure.Repositories")
                .And()
                .AreClasses()
                .Should()
                .HaveNameEndingWith("Repository")
                .GetResult();

            Assert.True(result.IsSuccessful, "All repository classes should end with 'Repository'.");
        }

        [Fact]
        public void Domain_Should_Not_Depend_On_Other_Layers()
        {
            var result = Types.InAssembly(DomainAssembly)
                .ShouldNot()
                .HaveDependencyOnAny(
                    "OnlineBlog.Application",
                    "OnlineBlog.Infrastructure"
                ).GetResult();

            Assert.True(result.IsSuccessful, "Domain layer should not depend on Application or Infrastructure layers.");
        }

        [Fact]
        public void Domain_Should_Not_Depend_On_Application_Layer()
        {
            var result = Types.InAssembly(DomainAssembly)
                .That()
                .ResideInNamespace("OnlineBlog.Domain")
                .ShouldNot()
                .HaveDependencyOn("OnlineBlog.Application")
                .GetResult();

            Assert.True(result.IsSuccessful, "Domain layer should not depend on Application layer.");
        }

        [Fact]
        public void Domain_Should_Not_Depend_On_Infrastructure_Layer()
        {
            var result = Types.InAssembly(DomainAssembly)
                .That()
                .ResideInNamespace("OnlineBlog.Domain")
                .ShouldNot()
                .HaveDependencyOn("OnlineBlog.Infrastructure")
                .GetResult();

            Assert.True(result.IsSuccessful, "Domain layer should not depend on Infrastructure layer.");
        }

        [Fact]
        public void All_Repositories_Should_Implement_IRepository()
        {
            var result = Types.InCurrentDomain()
                .That()
                .ResideInNamespace("OnlineBlog.Infrastructure.Repositories")
                .And()
                .AreClasses()
                .Should().ImplementInterface(typeof(IRepository))
                .GetResult();

            Assert.True(result.IsSuccessful, "Domain repositories in Infrastructure layer should implement IRepository.");
        }

    }
}
