using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using CommunityWebsite.Models;
using CommunityWebsite.Repositories;
using CommunityWebsite.Controllers;

namespace CommunityWebsite.Tests
{
    //Testing the controller, not the repository
    public class MessagesTests
    {
        //FakeMessageRepository repo;
        //ForumController controller;
        //List<Message> messagesByDate;
        //List<Message> messagesBySubject;
        //List<Message> allMessages;
        //DateTime date;
        //Member member;
        //string subject;

        //public MessagesTests()
        //{
        //    date = new DateTime(2017, 1, 31);
        //    repo = new FakeMessageRepository();
        //    messagesByDate = repo.GetAllMessagesByDate(date);
        //    controller = new ForumController(repo);
        //    member = repo.GetMemberOwnerOfMessage(repo.messages[0]);
        //    messagesBySubject = repo.GetAllMessagesBySubject(repo.messages[2].Subject);
        //    allMessages = repo.GetAllMessages().ToList();
        //    subject = allMessages[0].Subject;
        //}

        //[Fact]
        //public void TestGetAllMessagesByDate()
        //{
        //    var messages = controller.MessagesByDate(date).ViewData.Model as List<Message>;

        //    Assert.Equal(messages.Count, messagesByDate.Count);
            //Assert.Equal(messages[0].Body, messagesByDate[0].Body);
        //}

        //[Fact]
        //public void CanGetMemberOwnerOfMessage()
        //{
        //    Member testMember = controller.OwnerOfMessage(allMessages[0]).ViewData.Model as Member;

        //    Assert.Equal(member.FirstName, testMember.FirstName);
        //}

        //[Fact]
        //public void CanGetAllMessagesBySubject()
        //{
        //    List<Message> messages = controller.AllMessagesBySubject(subject).ViewData.Model as List<Message>;

        //    Assert.Equal(messages.Count, messagesBySubject.Count);
        //}

        //[Fact]
        //public void CanGetMessageByID()
        //{
        //    Message message = controller.Forum(1).ViewData.Model as Message;

        //    Assert.Equal(message.messageID, 1);
        //    Assert.Equal(message.Owner.FirstName, "Maria");
        //}

        //[Fact]
        //public void CanGetAllMessages()
        //{
        //    IEnumerable<Message> testMessageList = controller.Index(0).ViewData.Model as IEnumerable<Message>;

        //    Assert.Equal(testMessageList.Count(), allMessages.Count());
        //}
    }
}
