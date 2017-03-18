using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebsite.Repositories;
using CommunityWebsite.Models;

namespace CommunityWebsite.Controllers
{
    [Route("Community")]
    public class BlogController : Controller
    {
        private IBlogPostRepository blogRepo;

        public BlogController(IBlogPostRepository repo)
        {
            blogRepo = repo;
        }

        [Route("Blog")]
        public IActionResult Blog(int? id)
        {
            ViewBag.CurrentUser = Helper.CurrentUser;
            ViewBag.CurrentRole = Helper.CurrentRole;
            ViewBag.Sidebar = "true";
            ViewBag.Title = "Blog";
            if (id != null)
            {
                BlogPost post = blogRepo.GetBlogPostByID(id);

                ViewBag.Post = post;
                return View("Template2", post);
            }
            else
                ViewBag.Post = null;

            return View("Template2", blogRepo.GetAllBlogPosts().ToList());
        }
        [HttpPost]
        [Route("Blog/Filtered")]
        public ViewResult Filtered(string selected, string searchString)
        {
            ViewBag.CurrentUser = Helper.CurrentUser;
            ViewBag.CurrentRole = Helper.CurrentRole;
            ViewBag.Title = "Blog";
            ViewBag.Searchbar = "true";

            if (selected == "Title")
            {
                ViewBag.Filtered = "true";
                var post = blogRepo.GetBlogPostByTitle(searchString); 
                //This returns a singular blogPost. Need it to be a list for the template to display it properly
                if (post != null)
                {
                    List<BlogPost> queryResult = new List<BlogPost>();
                    queryResult.Add(post); //Turn the result into a list
                    ViewBag.MessageToUser = "Your search returned these results:";
                    return View("Template2", queryResult);
                }
                else
                {
                    ViewBag.MessageToUser = "Your search returned no results.";
                    return View("Template2");
                }
            }
            else if (selected == "Author")
            {
                ViewBag.Filtered = "true";
                var queryResult = blogRepo.GetBlogPostsByAuthorName(searchString);
                if (queryResult != null && queryResult.Count > 0)
                {
                    ViewBag.MessageToUser = "Your search returned these results:";
                    return View("Template2", queryResult);
                }
                else
                {
                    ViewBag.MessageToUser = "Your search returned no results.";
                    return View("Template2");
                }
            }
            else if (selected == "Date")
            {
                ViewBag.Filtered = "true";
                var queryResult = blogRepo.GetAllBlogPostsByDate(Convert.ToDateTime(searchString));
                if (queryResult != null)
                {
                    ViewBag.MessageToUser = "Your search returned these results:";
                    return View("Template2", queryResult);
                }
                else
                {
                    ViewBag.MessageToUser = "Your search returned no results.";
                    return View("Template2");
                }
            }
            else if (selected == "Category")
            {
                ViewBag.Filtered = "true";
                var queryResult = blogRepo.GetAllBlogPostsByCategory(searchString);
                if (queryResult != null)
                {
                    ViewBag.MessageToUser = "Your search returned these results:";
                    return View("Template2", queryResult);
                }
                else
                {
                    ViewBag.MessageToUser = "Your search returned no results.";
                    return View("Template2");
                }
            }
            else
            {
                return View("Template2");
            }
        }
    }
}
