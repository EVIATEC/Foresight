using Microsoft.EntityFrameworkCore;

namespace Platform.Api.System.AppManager.Models
{
    public class WebAPIDataContext : DbContext
    {
        public WebAPIDataContext(DbContextOptions<WebAPIDataContext> options)
            : base(options)
        {
        }

        public DbSet<App> Apps { get; set; }
    }
}
