using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CommunityWebsite.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    memberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvatarImg = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LoggedIn = table.Column<bool>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Registered = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.memberID);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    BlogPostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthormemberID = table.Column<int>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.BlogPostID);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Members_AuthormemberID",
                        column: x => x.AuthormemberID,
                        principalTable: "Members",
                        principalColumn: "memberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    messageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    From = table.Column<string>(nullable: true),
                    OwnermemberID = table.Column<int>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.messageID);
                    table.ForeignKey(
                        name: "FK_Messages_Members_OwnermemberID",
                        column: x => x.OwnermemberID,
                        principalTable: "Members",
                        principalColumn: "memberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    TestimonialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    OwnermemberID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.TestimonialID);
                    table.ForeignKey(
                        name: "FK_Testimonials_Members_OwnermemberID",
                        column: x => x.OwnermemberID,
                        principalTable: "Members",
                        principalColumn: "memberID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    replyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    From = table.Column<string>(nullable: true),
                    OwnermemberID = table.Column<int>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    messageID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.replyID);
                    table.ForeignKey(
                        name: "FK_Reply_Members_OwnermemberID",
                        column: x => x.OwnermemberID,
                        principalTable: "Members",
                        principalColumn: "memberID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reply_Messages_messageID",
                        column: x => x.messageID,
                        principalTable: "Messages",
                        principalColumn: "messageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_AuthormemberID",
                table: "BlogPosts",
                column: "AuthormemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_OwnermemberID",
                table: "Messages",
                column: "OwnermemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_OwnermemberID",
                table: "Reply",
                column: "OwnermemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_messageID",
                table: "Reply",
                column: "messageID");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_OwnermemberID",
                table: "Testimonials",
                column: "OwnermemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
