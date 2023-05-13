using Microsoft.EntityFrameworkCore;
using DemoAPI.Models.Domain;
using Microsoft.Identity.Client;

namespace DemoAPI.Data
{
    public class NzWalksDbContext : DbContext
    {
        public NzWalksDbContext( DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
    }
}
