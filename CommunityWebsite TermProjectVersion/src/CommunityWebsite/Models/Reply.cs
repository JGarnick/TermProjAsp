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
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Subject { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 10)]
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
