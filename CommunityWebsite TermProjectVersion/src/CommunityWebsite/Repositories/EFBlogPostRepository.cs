using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebsite.Repositories
{
    public class EFBlogPostRepository : IBlogPostRepository
    {
        private ApplicationDbContext context;

        public EFBlogPostRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<BlogPost> GetAllBlogPosts()
        {
            return context.BlogPosts.Include(b => b.Author);
        }

        public List<BlogPost> GetAllBlogPostsByAuthor(Member author)
        {
            return GetAllBlogPosts().Where(b => b.Author.memberID == author.memberID).Include(b => b.Author).ToList();
        }

        public List<BlogPost> GetAllBlogPostsByCategory(string category)
        {
            return GetAllBlogPosts().Where(b => b.Category == category).Include(b => b.Author).ToList();
        }

        public List<BlogPost> GetAllBlogPostsByDate(DateTime date)
        {
            return GetAllBlogPosts().Where(b => b.Created == date).Include(b => b.Author).ToList();
        }

        public List<BlogPost> GetAllBlogPostsByStatus(string status)
        {
            return GetAllBlogPosts().Where(b => b.Status == status).Include(b => b.Author).ToList();
        }

        public Member GetAuthorByName(string name)
        {
            Member owner = (from m in context.Members
                            where m.FirstName + " " + m.LastName == name
                            select m).FirstOrDefault<Member>() as Member;

            return owner;
        }

        public BlogPost GetBlogPostByID(int? ID)
        {
                return (from b in context.BlogPosts
                        where b.BlogPostID == ID
                        select b).Include(b => b.Author).FirstOrDefault<BlogPost>();
        }

        public BlogPost GetBlogPostByTitle(string title)
        {
            return (from b in context.BlogPosts
                           where b.Title == title
                           select b).Include(b => b.Author).FirstOrDefault<BlogPost>();
        }

        public int Update(BlogPost post)
        {
            context.BlogPosts.Update(post);
            return context.SaveChanges();
        }
    }
}
