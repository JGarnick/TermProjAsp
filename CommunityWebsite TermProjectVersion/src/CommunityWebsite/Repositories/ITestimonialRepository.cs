using CommunityWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Repositories
{
    public interface ITestimonialRepository
    {
        IQueryable<Testimonial> GetAllTestimonials();
        List<Testimonial> GetAllTestimonialsByDate(DateTime date);
        List<Testimonial> GetAllTestimonialsByOwner(Member owner);
        int Update(Testimonial testimonial);
        Testimonial GetTestimonialByID(int? ID);
        Member GetOwnerByName(string name);
    }
}
