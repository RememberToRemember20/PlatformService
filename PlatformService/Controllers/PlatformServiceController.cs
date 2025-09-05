using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.DbContexts;
using PlatformService.ModelDTOs;
using PlatformService.Models;
using PlatformService.Repository;
using PlatformService.SyncDataService;
using System.Threading.Tasks;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformServiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepository _repository;
        private readonly ICommandDataClient _client;

        public PlatformServiceController(IMapper mapper,IPlatformRepository repository,ICommandDataClient client)
        { 
            _mapper=mapper; 
            _repository=repository;
            _client=client;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>>GetAllPlatforms()
        {
            var platforms = _repository.GetAllPlatform();
            var map=_mapper.Map<IEnumerable<PlatformReadDTO>>(platforms);
            return Ok(map);
        }
        [HttpGet("{id}",Name = "GetPlatformById")]
        public ActionResult<PlatformReadDTO>GetPlatformById(int id)
        {
            var platform = _repository.GetPlatFormById(id);
            var map = _mapper.Map<PlatformReadDTO>(platform);
            return Ok(map);
        }
        [HttpPost]
        public async Task<ActionResult<PlatformReadDTO>> CreatePlatform(PlatformCreateDTO platform)
        {
            var plat = _mapper.Map<Platform>(platform);
            _repository.CreatePlateform(plat);
            _repository.SaveChange();
            var platformred = _mapper.Map<PlatformReadDTO>(plat);
            try
            {
               await _client.SendPlatformToCommnad(platformred);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"-->Could not send synchronously:{ex.Message}");
            }
            return CreatedAtRoute(nameof(GetPlatformById),new {Id=platformred.Id},platformred);
        }        
    }
}
