using System;
using Microsoft.EntityFrameworkCore;
namespace webApiApp.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Case> Defendants { get; set; }

    }
}
