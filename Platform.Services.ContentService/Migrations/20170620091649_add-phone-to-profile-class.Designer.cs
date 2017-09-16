using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Platform.Services.ContentService.Models;

namespace Platform.Services.ContentService.Migrations
{
    [DbContext(typeof(WebAPIDataContext))]
    [Migration("20170620091649_add-phone-to-profile-class")]
    partial class addphonetoprofileclass
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

            modelBuilder.Entity("Platform.Services.ContentService.Models.Profile", b =>
                {
                    b.Property<long>("ProfileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Department");

                    b.Property<string>("EMail");

                    b.Property<string>("FirstName");

                    b.Property<string>("JobTitle");

                    b.Property<string>("LastName");

                    b.Property<string>("MobilePhone");

                    b.Property<string>("Occupation");

                    b.Property<string>("Room");

                    b.Property<string>("Supervisor");

                    b.Property<string>("phone");

                    b.HasKey("ProfileId");

                    b.ToTable("Profiles");
                });
        }
    }
}
