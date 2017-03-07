using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;

namespace CommunityWebsite.Repositories
{
    public class FakeMemberRepository : IMemberRepository
    {
        public List<Member> GetAllMembersRegisteredBetweenDates(DateTime startDate, DateTime endDate)
        {
            List<Member> members;
            Member member1 = new Member() { FirstName = "John", LastName = "Smith", Email = "john@smith.com", Messages = null, Phone = "1111111111", Registered = new DateTime(2017, 1, 31) };
            Member member2 = new Member() { FirstName = "Mike", LastName = "Brown", Email = "mike@brown.com", Messages = null, Phone = "2222222222", Registered = new DateTime(2017, 2, 2) };
            Member member3 = new Member() { FirstName = "Maria", LastName = "Sanchez", Email = "maria@sanchez.com", Messages = null, Phone = "3333333333", Registered = new DateTime(2016, 4, 2) };
            members = new List<Member>() { member1, member2, member3 };

            List<Member> returnList = new List<Member>();
            foreach (Member m in members)
            {
                if (m.Registered.Ticks >= startDate.Ticks && m.Registered.Ticks <= endDate.Ticks)
                    returnList.Add(m);
            }
            return returnList;
        }

        public List<Member> GetAllMembersRegisteredOnDate(DateTime registerDate)
        {
            List<Member> members;
            Member member1 = new Member() { FirstName = "John", LastName = "Smith", Email = "john@smith.com", Messages = null, Phone = "1111111111", Registered = new DateTime(2017, 1, 31) };
            Member member2 = new Member() { FirstName = "Mike", LastName = "Brown", Email = "mike@brown.com", Messages = null, Phone = "2222222222", Registered = new DateTime(2017, 2, 2) };
            Member member3 = new Member() { FirstName = "Maria", LastName = "Sanchez", Email = "maria@sanchez.com", Messages = null, Phone = "3333333333", Registered = new DateTime(2016, 4, 2) };
            members = new List<Member>() { member1, member2, member3 };

            List<Member> returnList = new List<Member>();
            foreach (Member m in members)
            {
                if (m.Registered.Ticks == registerDate.Ticks)
                    returnList.Add(m);
            }
            return returnList;
        }

        public List<Message> GetAllMessagesByMember(Member member)
        {
            Message message1 = new Message() { Subject = "Test Subject 1", Topic = "Test Topic 1", Body = "Test Body 1", Date = DateTime.UtcNow, From = "Test From 1" };
            Message message2 = new Message() { Subject = "Test Subject 2", Topic = "Test Topic 2", Body = "Test Body 2", Date = DateTime.UtcNow, From = "Test From 2" };
            Message message3 = new Message() { Subject = "Test Subject 3", Topic = "Test Topic 3", Body = "Test Body 3", Date = DateTime.UtcNow, From = "Test From 3" };

            List<Message> messageList = new List<Message>() {message1, message2, message3 };

            member = new Member() { FirstName = "John", LastName = "Smith", Email = "john@smith.com", Messages = messageList, Phone = "1111111111", Registered = new DateTime(2017, 1, 31) };

            return member.Messages;
        }

        public Member GetMemberByName(string fullName)
        {
            Member member = new Member() { FirstName = "John", LastName = "Smith", Email = "john@smith.com", Messages = null, Phone = "1111111111", Registered = new DateTime(2017, 1, 31) };
            string memberFullName = member.FirstName + " " + member.LastName;

            if (memberFullName == fullName)
                return member;
            else
                return null;
        }

        public Member GetMemberByPhoneNumber(string phone)
        {
            Member member = new Member() { FirstName = "John", LastName = "Smith", Email = "john@smith.com", Messages = null, Phone = "1111111111", Registered = new DateTime(2017, 1, 31) };

            if (member.Phone == phone)
                return member;
            else
                return null;
        }

        public Member GetMemberRegistrationDate(DateTime date)
        {
            Member member = new Member() { FirstName = "John", LastName = "Smith", Email = "john@smith.com", Messages = null, Phone = "1111111111", Registered = new DateTime(2017, 1, 31) };

            if (member.Registered == date)
                return member;
            else
                return null;
        }
    }
}
