using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.DbContexts
{
    public class PlatformDbContext:DbContext
    {
        public PlatformDbContext(DbContextOptions<PlatformDbContext>opt):base(opt)
        {
            
        }
        public DbSet<Platform> Platforms { get; set; }
    }
}
