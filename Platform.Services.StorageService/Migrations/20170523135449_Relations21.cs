using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Platform.Services.StorageService.Migrations
{
    public partial class Relations21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileVersions_CurentVersionId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CurentVersionId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CurentVersionId",
                table: "Files");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileVersions_CurrentVersionId",
                table: "Files",
                column: "CurrentVersionId",
                principalTable: "FileVersions",
                principalColumn: "FileVersionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileVersions_CurrentVersionId",
                table: "Files");

            migrationBuilder.AddColumn<long>(
                name: "CurentVersionId",
                table: "Files",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_CurentVersionId",
                table: "Files",
                column: "CurentVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileVersions_CurentVersionId",
                table: "Files",
                column: "CurentVersionId",
                principalTable: "FileVersions",
                principalColumn: "FileVersionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
