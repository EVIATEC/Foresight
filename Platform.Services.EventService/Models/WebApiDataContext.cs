using Microsoft.EntityFrameworkCore;
using Platform.Services.EventService.Models;

namespace Platform.Services.System.AppManager.Models
{
    public class WebAPIDataContext : DbContext
    {
        public WebAPIDataContext(DbContextOptions<WebAPIDataContext> options)
            : base(options)
        {
        }

        public DbSet<Registration> Registrations { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Download> Downloads { get; set; }
    }
}
