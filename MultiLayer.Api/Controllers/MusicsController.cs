using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiLayer.Api.Resources;
using MultiLayer.Core.Models;
using MultiLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiLayer.Api.Controllers
{
    [Route("/api/Music")]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;

        public MusicsController(IMusicService musicService, IMapper mapper)
        {
            this._mapper = mapper;
            this._musicService = musicService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<MusicResource>>> Get()
        {
            try
            {
                var musics = await _musicService.GetAllWithArtist();
                var musicResources = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicResource>>(musics);

                return Ok(musicResources);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message= ex.Message});
            }
           
        }

        
    }
}
