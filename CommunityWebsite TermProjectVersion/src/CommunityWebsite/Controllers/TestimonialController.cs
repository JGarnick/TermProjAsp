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
    public class TestimonialController : Controller
    {
        private ITestimonialRepository testRepo;

        public TestimonialController(ITestimonialRepository repo)
        {
            testRepo = repo;
        }

        [Route("Testimonials")]
        public IActionResult Testimonials(int? id)
        {
            ViewBag.CurrentUser = "Current User"; //This will need to change to a real user
            ViewBag.Sidebar = "false";
            ViewBag.Title = "Testimonials";
            if (id != null)
            {
                Testimonial test = testRepo.GetTestimonialByID(id);

                ViewBag.Post = test;
                return View("Template2", test);
            }
            else
                ViewBag.Post = null;

            return View("Template2", testRepo.GetAllTestimonials().ToList());
        }
        [HttpPost]
        [Route("Blog/{filtered}")]
        public ViewResult Filtered(string selected, string searchString)
        {
            ViewBag.Title = "Testimonials";
            ViewBag.Searchbar = "false";

            
            if (selected == "Member")
            {
                ViewBag.Filtered = "true";

                var queryResult = testRepo.GetTestimonialsByAuthorName(searchString);
                if (queryResult != null && queryResult.Count > 0)
                {
                    ViewBag.MessageToUser = "Your search returned these results:";
                    return View("Template2", queryResult);
                }
                //var member = testRepo.GetOwnerByName(searchString);
                //if (member != null)
                //{
                //    var queryResult = testRepo.GetAllTestimonialsByOwner(member);
                //    if (queryResult.Count > 0)
                //    {
                //        ViewBag.MessageToUser = "Your search returned these results:";
                //        return View("Template2", queryResult);
                //    }
                //    else
                //    {
                //        ViewBag.MessageToUser = "Your search returned no results.";
                //        return View("Template2");
                //    }
                //}
                else
                {
                    ViewBag.MessageToUser = "Your search returned no results.";
                    return View("Template2");
                }
            }
            else if (selected == "Date")
            {
                ViewBag.Filtered = "true";
                var queryResult = testRepo.GetAllTestimonialsByDate(Convert.ToDateTime(searchString));
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
