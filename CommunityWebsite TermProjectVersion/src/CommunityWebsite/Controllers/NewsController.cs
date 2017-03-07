using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebsite.Models;

//TODO remove News Controller from term project
//TODO remove news classes

namespace CommunityWebsite.Controllers
{
    public class NewsController : Controller
    {
        // GET: /<controller>/
        public ViewResult Index()
        {
            if (Articles.ArticlesList.Count() == 0)
            {
                Articles.GenerateArticles();
                Articles.GenerateArchivedArticles();
            }
            ViewBag.Title = "Today's News";
            
            return View("Today's news");
        }
        public ViewResult Archive()
        {
            if (Articles.ArticlesList.Count() == 0)
            {
                Articles.GenerateArticles();
                Articles.GenerateArchivedArticles();
            }
            ViewBag.Title = "Archived News";
            return View();
        }
    }
}
