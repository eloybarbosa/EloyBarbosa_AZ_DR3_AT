﻿using AutoMapper;
using WebApiAmigo.Resources.AmigoResource;

namespace WebApiAmigo.AutomapperProfiles
{
    public class PaisProfile : Profile
    {
        public PaisProfile()
        {
            CreateMap<Pais, PaisResponse>();
            CreateMap<PaisRequest, Pais>();
        }
    }
}
