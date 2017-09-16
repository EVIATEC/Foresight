using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Platform.Services.StorageService.Migrations
{
    public partial class Relations10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Files_FileId1",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_FileVersions_FileId",
                table: "FileVersions");

            migrationBuilder.RenameColumn(
                name: "FileId1",
                table: "Files",
                newName: "CurrentVersionFileVersionId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_FileId1",
                table: "Files",
                newName: "IX_Files_CurrentVersionFileVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_FileVersions_FileId",
                table: "FileVersions",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileVersions_CurrentVersionFileVersionId",
                table: "Files",
                column: "CurrentVersionFileVersionId",
                principalTable: "FileVersions",
                principalColumn: "FileVersionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileVersions_CurrentVersionFileVersionId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_FileVersions_FileId",
                table: "FileVersions");

            migrationBuilder.RenameColumn(
                name: "CurrentVersionFileVersionId",
                table: "Files",
                newName: "FileId1");

            migrationBuilder.RenameIndex(
                name: "IX_Files_CurrentVersionFileVersionId",
                table: "Files",
                newName: "IX_Files_FileId1");

            migrationBuilder.CreateIndex(
                name: "IX_FileVersions_FileId",
                table: "FileVersions",
                column: "FileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Files_FileId1",
                table: "Files",
                column: "FileId1",
                principalTable: "Files",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
