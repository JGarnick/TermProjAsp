﻿using System;
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
        [Route("")]
        [Route("Index")]
        [Route("Home")]
        public ViewResult Index()
        {
            ViewBag.Title = "Home";
            
            return View("Template1");
        }
    }
}
