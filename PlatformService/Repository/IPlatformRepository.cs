using PlatformService.Models;

namespace PlatformService.Repository
{
    public interface IPlatformRepository
    {
        bool SaveChange();
        IEnumerable<Platform> GetAllPlatform();
        Platform GetPlatFormById(int id);
        void CreatePlateform(Platform platform);

    }
}
