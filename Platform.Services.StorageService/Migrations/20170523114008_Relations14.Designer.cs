using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Platform.Services.StorageService.Models;

namespace Platform.Services.StorageService.Migrations
{
    [DbContext(typeof(WebAPIDataContext))]
    [Migration("20170523114008_Relations14")]
    partial class Relations14
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Platform.Services.StorageService.Models.File", b =>
                {
                    b.Property<long>("FileId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CurrentVersionId");

                    b.HasKey("FileId");

                    b.HasIndex("CurrentVersionId")
                        .IsUnique();

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Platform.Services.StorageService.Models.FileVersion", b =>
                {
                    b.Property<long>("FileVersionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType");

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("Extension");

                    b.Property<long>("FileId");

                    b.Property<long>("FileSizeInBytes");

                    b.Property<string>("HashSha256");

                    b.Property<DateTimeOffset>("LastAccess");

                    b.Property<string>("OriginalFileName");

                    b.Property<long>("StorageId");

                    b.Property<string>("SubPath");

                    b.Property<string>("VersionComment");

                    b.Property<string>("VersionNumber");

                    b.HasKey("FileVersionId");

                    b.HasIndex("FileId");

                    b.ToTable("FileVersions");
                });

            modelBuilder.Entity("Platform.Services.StorageService.Models.Storage", b =>
                {
                    b.Property<long>("StorageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("StorageId");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("Platform.Services.StorageService.Models.StorageSettingFilesystem", b =>
                {
                    b.Property<long>("StorageSettingFilesystemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BasePath")
                        .IsRequired();

                    b.Property<long>("MaxElements");

                    b.Property<long>("StorageId");

                    b.HasKey("StorageSettingFilesystemId");

                    b.HasIndex("StorageId");

                    b.ToTable("StoragesSettingsFilesystem");
                });

            modelBuilder.Entity("Platform.Services.StorageService.Models.File", b =>
                {
                    b.HasOne("Platform.Services.StorageService.Models.FileVersion", "CurrentVersion")
                        .WithOne("CurrentFileLink")
                        .HasForeignKey("Platform.Services.StorageService.Models.File", "CurrentVersionId");
                });

            modelBuilder.Entity("Platform.Services.StorageService.Models.FileVersion", b =>
                {
                    b.HasOne("Platform.Services.StorageService.Models.File", "File")
                        .WithMany("FileVersions")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Platform.Services.StorageService.Models.StorageSettingFilesystem", b =>
                {
                    b.HasOne("Platform.Services.StorageService.Models.Storage", "Storage")
                        .WithMany()
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
