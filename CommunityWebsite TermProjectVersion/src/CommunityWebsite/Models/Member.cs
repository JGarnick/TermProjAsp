using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public class Member
    {
        private List<Message> messages = new List<Message>();
        private List<BlogPost> blogPosts = new List<BlogPost>();
        private List<Testimonial> testimonials = new List<Testimonial>();
        public int memberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Registered { get; set; }
        public bool LoggedIn { get; set; }
        public string AvatarImg { get; set; }
        public List<Message> Messages
        {
            get { return messages; }
        }
        public List<BlogPost> BlogPosts
        {
            get { return blogPosts; }
        }
        public List<Testimonial> Testimonials
        {
            get { return testimonials; }
        }
        public Member()
        {
            LoggedIn = false;
            AvatarImg = "";
            Registered = DateTime.Now;
        }
    }
}
