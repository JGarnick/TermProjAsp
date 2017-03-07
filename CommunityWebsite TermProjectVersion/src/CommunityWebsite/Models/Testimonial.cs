using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public class Testimonial
    {
        private DateTime created { get; set; }
        public string Title {get; set;}
        public string Body { get; set; }
        public DateTime Created { get { return created; } }
        public int TestimonialID { get; set; }
        public Member Owner { get; set; }

        public Testimonial()
        {
            created = DateTime.Now;
        }
    }
}
