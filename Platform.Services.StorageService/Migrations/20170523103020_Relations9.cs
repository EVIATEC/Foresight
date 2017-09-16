using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Platform.Services.StorageService.Migrations
{
    public partial class Relations9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentVersionId",
                table: "Files",
                newName: "FileId1");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileId1",
                table: "Files",
                column: "FileId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Files_FileId1",
                table: "Files",
                column: "FileId1",
                principalTable: "Files",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Files_FileId1",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_FileId1",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "FileId1",
                table: "Files",
                newName: "CurrentVersionId");
        }
    }
}
