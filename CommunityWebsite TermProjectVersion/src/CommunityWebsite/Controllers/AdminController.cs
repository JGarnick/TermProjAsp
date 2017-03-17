using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CommunityWebsite.Repositories;

namespace CommunityWebsite.Controllers
{
    [Route("Admin")]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {

        private UserManager<Member> userManager;

        private IUserValidator<Member> userValidator;
        private IPasswordValidator<Member> passwordValidator;
        private IPasswordHasher<Member> passwordHasher;
        private IMemberRepository memberRepo;
        private AppIdentityDbContext context;

        public AdminController(UserManager<Member> usrMgr,
                IUserValidator<Member> userValid,
                IPasswordValidator<Member> passValid,
                IPasswordHasher<Member> passwordHash,
                IMemberRepository repo,
                AppIdentityDbContext ctx)
        {
            memberRepo = repo;
            userManager = usrMgr;
            userValidator = userValid;
            passwordValidator = passValid;
            passwordHasher = passwordHash;
            context = ctx;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            if(Helper.AdminSuccess != "" || Helper.AdminSuccess != null)
            {
                ViewBag.AdminSuccess = Helper.AdminSuccess;
            }
            ViewBag.TItle = "Index";
            return View("AdminTemplate", memberRepo.GetAllMembers().ToList());
        }

        [Route("CreateAdmin")]
        public IActionResult CreateAdmin()
        {
            ViewBag.TItle = "Create";
            return View("AdminTemplate");
        }
        [Route("CreateAdmin")]
        [HttpPost]
        public async Task<IActionResult> Create(Member admin)
        {
            ViewBag.Title = "Create";
            if (ModelState.IsValid)
            {
                Member user = new Member
                {
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Registered = DateTime.Now,
                    UserName = admin.UserName,
                    Email = admin.Email,
                    Password = admin.Password,
                    Name = admin.FirstName + " " + admin.LastName,
                    Role = "Administrator"
                };
                var admincreate = await userManager.CreateAsync(user, user.Password);
                

                if (admincreate.Succeeded)
                {
                    var adminrole = await userManager.AddToRoleAsync(user, "Administrator");
                    if (adminrole.Succeeded)
                    {
                        Helper.AdminSuccess = "Admin" + admin.Name + " created successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (IdentityError error in adminrole.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    foreach (IdentityError error in admincreate.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    
                }
            }
            return View("AdminTemplate", admin);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            Member user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return RedirectToAction("Index", userManager.Users);
        }
        [Route("Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.Title = "Edit";
            Member user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View("AdminTemplate", user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [Route("Edit")]
        [HttpPost]
        public async Task<IActionResult> Edit(Member member)
        {
            ViewBag.Title = "Edit";
            Member user = await userManager.FindByIdAsync(member.Id);
            if (user != null)
            {
                user.Email = member.Email;
                user.AvatarImg = member.AvatarImg;
                user.FirstName = member.FirstName;
                user.LastName = member.LastName;
                user.Name = member.Name;
                user.Password = member.Password;
                user.PhoneNumber = member.PhoneNumber;
                user.UserName = member.UserName;
                IdentityResult validEmail = await userValidator.ValidateAsync(userManager, user);

                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(member.Password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, member.Password);

                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, member.Password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if ((validEmail.Succeeded && validPass == null)
                        || (validEmail.Succeeded
                        && member.Password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("AdminTemplate", user);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
