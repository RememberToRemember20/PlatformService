using AutoMapper;
using PlatformService.ModelDTOs;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatformProfiles:Profile
    {
        public PlatformProfiles()
        {
            CreateMap<Platform,PlatformReadDTO>();
            CreateMap<PlatformCreateDTO, Platform>();
        }
    }
}
