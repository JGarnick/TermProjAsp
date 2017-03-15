using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebsite.Repositories
{
    public class EFMessageRepository : IMessageRepository
    {
        private ApplicationDbContext context;

        public EFMessageRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }


        public List<Message> GetAllMessagesByDate(DateTime date)
        {
            return context.Messages.Where(m => m.Date == date).Include(m => m.Owner).ToList();
        }

        public Message GetMessageByID(int ID)
        {
            return (from m in context.Messages
             where m.messageID == ID
             select m).FirstOrDefault<Message>();
        }

        public List<Message> GetAllMessagesBySubject(string subject)
        {
            return context.Messages.Where(m => m.Subject == subject).Include(m => m.Owner).Include(m => m.Replies).ToList();
        }

        public Member GetMemberOwnerOfMessage(Message message)
        {
            return message.Owner;
        }

        public IQueryable<Message> GetAllMessages()
        {
            return context.Messages.Include(m => m.Owner).Include(m => m.Replies);
        }

        public List<Reply> GetRepliesByMessageID(int ID)
        {
            List<Reply> replies = GetMessageByID(ID).Replies.ToList();
            return replies;
        }

        public int Update(Message message)
        {
            context.Messages.Update(message);
            return context.SaveChanges();
        }

        public List<Message> GetAllMessagesByOwner(Member owner)
        {
            return GetAllMessages().Where(m => m.Owner.Id == owner.Id).ToList();
        }
        //This won't be enough if there are 2 people of the same name. Could theoretically make people pick a unique nickname or something.
        public List<Message> GetMessagesByOwnerName(string name)
        {
            List<Message> messages = context.Messages.Where(m => m.Owner.Name == name).ToList();

            return messages;
        }

        public int Add(Message message)
        {
            context.Messages.Add(message);
            return context.SaveChanges();
        }

        public int Delete(Message message)
        {
            context.Messages.Remove(message);
            return context.SaveChanges();
        }
    }
}
