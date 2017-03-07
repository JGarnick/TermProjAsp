using System;
using System.Collections.Generic;

namespace CommunityWebsite.Models
{
    public static class Articles
    {
        private static List<NewsModel> articlesList = new List<NewsModel>();

        
        public static IEnumerable<NewsModel> ArticlesList
        {
            get
            {
                return articlesList;
            }
        }

        public static void AddArticle(NewsModel article)
        {
            articlesList.Add(article);
        }

        public static void GenerateArticles()
        {
            
            for (int i = 1; i <= 5; i++)
            {
                NewsModel article = new NewsModel();
                article.Author = "Test Author " + i;
                article.Title = "Test Article Title " + i;
                article.Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi tincidunt, odio sed commodo blandit, orci nunc porttitor felis, id commodo augue quam vitae magna.Integer lobortis vulputate magna, eu facilisis lacus vestibulum non.Sed venenatis, arcu eget lobortis congue, metus orci venenatis sem, non ullamcorper metus arcu tristique nisi.Cras ultrices, massa eu elementum tempus, dui purus hendrerit ipsum, a molestie eros neque quis nisi.Nam vitae libero nulla. Donec malesuada, sem non gravida ullamcorper, risus odio feugiat diam, in scelerisque ligula velit eget elit. Aenean maximus convallis lacus placerat elementum. Maecenas vel dolor tempor, aliquet augue vel, sodales odio.Nunc gravida purus neque, non dapibus dui viverra sit amet.Nulla vestibulum condimentum ante a finibus. Duis id interdum nulla. Praesent semper convallis nunc eget sagittis. Aenean tempus sagittis sem id vehicula magna commodo sit amet.Nulla porttitor, neque eget pulvinar sollicitudin, justo ex semper ante, vitae feugiat neque lectus at dui.Donec eleifend semper justo quis vestibulum. In hac habitasse platea dictumst. Etiam pharetra risus in sagittis mattis.Etiam vel euismod ipsum.Aenean quis pellentesque est. Integer in mauris eget justo tempor semper. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.Nullam in ornare lacus, vel iaculis enim.Praesent sodales, eros nec tincidunt luctus, nisi elit mattis elit, eu sodales mauris enim a justo. Maecenas tincidunt semper placerat.";


                article.PublishDate = DateTime.Now;

                article.Archived = false;
                Articles.AddArticle(article);
            }
            
            
        }
        public static void GenerateArchivedArticles()
        {
            for (int i = 1; i <= 5; i++)
            {
                NewsModel article = new NewsModel();
                article.Author = "Test Author " + i;
                article.Title = "Test Article Title " + i;
                article.Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi tincidunt, odio sed commodo blandit, orci nunc porttitor felis, id commodo augue quam vitae magna.Integer lobortis vulputate magna, eu facilisis lacus vestibulum non.Sed venenatis, arcu eget lobortis congue, metus orci venenatis sem, non ullamcorper metus arcu tristique nisi.Cras ultrices, massa eu elementum tempus, dui purus hendrerit ipsum, a molestie eros neque quis nisi.Nam vitae libero nulla. Donec malesuada, sem non gravida ullamcorper, risus odio feugiat diam, in scelerisque ligula velit eget elit. Aenean maximus convallis lacus placerat elementum. Maecenas vel dolor tempor, aliquet augue vel, sodales odio.Nunc gravida purus neque, non dapibus dui viverra sit amet.Nulla vestibulum condimentum ante a finibus. Duis id interdum nulla. Praesent semper convallis nunc eget sagittis. Aenean tempus sagittis sem id vehicula magna commodo sit amet.Nulla porttitor, neque eget pulvinar sollicitudin, justo ex semper ante, vitae feugiat neque lectus at dui.Donec eleifend semper justo quis vestibulum. In hac habitasse platea dictumst. Etiam pharetra risus in sagittis mattis.Etiam vel euismod ipsum.Aenean quis pellentesque est. Integer in mauris eget justo tempor semper. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.Nullam in ornare lacus, vel iaculis enim.Praesent sodales, eros nec tincidunt luctus, nisi elit mattis elit, eu sodales mauris enim a justo. Maecenas tincidunt semper placerat.";


                article.PublishDate = DateTime.Now;

                article.Archived = true;
                Articles.AddArticle(article);
            }
        }

        public static void Clear()
        {
            articlesList.Clear();
        }
    }
}
