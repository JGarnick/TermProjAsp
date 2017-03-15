using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;

namespace CommunityWebsite.Repositories
{
    public interface IMessageRepository
    {
        List<Message> GetAllMessagesByDate(DateTime date);

        IQueryable<Message> GetAllMessages();

        Member GetMemberOwnerOfMessage(Message message);
        List<Message> GetAllMessagesBySubject(string subject);
        Message GetMessageByID(int ID);

        List<Reply> GetRepliesByMessageID(int ID);
        List<Message> GetAllMessagesByOwner(Member owner);
        List<Message> GetMessagesByOwnerName(string name);
        int Add(Message message);
        int Update(Message message);

        int Delete(Message message);
    }
}
