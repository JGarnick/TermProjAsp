using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebsite.Repositories
{
    public class EFMemberRepository : IMemberRepository
    {
        private AppIdentityDbContext context;

        public EFMemberRepository(AppIdentityDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Member> GetAllMembers()
        {
            return context.Users.Include(u => u.Roles).AsQueryable();
        }

        public List<Member> GetAllMembersRegisteredBetweenDates(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Member> GetAllMembersRegisteredOnDate(DateTime registerDate)
        {
            throw new NotImplementedException();
        }

        public string GetUserRole(Member member)
        {
            throw new NotImplementedException();
        }

    }
}
