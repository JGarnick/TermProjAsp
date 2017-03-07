using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebsite.Models;
using CommunityWebsite.Repositories;

namespace CommunityWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult TestHomePage()
        {
            return View();
        }
        public ViewResult Index()
        {
            ViewBag.Title = "Home Page";
            
            return View();
        }
        [Route("Home/About/Contact")]
        public ViewResult Contact()
        {
            ViewBag.Title = "Contact Page";
            return View();
        }

    }
}
