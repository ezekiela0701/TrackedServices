using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper ; 
using Api.Models.Domain ; 
using Api.Models.DTO ; 

namespace Api.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){

            CreateMap<Client , ClientDto>().ReverseMap() ;

        }
    }
}