using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CommunityWebsite.Controllers
{
    [Route("Services")]
    public class ServicesController : Controller
    {
        [Route("Schedule")]
        public IActionResult Index()
        {
            ViewBag.Title = "Schedule";
            return View("Template1");
        }
    }
}
