using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity ; 
using Microsoft.AspNetCore.Mvc ;
using Api.Models.DTO ;
using Api.Repositories ;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager ; 
        private readonly ITokenRepository tokenRepository ;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager     = userManager ; 
            this.tokenRepository = tokenRepository ; 
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

        //api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] AuthLoginRequestDto authLoginRequestDto)
        {
            
            var user = await userManager.FindByEmailAsync(authLoginRequestDto.Username) ; 

            if(user != null)
            {

                var checkPasswordResult = await userManager.CheckPasswordAsync(user , authLoginRequestDto.Password) ;

                if(checkPasswordResult)
                {

                    var roles = await userManager.GetRolesAsync(user) ;

                    if(roles != null)
                    {
                        //create token
                        
                        var jwtToken = tokenRepository.CreateJwtToken(user , roles.ToList()) ;
                        var response = new AuthResponseDto
                        {
                            JwtToken = jwtToken
                        } ;
 
                        return Ok(response) ;

                    }

                }
                return BadRequest("Password incorrect") ;

            }
            return BadRequest("Username incorrect") ;

        }

    }
}