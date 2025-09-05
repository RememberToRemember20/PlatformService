using PlatformService.ModelDTOs;

namespace PlatformService.SyncDataService
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommnad(PlatformReadDTO platform);
    }
}
