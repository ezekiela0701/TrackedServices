using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity ; 
using Microsoft.AspNetCore.Mvc ;
using Api.Models.DTO ;

namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager ; 
        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager ; 
        }

        // POST : /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] AuthAddRequestDto AuthAddRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = AuthAddRequestDto.Username , 
                Email = AuthAddRequestDto.Username
            } ; 

            var identityResult = await userManager.CreateAsync(identityUser , AuthAddRequestDto.Password) ;

            if(identityResult.Succeeded)
            {

                //Adding roles to the User
                if(AuthAddRequestDto.Roles != null && AuthAddRequestDto.Roles.Any())
                {

                    await userManager.AddToRolesAsync(identityUser, AuthAddRequestDto.Roles) ;

                    if(identityResult.Succeeded)
                    {
                        return Ok("user register , you can login now.") ; 
                    }

                }

            }

            return BadRequest("Something went wrong") ;

        }

    }
}