using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UzywaneKsiazki.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adress = table.Column<string>(nullable: true),
                    AuthorName = table.Column<string>(nullable: true),
                    BookAuthor = table.Column<string>(nullable: true),
                    DateOfPosting = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhotosDb = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PublishDate = table.Column<string>(nullable: true),
                    SearchTags = table.Column<string>(nullable: true),
                    StateOfBook = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
