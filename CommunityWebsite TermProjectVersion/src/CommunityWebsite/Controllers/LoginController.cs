using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CommunityWebsite.Models;

namespace CommunityWebsite.Controllers
{
    [Route("Community")]
    public class LoginController : Controller
    {
        protected class Helper
        {
            public static bool LoginSuccess { get; set; }
            public static bool RegisterSuccess { get; set; }
        }
        private UserManager<Member> userManager;
        private SignInManager<Member> signInManager;

        public LoginController(UserManager<Member> usrMgr, SignInManager<Member> sim)
        {
            userManager = usrMgr;
            signInManager = sim;
        }
        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Title = "Register";
            return View("Template1", new Member());
        }

        [Route("Login")]
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            if (Helper.RegisterSuccess)
            {
                ViewBag.SuccessMessage = "Congratulations! You've successfully joined the community! Just log in below to enjoy the benefits of membership!";
                Helper.RegisterSuccess = false;
            }
            else if(Helper.LoginSuccess)
            {
                //Because SuccessMessage isn't null, this will trigger the template to go to "_LoginSuccess"
                ViewBag.SuccessMessage = "Welcome " + HttpContext.User.Identity.Name + ", you've successfully Logged in";
                Helper.LoginSuccess = false;
                return View("Template1");
            }

            return View("Template1", new LoginViewModel());
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Member user = await userManager.FindByNameAsync(vm.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync(); //Signs out a current user, but crashes if their isn't one
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync( user, vm.Password, false, false);

                    if (result.Succeeded)
                    {
                        Helper.LoginSuccess = true;
                        return RedirectToAction("Login");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Invalid user or password");

            }
            return View("Template1", vm);
        }
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(Member member)
        {
           
            ViewBag.Title = "Register";
            

            if(ModelState.IsValid)
            {
                
                IdentityResult result = await userManager.CreateAsync(member, member.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(member, "Member");
                    if (result.Succeeded)
                    {
                        Helper.RegisterSuccess = true;
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            // We get here either if the model state is invalid or if create user fails
            return View(member);
        }
        
    }
}
