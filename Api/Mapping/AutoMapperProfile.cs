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
        public AutoMapperProfile()
        {
            
            //mapping client 
            CreateMap<Client , ClientDto>().ReverseMap() ;

            CreateMap<ClientAddRequestDto , Client>().ReverseMap() ;

            CreateMap<Client , ClientAddRequestDto>().ReverseMap() ;

            CreateMap<ClientUpdateRequestDto , Client>().ReverseMap() ;

            //mapping user 
            CreateMap<User , UserDto>().ReverseMap() ;

            CreateMap<UserAddRequestDto , User>().ReverseMap() ;

        }
    }
}