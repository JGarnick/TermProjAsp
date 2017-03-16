using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;

namespace CommunityWebsite.Repositories
{
    public class EFMemberRepository : IMemberRepository
    {
        private AppIdentityDbContext context;

        public EFMemberRepository(AppIdentityDbContext ctx)
        {
            context = ctx;
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
            //member.Roles
            //string role = (from r in context.UserRoles
            //               where b.BlogPostID == ID
            //               select b).Include(b => b.Author).FirstOrDefault<BlogPost>(); )
        }
    }
}
