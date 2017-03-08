using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace CommunityWebsite.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Title = "Contact";
            return View("Template1");
        }
        [HttpPost]
        [Route("Success")]
        public IActionResult Success(string subject, string message, string name, string email)
        {
            //Do stuff with form. Probably stuff it in a Form object
            ViewBag.Title = "Contact";
            ViewBag.Success = "true";
            return View("Template1");
        }
    }
}
