using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Repositories ; 
using Api.Data ; 
using Api.Models.Domain ; 
using Api.Models.DTO ; 
using Api.Mapping ; 
using AutoMapper ; 

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ServiceContext context ; 
        private readonly IMapper mapper ; 
        private readonly IUserRepository userRepository ; 

        public UserController(ServiceContext context , IUserRepository userRepository , IMapper mapper)
        {

            this.mapper         = mapper ; 
            this.context        = context ; 
            this.userRepository = userRepository ; 

        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            if(context.Users == null ){

                return NotFound() ;

            }

            var userDomainModels = await userRepository.GetAllUsers() ; 

            var usersDto = mapper.Map<List<UserDto>>(userDomainModels) ; 

            return Ok(usersDto) ;

        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            if(context.Users == null)
            {
                return NotFound() ;
            }

            var user = await userRepository.GetUser(id) ;

            if(user == null )
            {
                return NotFound() ;
            }

            return Ok(user) ;

        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserAddRequestDto userAddRequestDto)
        {
            var userDomainModel = mapper.Map<User>(userAddRequestDto) ; 
            await userRepository.AddUser(userDomainModel) ; 

            var clientDto = mapper.Map<UserDto>(userDomainModel) ;

            return Ok(clientDto); 

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}