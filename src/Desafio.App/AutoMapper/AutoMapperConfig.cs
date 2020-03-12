using AutoMapper;
using Desafio.App.ViewModels;
using Desafio.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Autor, AutorViewModel>().ReverseMap();
            CreateMap<Obra, ObraViewModel>().ReverseMap();
        }
    }
}
