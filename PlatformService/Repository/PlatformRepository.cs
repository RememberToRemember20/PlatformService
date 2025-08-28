using PlatformService.DbContexts;
using PlatformService.Models;

namespace PlatformService.Repository
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly PlatformDbContext _context;

        public PlatformRepository(PlatformDbContext context)
        {
            _context = context;
        }
        public void CreatePlateform(Platform platform)
        {
            if(platform==null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            _context.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatform()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatFormById(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChange()
        {
            return(_context.SaveChanges() >= 0); ;
        }
    }
}
