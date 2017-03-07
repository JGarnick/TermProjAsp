using CommunityWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Repositories
{
    public interface IMemberRepository
    {
        List<Message> GetAllMessagesByMember(Member member);
        Member GetMemberByPhoneNumber(string phone);
        Member GetMemberByName(string name);
        Member GetMemberRegistrationDate(DateTime date);
        List<Member> GetAllMembersRegisteredOnDate(DateTime registerDate);
        List<Member> GetAllMembersRegisteredBetweenDates(DateTime startDate, DateTime endDate);
    }
}
