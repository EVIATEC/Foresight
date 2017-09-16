using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Platform.Services.System.AppManager.Models;

namespace Platform.Services.EventService.Migrations
{
    [DbContext(typeof(WebAPIDataContext))]
    [Migration("20170602071304_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Platform.Services.EventService.Models.Download", b =>
                {
                    b.Property<int>("DownloadId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EventId");

                    b.Property<string>("Name");

                    b.Property<long>("StorageServiceFileId");

                    b.HasKey("DownloadId");

                    b.HasIndex("EventId");

                    b.ToTable("Downloads");
                });

            modelBuilder.Entity("Platform.Services.EventService.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescriptionLong");

                    b.Property<string>("DescriptionShort");

                    b.Property<DateTimeOffset>("EventDate");

                    b.Property<string>("EventName");

                    b.Property<string>("Location");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Platform.Services.EventService.Models.Registration", b =>
                {
                    b.Property<int>("RegistrationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("EMail");

                    b.Property<int>("EventId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<string>("Salutation");

                    b.Property<string>("Street");

                    b.Property<string>("Title");

                    b.Property<string>("Zipcode");

                    b.HasKey("RegistrationId");

                    b.HasIndex("EventId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("Platform.Services.EventService.Models.Download", b =>
                {
                    b.HasOne("Platform.Services.EventService.Models.Event", "Event")
                        .WithMany("Downloads")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Platform.Services.EventService.Models.Registration", b =>
                {
                    b.HasOne("Platform.Services.EventService.Models.Event", "Event")
                        .WithMany("Registrations")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
