using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Platform.Api.System.AppManager.Models;

namespace Platform.Api.System.AppManager.Migrations
{
    [DbContext(typeof(WebAPIDataContext))]
    [Migration("20170419151035_INITIAL")]
    partial class INITIAL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("Platform.Api.System.AppManager.Models.App", b =>
                {
                    b.Property<int>("AppId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FormatedDate");

                    b.Property<string>("Name");

                    b.HasKey("AppId");

                    b.ToTable("Apps");
                });
        }
    }
}
