using CommunityWebsite.Models;
using System;
using System.Collections.Generic;
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
        public string Subject { get; set; }
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

        //This will be deleted once real members are added to project
        //TODO Delete this when real members are added to project
        public static Message TestMessage
        {
            get
            {
                Member member = new Member { FirstName = "John", Email = "jsmith@gmail.com", LastName = "Smith", Phone = "5415551111", Registered = new DateTime(2017, 1, 20) };
                Message message = new Message { Subject = "Subject1", Body = "Body1", Date = new DateTime(2017, 1, 31), From = member.FirstName + " " + member.LastName, Topic = "Topic1", Owner = member };
                return message;
            }
        }
    }
}
