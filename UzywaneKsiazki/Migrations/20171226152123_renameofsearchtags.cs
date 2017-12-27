using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UzywaneKsiazki.Migrations
{
    public partial class renameofsearchtags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SearchTags",
                table: "Posts",
                newName: "TitleQuery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TitleQuery",
                table: "Posts",
                newName: "SearchTags");
        }
    }
}
