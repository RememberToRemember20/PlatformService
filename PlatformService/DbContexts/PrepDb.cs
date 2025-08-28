using PlatformService.Models;

namespace PlatformService.DbContexts
{
    public static class PrepDb
    {
        public static void Prepopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<PlatformDbContext>());    
            }
        }
        private static void SeedData(PlatformDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> sedding data");
                context.Platforms.AddRange(
                    new Platform() { Name="windows",Publisher="microsotft",Cost=0},
                    new Platform() { Name="excel",Publisher="microsoft",Cost=0},
                    new Platform() { Name="geminai",Publisher="googl",Cost=25}
                    );
                context.SaveChanges();   
            }
            else {
                Console.WriteLine("--> we already have data ");
            }
        }
    }
}
