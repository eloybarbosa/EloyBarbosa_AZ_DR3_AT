using AutoMapper;
using Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiAmigo.Resources.AmigoResource;

namespace WebApiAmigo.AutomapperProfiles
{
    public class AmigoProfile : Profile

    {
        public AmigoProfile()
        {
            CreateMap<AmigoRequest, Amigo>()
                .ForMember(
                    dest => dest.Foto,
                    opt => opt.MapFrom(src => src.UrllFoto)
            );
            CreateMap<Amigo, AmigoResponse>();
        }

    }
}
