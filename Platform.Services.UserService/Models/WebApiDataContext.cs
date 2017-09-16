using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Services.UserService.Models
{
    public class WebApiDataContext : DbContext
    {
        public WebApiDataContext(DbContextOptions<WebApiDataContext> options)
            : base(options)
        {
        }

    }
}
