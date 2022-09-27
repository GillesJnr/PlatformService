using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Dtos;
using PlatformService.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // GET: /<controller>/
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            var platformItems = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platformItem = _repository.GetPlatformById(id);
            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<PlatformWriteDto> CreatePlatform(PlatformWriteDto platform)
        {
            if (ModelState.IsValid)
            {
                var platformItem = _mapper.Map<Platform>(platform);
                _repository.CreatePlatform(platformItem);
                _repository.SaveChanges();
                 
                var platformReadItem = _mapper.Map<PlatformReadDto>(platformItem);
                return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformItem.Id }, platformReadItem);
            }

            return BadRequest();
        }
        
    }
}
