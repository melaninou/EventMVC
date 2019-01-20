using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class eventmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ID = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Organizer = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EventImage = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    ProfileImage = table.Column<string>(nullable: true),
                    AboutText = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CommentsProfile",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ID = table.Column<string>(nullable: false),
                    CommentAddTime = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserPicture = table.Column<string>(nullable: true),
                    CommentText = table.Column<string>(nullable: true),
                    ProfileID = table.Column<string>(nullable: true),
                    ProfilesID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsProfile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentsProfile_Profiles_ProfilesID",
                        column: x => x.ProfilesID,
                        principalTable: "Profiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventProfile",
                columns: table => new
                {
                    ProfileID = table.Column<string>(nullable: false),
                    EventID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventProfile", x => new { x.EventID, x.ProfileID });
                    table.ForeignKey(
                        name: "FK_EventProfile_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventProfile_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Followings",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    FollowedUserID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Followings", x => new { x.UserID, x.FollowedUserID });
                    table.ForeignKey(
                        name: "FK_Followings_Profiles_FollowedUserID",
                        column: x => x.FollowedUserID,
                        principalTable: "Profiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Followings_Profiles_UserID",
                        column: x => x.UserID,
                        principalTable: "Profiles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    EventID = table.Column<string>(nullable: false),
                    CommentID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => new { x.EventID, x.CommentID });
                    table.ForeignKey(
                        name: "FK_Comment_CommentsProfile_CommentID",
                        column: x => x.CommentID,
                        principalTable: "CommentsProfile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentID",
                table: "Comment",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentsProfile_ProfilesID",
                table: "CommentsProfile",
                column: "ProfilesID");

            migrationBuilder.CreateIndex(
                name: "IX_EventProfile_ProfileID",
                table: "EventProfile",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Followings_FollowedUserID",
                table: "Followings",
                column: "FollowedUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "EventProfile");

            migrationBuilder.DropTable(
                name: "Followings");

            migrationBuilder.DropTable(
                name: "CommentsProfile");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
