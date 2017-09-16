using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Platform.Services.StorageService.Migrations
{
    public partial class Relations12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileVersions_CurrentVersionFileVersionId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_FileVersions_Files_FileId",
                table: "FileVersions");

            migrationBuilder.DropIndex(
                name: "IX_FileVersions_FileId",
                table: "FileVersions");

            migrationBuilder.DropIndex(
                name: "IX_Files_CurrentVersionFileVersionId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "CurrentVersionFileVersionId",
                table: "Files",
                newName: "CurrentVersionId");

            migrationBuilder.AlterColumn<long>(
                name: "FileId",
                table: "FileVersions",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_CurrentVersionId",
                table: "Files",
                column: "CurrentVersionId",
                unique: true);

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

            migrationBuilder.DropIndex(
                name: "IX_Files_CurrentVersionId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "CurrentVersionId",
                table: "Files",
                newName: "CurrentVersionFileVersionId");

            migrationBuilder.AlterColumn<long>(
                name: "FileId",
                table: "FileVersions",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_FileVersions_FileId",
                table: "FileVersions",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CurrentVersionFileVersionId",
                table: "Files",
                column: "CurrentVersionFileVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileVersions_CurrentVersionFileVersionId",
                table: "Files",
                column: "CurrentVersionFileVersionId",
                principalTable: "FileVersions",
                principalColumn: "FileVersionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileVersions_Files_FileId",
                table: "FileVersions",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
