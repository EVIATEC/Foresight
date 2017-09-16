using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Platform.Services.StorageService.Models
{
    public class WebAPIDataContext : DbContext
    {
        public WebAPIDataContext(DbContextOptions<WebAPIDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // create an unique index
            modelBuilder.Entity<File>()
                .HasIndex(b => b.CurrentVersionId)
                .IsUnique(true);

            // one to many relationship between file and version
            modelBuilder.Entity<FileVersion>()
                .HasOne(v => v.File)
                .WithMany(f => f.FileVersions)
                .HasForeignKey(v => v.FileId);
        }

        public DbSet<Storage> Storages { get; set; }

        public DbSet<StorageSettingFilesystem> StoragesSettingsFilesystem { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<FileVersion> FileVersions { get; set; }



    }
}
