using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace CommunityWebsite.Controllers
{
    [Route("Community")]
    public class LoginController : Controller
    {
        [Route("SignUp")]
        public IActionResult Signup()
        {
            ViewBag.Title = "Signup";
            return View("Template1");
        }
        [Route("Login")]
        public IActionResult Login()
        {
            ViewBag.Title = "Login";
            return View("Template1");
        }
        [Route("SignUp/Success")]
        public IActionResult SignupSuccess()
        {
            //TODO Some Logic for determining a successful login and how to display feedback to user
            ViewBag.Title = "SignUp";
            ViewBag.Success = "true";
            return View("Template1");
        }
        [Route("Login/Success")]
        public IActionResult LoginSuccess()
        {
            ViewBag.Title = "Login";
            ViewBag.Successful = "true";
            return View("Template1");
        }
    }
}
