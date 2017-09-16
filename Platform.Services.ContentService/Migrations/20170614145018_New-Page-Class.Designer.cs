using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Platform.Services.ContentService.Models;

namespace Platform.Services.ContentService.Migrations
{
    [DbContext(typeof(WebAPIDataContext))]
    [Migration("20170614145018_New-Page-Class")]
    partial class NewPageClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Platform.Services.ContentService.Models.Form", b =>
                {
                    b.Property<long>("FormId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApiUrl");

                    b.Property<string>("FormDefinition");

                    b.Property<string>("FormName");

                    b.HasKey("FormId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("Platform.Services.ContentService.Models.Page", b =>
                {
                    b.Property<long>("PageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PageElements");

                    b.Property<string>("PageName");

                    b.HasKey("PageId");

                    b.ToTable("Pages");
                });
        }
    }
}
