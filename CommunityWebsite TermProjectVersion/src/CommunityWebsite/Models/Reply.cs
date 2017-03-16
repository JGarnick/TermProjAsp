using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public class Reply
    {
        [Required]
        public Member owner = new Member();
        public int replyID { get; set; }
        [Required(ErrorMessage = "Subject cannot be empty")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Subject must have between 5 and 20 characters")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Body cannot be empty")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Body must have a minimum of 10 characters, and has a max of 200")]
        public string Body { get; set; }
        public string From { get; set; }
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
