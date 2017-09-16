using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Platform.Services.StorageService.Migrations
{
    public partial class Relations4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileVersions_Storages_StorageId",
                table: "FileVersions");

            migrationBuilder.DropIndex(
                name: "IX_FileVersions_StorageId",
                table: "FileVersions");

            migrationBuilder.AlterColumn<long>(
                name: "StorageId",
                table: "FileVersions",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "StorageId",
                table: "FileVersions",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_FileVersions_StorageId",
                table: "FileVersions",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileVersions_Storages_StorageId",
                table: "FileVersions",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "StorageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
