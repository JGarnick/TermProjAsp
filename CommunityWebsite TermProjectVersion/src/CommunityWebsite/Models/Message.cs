using CommunityWebsite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public class Message
    {
        private List<Reply> replies = new List<Reply>();
        public List<Reply> Replies { get { return replies; } }
        public Member owner = new Member();
        public int messageID { get; set; }
        [Required(ErrorMessage = "Subject field cannot be empty")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Subject must be between 5 and 25 characters")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Body field cannot be empty")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Body requires between 10 and 200 characters")]
        public string Body { get; set; }

        public string From { get; set; }
        [Required(ErrorMessage = "Topic field cannot be empty")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Topic requires between 5 and 25 characters")]
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public Member Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }
    }
}
