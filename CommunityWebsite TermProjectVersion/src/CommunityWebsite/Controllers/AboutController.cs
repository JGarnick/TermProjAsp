using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebsite.Models;
using CommunityWebsite.Repositories;

namespace CommunityWebsite.Controllers
{
    [Route("About")]
    public class AboutController : Controller
    {
        [Route("Resume")]
        public IActionResult Resume()
        {
            ViewBag.Details = "false";
            ViewBag.Title = "Resume";
            return View("Template1");
        }
        [Route("Archived")]
        public IActionResult Archived()
        {
            ViewBag.Details = "true";
            ViewBag.Title = "Archived";
            return View("Template1");
        }

    }
}
