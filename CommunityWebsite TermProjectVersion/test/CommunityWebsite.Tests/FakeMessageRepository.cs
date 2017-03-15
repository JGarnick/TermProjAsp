using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebsite.Repositories
{
    //public class FakeMessageRepository : IMessageRepository
    //{
    //    public List<Message> messages = new List<Message>();
    //    public FakeMessageRepository()
    //    {
    //        Member member = new Member { FirstName = "John", Email = "jsmith@gmail.com", LastName = "Smith", Phone = "5415551111", Registered = new DateTime(2017, 1, 20) };
    //        Message message = new Message { Subject = "Subject1", Body = "Body1", Date = new DateTime(2017, 1, 31), From = member.FirstName + " " + member.LastName, Topic = "Topic1", Owner = member, messageID = 0 };
    //        member.Messages.Add(message);
            
    //        messages.Add(message);
            


    //        member = new Member { FirstName = "Mike", Email = "mbrown@gmail.com", LastName = "Brown", Phone = "5415552222", Registered = new DateTime(2017, 1, 22), memberID = 0 };
    //        message = new Message { Subject = "Subject2", Body = "Body2", Date = new DateTime(2017, 1, 31), From = member.FirstName + " " + member.LastName, Topic = "Topic2", Owner = member, messageID = 0 };
    //        member.Messages.Add(message);
           
    //        messages.Add(message);

    //        member = new Member { FirstName = "Maria", Email = "msanchez@gmail.com", LastName = "Sanchez", Phone = "5415553333", Registered = new DateTime(2017, 1, 22), memberID = 1 };
    //        message = new Message { Subject = "Subject3", Body = "Body3", Date = new DateTime(2017, 2, 01), From = member.FirstName + " " + member.LastName, Topic = "Topic3", Owner = member, messageID = 1 };
    //        member.Messages.Add(message);
           
    //        messages.Add(message);

    //        member = new Member { FirstName = "Miguel", Email = "miguel.s@gmail.com", LastName = "Sanchez", Phone = "5415554444", Registered = new DateTime(2017, 1, 21), memberID = 2 };
    //        message = new Message { Subject = "Subject4", Body = "Body4", Date = new DateTime(2017, 2, 01), From = member.FirstName + " " + member.LastName, Topic = "Topic4", Owner = member, messageID = 2 };
    //        member.Messages.Add(message);
           
    //        messages.Add(message);

    //        member = new Member { FirstName = "Andrea", Email = "a.johnson@gmail.com", LastName = "Johnson", Phone = "5415555555", Registered = new DateTime(2017, 1, 23), memberID = 3 };
    //        message = new Message { Subject = "Subject5", Body = "Body5", Date = new DateTime(2017, 1, 11), From = member.FirstName + " " + member.LastName, Topic = "Topic5", Owner = member, messageID = 3 };
    //        member.Messages.Add(message);
            
    //        messages.Add(message);
    //    }
        

    //    public List<Message> GetAllMessagesByDate(DateTime date)
    //    {
    //        return messages.Where(m => m.Date == date).ToList();
    //    }

    //    public List<Message> GetAllMessagesBySubject(string subject)
    //    {
    //        return messages.Where(m => m.Subject == subject).ToList();
    //    }

    //    public Message GetMessageByID(int ID)
    //    {
    //        return (from m in messages
    //                where m.messageID == ID
    //                select m).FirstOrDefault<Message>();
    //    }

    //    public Member GetMemberOwnerOfMessage(Message message)
    //    {
    //        Member member = message.Owner;
    //        return member;
    //    }

    //    public IQueryable<Message> GetAllMessages()
    //    {
    //        return messages.AsQueryable();
    //    }

    //    public List<Reply> GetRepliesByMessageID(int ID)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int Update(Message message)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
