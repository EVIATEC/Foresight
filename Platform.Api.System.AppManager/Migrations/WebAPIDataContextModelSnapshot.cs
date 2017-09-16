using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Platform.Api.System.AppManager.Models;

namespace Platform.Api.System.AppManager.Migrations
{
    [DbContext(typeof(WebAPIDataContext))]
    partial class WebAPIDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
