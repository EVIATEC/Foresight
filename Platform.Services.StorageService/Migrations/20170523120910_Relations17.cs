using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Platform.Services.StorageService.Migrations
{
    public partial class Relations17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileVersions_CurrentVersionId",
                table: "Files");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileVersions_CurrentVersionId",
                table: "Files",
                column: "CurrentVersionId",
                principalTable: "FileVersions",
                principalColumn: "FileVersionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
