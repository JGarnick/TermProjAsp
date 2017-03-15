using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public class Member : IdentityUser
    {
        private List<Message> messages = new List<Message>();
        private List<BlogPost> blogposts = new List<BlogPost>();
        private List<Testimonial> testimonials = new List<Testimonial>();
        //public int memberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public DateTime Registered { get; set; }
        public string AvatarImg { get; set; }

        [StringLength(20, MinimumLength = 6)]
        //[RegularExpression(@"^((?=\S*?[A-Z])(?=\S*?[a-z])(?=\S*?[0-9]).{6,})\S$")]
        public string Password { get; set; }
        public List<Message> Messages
        {
            get { return messages; }
            set
            {
                messages = value;
            }
        }
        public List<BlogPost> BlogPosts
        {
            get { return blogposts; }
            set
            {
                blogposts = value;
            }
        }
        public List<Testimonial> Testimonials
        {
            get { return testimonials; }
            set
            {
                testimonials = value;
            }
        }

    }
}
