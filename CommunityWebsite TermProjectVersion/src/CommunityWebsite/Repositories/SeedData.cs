using CommunityWebsite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Repositories
{
    public class SeedData
    {
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            UserManager<Member> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<Member>>();

            if (!context.Messages.Any())
            {
                //Member member = new Member { FirstName = "John", Email = "jsmith@gmail.com", LastName = "Smith", PhoneNumber = "5415551111", Registered = new DateTime(2017, 1, 20) };
                //context.Members.Add(member);

                Member member = await userManager.FindByEmailAsync("jsmith@member.com");
                Message message = new Message { Subject = "Subject1", Body = "Body1", Date = new DateTime(2017, 1, 31), From = member.FirstName + " " + member.LastName, Topic = "Topic1", Owner = member };
                member.Messages.Add(message);
                context.Messages.Add(message);
                //await userManager.UpdateAsync(member);


                //member = new Member { FirstName = "Mike", Email = "mbrown@gmail.com", LastName = "Brown", PhoneNumber = "5415552222", Registered = new DateTime(2017, 1, 22) };
                //context.Members.Add(member);
                member = await userManager.FindByEmailAsync("mbrown@member.com");
                message = new Message { Subject = "Subject2", Body = "Body2", Date = new DateTime(2017, 1, 31), From = member.FirstName + " " + member.LastName, Topic = "Topic2", Owner = member };
                member.Messages.Add(message);
                context.Messages.Add(message);
                //await userManager.UpdateAsync(member);

                //member = new Member { FirstName = "Christina", Email = "dancewme0102@yahoo.com", LastName = "Lindsay", PhoneNumber = "5415553333", Registered = new DateTime(2017, 1, 22), LoggedIn = true, AvatarImg = "~/lib/images/head_shot.jpg" };
                //context.Members.Add(member);
                member = await userManager.FindByEmailAsync("dancewme0102@yahoo.com");
                message = new Message { Subject = "Subject3", Body = "Body3", Date = new DateTime(2017, 2, 01), From = member.FirstName + " " + member.LastName, Topic = "Topic3", Owner = member };
                member.Messages.Add(message);
                context.Messages.Add(message);
                //await userManager.UpdateAsync(member);

                //member = new Member { FirstName = "Miguel", Email = "miguel.s@gmail.com", LastName = "Sanchez", PhoneNumber = "5415554444", Registered = new DateTime(2017, 1, 21) };
                //context.Members.Add(member);
                member = await userManager.FindByEmailAsync("msanchez@member.com");
                message = new Message { Subject = "Subject4", Body = "Body4", Date = new DateTime(2017, 2, 01), From = member.FirstName + " " + member.LastName, Topic = "Topic4", Owner = member };
                member.Messages.Add(message);
                context.Messages.Add(message);
                //await userManager.UpdateAsync(member);

                //member = new Member { FirstName = "Andrea", Email = "a.johnson@gmail.com", LastName = "Johnson", PhoneNumber = "5415555555", Registered = new DateTime(2017, 1, 23) };
                //context.Members.Add(member);

                member = await userManager.FindByEmailAsync("ajohnson@member.com");
                message = new Message { Subject = "Subject5", Body = "Body5", Date = new DateTime(2017, 1, 11), From = member.FirstName + " " + member.LastName, Topic = "Topic5", Owner = member };
                member.Messages.Add(message);
                context.Messages.Add(message);
                //await userManager.UpdateAsync(member);

                context.SaveChanges();


            }
            if (!context.BlogPosts.Any() && context.Messages.Any())
            {
                
                Member member = await userManager.FindByEmailAsync("dancewme0102@yahoo.com");

                BlogPost post = new BlogPost
                {
                    Author = member,
                    Title = "10 Kids Unaware of Their Halloween Costume",
                    ShortDescription = "It's one thing to subject yourself to a Halloween costume mishap because, hey, that's your prerogative.",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed convallis ornare nisi, ultrices gravida metus pulvinar id. Maecenas at" + "nibh iaculis, finibus risus vitae, finibus augue. Pellentesque fringilla metus non dui sagittis tincidunt ac a nisi." +
                      "Ut varius odio lacus, quis feugiat ligula tincidunt ut. Sed aliquam condimentum nunc sed vehicula. Donec suscipit, " +
                      "justo sit amet iaculis mollis, lectus libero pharetra nisl, eu lobortis elit turpis efficitur ligula. Mauris commodo nisl" +
                      "vitae sem dignissim, at gravida justo rutrum. Sed interdum volutpat suscipit. In cursus, tellus ut tristique dignissim," +
                      "purus velit posuere felis, non elementum sem augue a augue." +
                      "<br />" +
                    "Vivamus risus eros, elementum quis augue vitae, sollicitudin congue nunc.Sed eros eros, dapibus ut diam non," +
                    "pretium euismod enim.In feugiat tempor consectetur.Proin viverra vel libero at facilisis.Nulla faucibus felis sem," +
                    "eu auctor lorem tincidunt sit amet.Maecenas sed semper est.Maecenas ultrices suscipit ante sit amet consequat.Curabitur" +
                    "ac tellus egestas erat dictum tincidunt.Donec imperdiet tortor et justo tincidunt vulputate.Sed placerat" +
                    "eget elit sit amet condimentum.Maecenas non blandit ex.Sed nec odio id tortor sagittis maximus vel vitae odio." +
                    "Cras vehicula tempor turpis eget mollis."
                };
                member.BlogPosts.Add(post);
                context.BlogPosts.Add(post);
                

               
                post = new BlogPost
                {
                    Author = member,
                    Title = "What Instagram Ads Will Look Like",
                    ShortDescription = "Instagram offered a first glimpse at what its ads will look like in a blog post Thursday. The sample ad, which you can see below.",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed convallis ornare nisi, ultrices gravida metus pulvinar id. Maecenas at" + "nibh iaculis, finibus risus vitae, finibus augue. Pellentesque fringilla metus non dui sagittis tincidunt ac a nisi." +
                      "Ut varius odio lacus, quis feugiat ligula tincidunt ut. Sed aliquam condimentum nunc sed vehicula. Donec suscipit, " +
                      "justo sit amet iaculis mollis, lectus libero pharetra nisl, eu lobortis elit turpis efficitur ligula. Mauris commodo nisl" +
                      "vitae sem dignissim, at gravida justo rutrum. Sed interdum volutpat suscipit. In cursus, tellus ut tristique dignissim," +
                      "purus velit posuere felis, non elementum sem augue a augue." +
                      "<br />" +
                    "Vivamus risus eros, elementum quis augue vitae, sollicitudin congue nunc.Sed eros eros, dapibus ut diam non," +
                    "pretium euismod enim.In feugiat tempor consectetur.Proin viverra vel libero at facilisis.Nulla faucibus felis sem," +
                    "eu auctor lorem tincidunt sit amet.Maecenas sed semper est.Maecenas ultrices suscipit ante sit amet consequat.Curabitur" +
                    "ac tellus egestas erat dictum tincidunt.Donec imperdiet tortor et justo tincidunt vulputate.Sed placerat" +
                    "eget elit sit amet condimentum.Maecenas non blandit ex.Sed nec odio id tortor sagittis maximus vel vitae odio." +
                    "Cras vehicula tempor turpis eget mollis."
                };
                member.BlogPosts.Add(post);
                context.BlogPosts.Add(post);
                


                post = new BlogPost
                {
                    Author = member,
                    Title = "The Future of Magazines Is on Tablets",
                    ShortDescription = "Eric Schmidt has seen the future of magazines, and it's on the tablet. At a Magazine Publishers Association.",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed convallis ornare nisi, ultrices gravida metus pulvinar id. Maecenas at" + "nibh iaculis, finibus risus vitae, finibus augue. Pellentesque fringilla metus non dui sagittis tincidunt ac a nisi." +
                      "Ut varius odio lacus, quis feugiat ligula tincidunt ut. Sed aliquam condimentum nunc sed vehicula. Donec suscipit, " +
                      "justo sit amet iaculis mollis, lectus libero pharetra nisl, eu lobortis elit turpis efficitur ligula. Mauris commodo nisl" +
                      "vitae sem dignissim, at gravida justo rutrum. Sed interdum volutpat suscipit. In cursus, tellus ut tristique dignissim," +
                      "purus velit posuere felis, non elementum sem augue a augue." +
                      "<br />" +
                    "Vivamus risus eros, elementum quis augue vitae, sollicitudin congue nunc.Sed eros eros, dapibus ut diam non," +
                    "pretium euismod enim.In feugiat tempor consectetur.Proin viverra vel libero at facilisis.Nulla faucibus felis sem," +
                    "eu auctor lorem tincidunt sit amet.Maecenas sed semper est.Maecenas ultrices suscipit ante sit amet consequat.Curabitur" +
                    "ac tellus egestas erat dictum tincidunt.Donec imperdiet tortor et justo tincidunt vulputate.Sed placerat" +
                    "eget elit sit amet condimentum.Maecenas non blandit ex.Sed nec odio id tortor sagittis maximus vel vitae odio." +
                    "Cras vehicula tempor turpis eget mollis."
                };
                member.BlogPosts.Add(post);
                context.BlogPosts.Add(post);

                post = new BlogPost
                {
                    Author = member,
                    Title = "Pinterest Now Worth $3.8 Billion",
                    ShortDescription = "Pinterest's valuation is closing in on $4 billion after its latest funding round of $225 million, according to a report.",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed convallis ornare nisi, ultrices gravida metus pulvinar id. Maecenas at" + "nibh iaculis, finibus risus vitae, finibus augue. Pellentesque fringilla metus non dui sagittis tincidunt ac a nisi." +
                      "Ut varius odio lacus, quis feugiat ligula tincidunt ut. Sed aliquam condimentum nunc sed vehicula. Donec suscipit, " +
                      "justo sit amet iaculis mollis, lectus libero pharetra nisl, eu lobortis elit turpis efficitur ligula. Mauris commodo nisl" +
                      "vitae sem dignissim, at gravida justo rutrum. Sed interdum volutpat suscipit. In cursus, tellus ut tristique dignissim," +
                      "purus velit posuere felis, non elementum sem augue a augue." +
                      "<br />" +
                    "Vivamus risus eros, elementum quis augue vitae, sollicitudin congue nunc.Sed eros eros, dapibus ut diam non," +
                    "pretium euismod enim.In feugiat tempor consectetur.Proin viverra vel libero at facilisis.Nulla faucibus felis sem," +
                    "eu auctor lorem tincidunt sit amet.Maecenas sed semper est.Maecenas ultrices suscipit ante sit amet consequat.Curabitur" +
                    "ac tellus egestas erat dictum tincidunt.Donec imperdiet tortor et justo tincidunt vulputate.Sed placerat" +
                    "eget elit sit amet condimentum.Maecenas non blandit ex.Sed nec odio id tortor sagittis maximus vel vitae odio." +
                    "Cras vehicula tempor turpis eget mollis."
                };
                member.BlogPosts.Add(post);
                context.BlogPosts.Add(post);

                post = post = new BlogPost
                {
                    Author = member,
                    Title = "10 Kids Unaware of Their Halloween Costume",
                    ShortDescription = "It's one thing to subject yourself to a Halloween costume mishap because, hey, that's your prerogative.",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed convallis ornare nisi, ultrices gravida metus pulvinar id. Maecenas at" + "nibh iaculis, finibus risus vitae, finibus augue. Pellentesque fringilla metus non dui sagittis tincidunt ac a nisi." +
                      "Ut varius odio lacus, quis feugiat ligula tincidunt ut. Sed aliquam condimentum nunc sed vehicula. Donec suscipit, " +
                      "justo sit amet iaculis mollis, lectus libero pharetra nisl, eu lobortis elit turpis efficitur ligula. Mauris commodo nisl" +
                      "vitae sem dignissim, at gravida justo rutrum. Sed interdum volutpat suscipit. In cursus, tellus ut tristique dignissim," +
                      "purus velit posuere felis, non elementum sem augue a augue." +
                      "<br />" +
                      "Vivamus risus eros, elementum quis augue vitae, sollicitudin congue nunc.Sed eros eros, dapibus ut diam non," +
                      "pretium euismod enim.In feugiat tempor consectetur.Proin viverra vel libero at facilisis.Nulla faucibus felis sem," +
                      "eu auctor lorem tincidunt sit amet.Maecenas sed semper est.Maecenas ultrices suscipit ante sit amet consequat.Curabitur" +
                      "ac tellus egestas erat dictum tincidunt.Donec imperdiet tortor et justo tincidunt vulputate.Sed placerat" +
                      "eget elit sit amet condimentum.Maecenas non blandit ex.Sed nec odio id tortor sagittis maximus vel vitae odio." +
                      "Cras vehicula tempor turpis eget mollis."
                };
                member.BlogPosts.Add(post);
                context.BlogPosts.Add(post);

                post = new BlogPost
                {
                    Author = member,
                    Title = "What Instagram Ads Will Look Like",
                    ShortDescription = "Instagram offered a first glimpse at what its ads will look like in a blog post Thursday. The sample ad, which you can see below.",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed convallis ornare nisi, ultrices gravida metus pulvinar id. Maecenas at" + "nibh iaculis, finibus risus vitae, finibus augue. Pellentesque fringilla metus non dui sagittis tincidunt ac a nisi." +
                      "Ut varius odio lacus, quis feugiat ligula tincidunt ut. Sed aliquam condimentum nunc sed vehicula. Donec suscipit, " +
                      "justo sit amet iaculis mollis, lectus libero pharetra nisl, eu lobortis elit turpis efficitur ligula. Mauris commodo nisl" +
                      "vitae sem dignissim, at gravida justo rutrum. Sed interdum volutpat suscipit. In cursus, tellus ut tristique dignissim," +
                      "purus velit posuere felis, non elementum sem augue a augue." +
                      "<br />" +
                    "Vivamus risus eros, elementum quis augue vitae, sollicitudin congue nunc.Sed eros eros, dapibus ut diam non," +
                    "pretium euismod enim.In feugiat tempor consectetur.Proin viverra vel libero at facilisis.Nulla faucibus felis sem," +
                    "eu auctor lorem tincidunt sit amet.Maecenas sed semper est.Maecenas ultrices suscipit ante sit amet consequat.Curabitur" +
                    "ac tellus egestas erat dictum tincidunt.Donec imperdiet tortor et justo tincidunt vulputate.Sed placerat" +
                    "eget elit sit amet condimentum.Maecenas non blandit ex.Sed nec odio id tortor sagittis maximus vel vitae odio." +
                    "Cras vehicula tempor turpis eget mollis."
                };
                member.BlogPosts.Add(post);
                context.BlogPosts.Add(post);

                post = new BlogPost
                {
                    Author = member,
                    Title = "The Future of Magazines Is on Tablets",
                    ShortDescription = "Eric Schmidt has seen the future of magazines, and it's on the tablet. At a Magazine Publishers Association.",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed convallis ornare nisi, ultrices gravida metus pulvinar id. Maecenas at" + "nibh iaculis, finibus risus vitae, finibus augue. Pellentesque fringilla metus non dui sagittis tincidunt ac a nisi." +
                      "Ut varius odio lacus, quis feugiat ligula tincidunt ut. Sed aliquam condimentum nunc sed vehicula. Donec suscipit, " +
                      "justo sit amet iaculis mollis, lectus libero pharetra nisl, eu lobortis elit turpis efficitur ligula. Mauris commodo nisl" +
                      "vitae sem dignissim, at gravida justo rutrum. Sed interdum volutpat suscipit. In cursus, tellus ut tristique dignissim," +
                      "purus velit posuere felis, non elementum sem augue a augue." +
                      "<br />" +
                    "Vivamus risus eros, elementum quis augue vitae, sollicitudin congue nunc.Sed eros eros, dapibus ut diam non," +
                    "pretium euismod enim.In feugiat tempor consectetur.Proin viverra vel libero at facilisis.Nulla faucibus felis sem," +
                    "eu auctor lorem tincidunt sit amet.Maecenas sed semper est.Maecenas ultrices suscipit ante sit amet consequat.Curabitur" +
                    "ac tellus egestas erat dictum tincidunt.Donec imperdiet tortor et justo tincidunt vulputate.Sed placerat" +
                    "eget elit sit amet condimentum.Maecenas non blandit ex.Sed nec odio id tortor sagittis maximus vel vitae odio." +
                    "Cras vehicula tempor turpis eget mollis."
                };
                member.BlogPosts.Add(post);
                context.BlogPosts.Add(post);
                //await userManager.UpdateAsync(member);
                context.SaveChanges();
            }

            if (!context.Testimonials.Any())
            {
                //Member member = (from m in context.Members
                //                 where m.memberID == 1
                //                 select m).FirstOrDefault<Member>() as Member;

                Member member = await userManager.FindByEmailAsync("jsmith@member.com");

                Testimonial t = new Testimonial
                {
                    Title = "Best Teacher Ever",
                    Body = "Christina is the brightest youth Ballet teacher to come out of Eugene in 30 years. " +
                    "She has grace, talent, and patience. Why isn't she on broadway?",
                    Owner = member
                };
                member.Testimonials.Add(t);
                //await userManager.UpdateAsync(member);
                context.Testimonials.Add(t);

                //member = (from m in context.Members
                //          where m.memberID == 2
                //          select m).FirstOrDefault<Member>() as Member;

                member = await userManager.FindByEmailAsync("mbrown@member.com");

                t = new Testimonial
                {
                    Title = "Never going back!",
                    Body = "Christina made learning Ballet so much fun that I've decided to give up Modern Dance forever and change my name to Ballet4Life Peterson.",
                    Owner = member
                };
                member.Testimonials.Add(t);
                //await userManager.UpdateAsync(member);
                context.Testimonials.Add(t);

                //member = (from m in context.Members
                //          where m.memberID == 4
                //          select m).FirstOrDefault<Member>() as Member;

                member = await userManager.FindByEmailAsync("msanchez@member.com");

                t = new Testimonial
                {
                    Title = "Is this google?",
                    Body = "Closest place to buy pasta. Closest pasta place. Buy pasta near me. Pasta. Noodles.",
                    Owner = member
                };
                member.Testimonials.Add(t);
                //await userManager.UpdateAsync(member);
                context.Testimonials.Add(t);

                //member = (from m in context.Members
                //          where m.memberID == 5
                //          select m).FirstOrDefault<Member>() as Member;

                member = await userManager.FindByEmailAsync("ajohnson@member.com");
                t = new Testimonial
                {
                    Title = "Testimonial {4}",
                    Body = "This is a system generated testimonial for {Christina} {Lindsay}. This testimonial was generated because owner testimonial count was {3}, " +
                    "which is below the minimum required testimonials of {4}. Have a good day. {End message}.",
                    Owner = member
                };
                member.Testimonials.Add(t);
                //await userManager.UpdateAsync(member);
                context.Testimonials.Add(t);
                
                context.SaveChanges();
            }
        }
    }
}
