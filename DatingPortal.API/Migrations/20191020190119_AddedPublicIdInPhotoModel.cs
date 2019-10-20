﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingPortal.Migrations
{
    public partial class AddedPublicIdInPhotoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "public_id",
                table: "Photos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "public_id",
                table: "Photos");
        }
    }
}
