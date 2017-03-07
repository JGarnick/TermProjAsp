using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public class BlogPost
    {
        private string status { get; set; }
        private DateTime created { get; set; }
        public Member author = new Member();
        public Member Author { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get { return created; } }
        public int BlogPostID { get; set; }
        public string Status { get { return status; } }
        public string URL { get; set; }
        public string ShortDescription { get; set; }
        public string Category { get; set; }
        public BlogPost()
        {
            status = "Active";
            created = DateTime.Now;
        }

        public int SetStatus(int statusCode)
        {
            if(statusCode == 1 && this.status != "Active")
            {
                this.status = "Active";
                return 1;
            }
            else if(statusCode == 0 && this.status != "InActive")
            {
                this.status = "InActive";
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    
}
