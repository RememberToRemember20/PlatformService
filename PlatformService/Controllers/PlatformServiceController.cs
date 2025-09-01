using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlatformService.DbContexts;
using PlatformService.ModelDTOs;
using PlatformService.Repository;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformServiceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepository _repository;

        public PlatformServiceController(IMapper mapper,IPlatformRepository repository)
        { 
            _mapper=mapper; 
            _repository=repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>>GetAllPlatforms()
        {
            var platforms = _repository.GetAllPlatform();
            var map=_mapper.Map<IEnumerable<PlatformReadDTO>>(platforms);
            return Ok(map);
        }
        [HttpGet("GetPlatformById/{id}")]
        public ActionResult<PlatformReadDTO>GetPlatformById(int id)
        {
            var platform = _repository.GetPlatFormById(id);
            var map = _mapper.Map<PlatformReadDTO>(platform);
            return Ok(map);
        }
        
    }
}
