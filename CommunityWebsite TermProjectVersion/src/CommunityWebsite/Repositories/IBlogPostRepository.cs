using CommunityWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Repositories
{
    public interface IBlogPostRepository
    {
        IQueryable<BlogPost> GetAllBlogPosts();
        List<BlogPost> GetAllBlogPostsByAuthor(Member author);
        BlogPost GetBlogPostByTitle(string title);
        List<BlogPost> GetAllBlogPostsByDate(DateTime date);
        List<BlogPost> GetAllBlogPostsByStatus(string status);
        int Update(BlogPost post);
        BlogPost GetBlogPostByID(int? ID);
        Member GetAuthorByName(string name);
        List<BlogPost> GetAllBlogPostsByCategory(string category);
    }
}
