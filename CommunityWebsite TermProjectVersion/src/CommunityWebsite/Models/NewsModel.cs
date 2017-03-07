using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public class NewsModel
    {
        public string Author {get; set;}
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }
        public bool Archived { get; set; }

        public NewsModel(string author = "", string title = "", string body = "", DateTime pubDate = default(DateTime), bool archived = false)
        {
            Author = author;
            Title = title;
            Body = body;
            PublishDate = pubDate;
            Archived = archived;
        }
    }
}

