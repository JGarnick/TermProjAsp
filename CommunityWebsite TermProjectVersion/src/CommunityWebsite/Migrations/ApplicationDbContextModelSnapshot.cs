using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CommunityWebsite.Repositories;

namespace CommunityWebsite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommunityWebsite.Models.BlogPost", b =>
                {
                    b.Property<int>("BlogPostID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthormemberID");

                    b.Property<string>("Body");

                    b.Property<string>("Category");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Title");

                    b.Property<string>("URL");

                    b.HasKey("BlogPostID");

                    b.HasIndex("AuthormemberID");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Member", b =>
                {
                    b.Property<int>("memberID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AvatarImg");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LoggedIn");

                    b.Property<string>("Phone");

                    b.Property<DateTime>("Registered");

                    b.HasKey("memberID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Message", b =>
                {
                    b.Property<int>("messageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("Date");

                    b.Property<string>("From");

                    b.Property<int?>("OwnermemberID");

                    b.Property<string>("Subject");

                    b.Property<string>("Topic");

                    b.HasKey("messageID");

                    b.HasIndex("OwnermemberID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Reply", b =>
                {
                    b.Property<int>("replyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("Date");

                    b.Property<string>("From");

                    b.Property<int?>("OwnermemberID");

                    b.Property<string>("Subject");

                    b.Property<string>("Topic");

                    b.Property<int?>("messageID");

                    b.HasKey("replyID");

                    b.HasIndex("OwnermemberID");

                    b.HasIndex("messageID");

                    b.ToTable("Reply");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Testimonial", b =>
                {
                    b.Property<int>("TestimonialID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<int?>("OwnermemberID");

                    b.Property<string>("Title");

                    b.HasKey("TestimonialID");

                    b.HasIndex("OwnermemberID");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("CommunityWebsite.Models.BlogPost", b =>
                {
                    b.HasOne("CommunityWebsite.Models.Member", "Author")
                        .WithMany("BlogPosts")
                        .HasForeignKey("AuthormemberID");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Message", b =>
                {
                    b.HasOne("CommunityWebsite.Models.Member", "Owner")
                        .WithMany("Messages")
                        .HasForeignKey("OwnermemberID");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Reply", b =>
                {
                    b.HasOne("CommunityWebsite.Models.Member", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnermemberID");

                    b.HasOne("CommunityWebsite.Models.Message")
                        .WithMany("Replies")
                        .HasForeignKey("messageID");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Testimonial", b =>
                {
                    b.HasOne("CommunityWebsite.Models.Member", "Owner")
                        .WithMany("Testimonials")
                        .HasForeignKey("OwnermemberID");
                });
        }
    }
}
