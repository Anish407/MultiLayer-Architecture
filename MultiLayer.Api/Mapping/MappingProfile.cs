using AutoMapper;
using MultiLayer.Api.Resources;
using MultiLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiLayer.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Music, MusicResource>();
            CreateMap<Artist, ArtistResource>();

            // Resource to Domain`c     
            CreateMap<MusicResource, Music>();
            CreateMap<ArtistResource, Artist>();
        }
    }
}
