using CommunityWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Repositories
{
    public interface IMemberRepository
    {
        string GetUserRole(Member member);
        List<Member> GetAllMembersRegisteredOnDate(DateTime registerDate);
        List<Member> GetAllMembersRegisteredBetweenDates(DateTime startDate, DateTime endDate);
        IQueryable<Member> GetAllMembers();
    }
}
