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

                    b.Property<string>("AuthorId");

                    b.Property<string>("Body");

                    b.Property<string>("Category");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Title");

                    b.Property<string>("URL");

                    b.HasKey("BlogPostID");

                    b.HasIndex("AuthorId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Member", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("AvatarImg");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("Password");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime>("Registered");

                    b.Property<string>("Role");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Message", b =>
                {
                    b.Property<int>("messageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<DateTime>("Date");

                    b.Property<string>("From");

                    b.Property<string>("OwnerId");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 25);

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 25);

                    b.HasKey("messageID");

                    b.HasIndex("OwnerId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Reply", b =>
                {
                    b.Property<int>("replyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<DateTime>("Date");

                    b.Property<string>("From");

                    b.Property<string>("OwnerId");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Topic");

                    b.Property<int?>("messageID");

                    b.HasKey("replyID");

                    b.HasIndex("OwnerId");

                    b.HasIndex("messageID");

                    b.ToTable("Reply");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Testimonial", b =>
                {
                    b.Property<int>("TestimonialID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("OwnerId");

                    b.Property<string>("Title");

                    b.HasKey("TestimonialID");

                    b.HasIndex("OwnerId");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("CommunityWebsite.Models.BlogPost", b =>
                {
                    b.HasOne("CommunityWebsite.Models.Member", "Author")
                        .WithMany("BlogPosts")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Message", b =>
                {
                    b.HasOne("CommunityWebsite.Models.Member", "Owner")
                        .WithMany("Messages")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Reply", b =>
                {
                    b.HasOne("CommunityWebsite.Models.Member", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("CommunityWebsite.Models.Message")
                        .WithMany("Replies")
                        .HasForeignKey("messageID");
                });

            modelBuilder.Entity("CommunityWebsite.Models.Testimonial", b =>
                {
                    b.HasOne("CommunityWebsite.Models.Member", "Owner")
                        .WithMany("Testimonials")
                        .HasForeignKey("OwnerId");
                });
        }
    }
}
