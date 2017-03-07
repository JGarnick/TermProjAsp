using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebsite.Repositories
{
    public class EFTestimonialRepository : ITestimonialRepository
    {
        private ApplicationDbContext context;

        public EFTestimonialRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Testimonial> GetAllTestimonials()
        {
            return context.Testimonials.AsQueryable();
        }

        public List<Testimonial> GetAllTestimonialsByDate(DateTime date)
        {
            return GetAllTestimonials().Where(t => t.Created == date).Include(t => t.Owner).ToList();
        }

        public List<Testimonial> GetAllTestimonialsByOwner(Member owner)
        {
            return GetAllTestimonials().Where(t => t.Owner == owner).Include(t => t.Owner).ToList();
        }

        public Member GetOwnerByName(string name)
        {
            Member owner = (from m in context.Members
                            where m.FirstName + " " + m.LastName == name
                            select m).FirstOrDefault<Member>() as Member;

            return owner;
        }

        public Testimonial GetTestimonialByID(int? ID)
        {
            return (from b in context.Testimonials
                    where b.TestimonialID == ID
                    select b).Include(b => b.Owner).FirstOrDefault<Testimonial>();
        }

        public Testimonial GetTestimonialByID(int ID)
        {
            return (from t in context.Testimonials
                    where t.TestimonialID == ID
                    select t).Include(t => t.Owner).FirstOrDefault<Testimonial>();
        }

        public int Update(Testimonial testimonial)
        {
            context.Testimonials.Update(testimonial);
            return context.SaveChanges();
        }
    }
}
