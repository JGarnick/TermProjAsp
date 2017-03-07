using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;
using Xunit;

namespace CommunityWebsite.Tests
{
    public class ArticlesTests
    {
        [Fact]
        private void ArticlesListIsEmpty()
        {
            Articles.Clear();
            Assert.Empty(Articles.ArticlesList);
        }

        [Fact]
        private void CanAddArticle()
        {
            Articles.Clear();
            NewsModel article = new NewsModel("John Smith", "Trump Dies of Dysentary", "The day we never thought would come, but are so very happy it did...");

            Articles.AddArticle(article);

            Assert.NotEmpty(Articles.ArticlesList);
        }

        [Fact]
        private void GenerateArticlesCreates5Articles()
        {
            Articles.Clear();
            Articles.GenerateArticles();
            Assert.Equal(5, Articles.ArticlesList.Count());
        }

        [Fact]
        private void GenerateArchivedArticlesCreates5Articles()
        {
            Articles.Clear();
            Articles.GenerateArchivedArticles();
            Assert.Equal(5, Articles.ArticlesList.Count());
        }

        [Fact]
        private void GenerateArchivedArticlesCreatesArchivedArticles()
        {
            Articles.Clear();
            int numFalse = 0;
            Articles.GenerateArchivedArticles();
            foreach (NewsModel n in Articles.ArticlesList)
            {
                if (!n.Archived)
                {
                    numFalse += 1;
                }
            }
            Assert.Equal(0, numFalse);
        }
    }
}
