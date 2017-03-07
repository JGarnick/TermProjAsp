using CommunityWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CommunityWebsite.Tests
{
    public class NewsModelTests
    {
        [Fact]
        private void CanChangeTitle()
        {
            NewsModel article = new NewsModel("John Smith", "Trump Dies of Dysentary", "The day we never thought would come, but are so very happy it did...");

            article.Title = "World Peace Achieved";

            Assert.Equal("World Peace Achieved", article.Title);
        }

        [Fact]
        private void PublishedDateNotNull()
        {
            NewsModel article = new NewsModel("John Smith", "Trump Dies of Dysentary", "The day we never thought would come, but are so very happy it did...");

            Assert.NotNull(article.PublishDate);
        }

        [Fact]
        private void CanChangeBody()
        {
            NewsModel article = new NewsModel("John Smith", "Trump Dies of Dysentary", "The day we never thought would come, but are so very happy it did...");

            article.Body = "The world rejoices as Vladimir Putin and Donald Trump meet their end in a plane crash while selling US secrets";

            Assert.Equal("The world rejoices as Vladimir Putin and Donald Trump meet their end in a plane crash while selling US secrets", article.Body);
        }

        [Fact]
        private void CanChangeAuthor()
        {
            NewsModel article = new NewsModel("John Smith", "Trump Dies of Dysentary", "The day we never thought would come, but are so very happy it did...");

            article.Author = "Bernie Sanders";

            Assert.Equal("Bernie Sanders", article.Author);
        }

        [Fact]
        private void CanChangeArchived()
        {
            NewsModel article = new NewsModel("John Smith", "Trump Dies of Dysentary", "The day we never thought would come, but are so very happy it did...");

            article.Archived = true;

            Assert.True(article.Archived);
        }
       
    }
}
