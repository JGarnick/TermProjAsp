using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityWebsite.Repositories;
using CommunityWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebsite.Controllers
{
    [Route("Community")] //Set "Community/ before Forum in the URL
    public class ForumController : Controller
    {
        private IMessageRepository messageRepo;
        
        public ForumController(IMessageRepository repo)
        {
            messageRepo = repo;
        }

        [Route("[action]")] //Default Forum page
        public ActionResult Forum(int? messageID)
        {
            //If I don't have a messageID, then return all messages
            //Otherwise, return the message and a new reply object to be filled out
            ViewBag.Title = "Forum";
            ViewBag.Sidebar = "true";
            string user = HttpContext.User.Identity.Name;
            ViewBag.User = user;
            if (messageID != null)
            {
                if(HttpContext.User.Identity.IsAuthenticated)
                {
                    var message = (from m in messageRepo.GetAllMessages() //Get the message from Context that matches the ID
                                   where m.messageID == messageID
                                   select m).FirstOrDefault<Message>();
                    ViewBag.Message = message; //Set Viewbag to pass the message to the reply partial view

                    return View("Template2", new Reply()); //This will serve to set the Model type appropriately for conditions in Template
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            else
                ViewBag.Message = null;
            return View("Template2", messageRepo.GetAllMessages().ToList());
        }
        [HttpPost]
        [Route("Forum/Reply")] //Come here from reply to make more replies
        public ActionResult Reply(int id, Reply returned)
        {
            var message = (from m in messageRepo.GetAllMessages()
                               where m.messageID == id
                               select m).FirstOrDefault<Message>();

            ViewBag.Message = message;
            ViewBag.Title = "Forum";
            ViewBag.Sidebar = "true";

            message.Replies.Add(returned); //Add the reply to the message's list of replies
            messageRepo.Update(message); //Save the changes to the database

            return View("Template2", returned);
        }
        [HttpPost]
        [Route("Forum")] //Come here from New Message
        public ActionResult Forum(Message returned)
        {
            ViewBag.Title = "Forum";
            ViewBag.Sidebar = "true";

            messageRepo.Add(returned);

            return View("Template2", messageRepo.GetAllMessages().ToList());
        }
        [HttpPost]
        [Route("Forum/Filtered")] //Come here if clicking on Search button
        public ViewResult Filtered(string selected, string searchString)
        {
            ViewBag.Title = "Forum";
            ViewBag.Searchbar = "true";

            if(selected == "Subject")
            {
                ViewBag.Filtered = "true";
                var queryResult = messageRepo.GetAllMessagesBySubject(searchString);
                if(queryResult != null && queryResult.Count > 0)
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
            else if(selected == "Member")
            {
                ViewBag.Filtered = "true";
                var queryResult = messageRepo.GetMessagesByOwnerName(searchString);
                if (queryResult != null && queryResult.Count > 0)
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
            else if(selected == "Date")
            {
                ViewBag.Filtered = "true";
                var queryResult = messageRepo.GetAllMessagesByDate(Convert.ToDateTime(searchString));
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

        [HttpGet]
        //[Route("Forum/{NewMessage}")]
        [Route("Forum/NewMessage")]
        public ActionResult NewMessage()
        {
            ViewBag.Title = "Forum";

            return View("Template2", new Message());
        }
        public ActionResult DeleteMessage(int id)
        {
            var message = (from m in messageRepo.GetAllMessages()
                           where m.messageID == id
                           select m).FirstOrDefault<Message>();

            messageRepo.Delete(message);
            return RedirectToAction("Forum");
        }
    }
}
