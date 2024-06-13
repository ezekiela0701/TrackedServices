using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repositories ;
using Microsoft.AspNetCore.Identity ;
using System.Security.Claims ; 
using System.Text ; 
using Microsoft.AspNetCore.Authentication.JwtBearer ; 
using Microsoft.IdentityModel.Tokens ; 
using System.IdentityModel.Tokens.Jwt ;

namespace Api.Repositories
{
    public class TokenRepository :ITokenRepository
    {
        public readonly IConfiguration configuration ;

        public TokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration ;
        }

        public string CreateJwtToken(IdentityUser user , List<string> roles)  
        {
            //creating claims
            var claims = new List<Claim>() ;

            claims.Add(new Claim(ClaimTypes.Email , user.Email)) ;

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role , role)) ;
            }

            var key         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])) ;
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256) ;

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(45),
                signingCredentials:credentials
            ) ;

            var tokenReturn = new JwtSecurityTokenHandler().WriteToken(token) ;

            return tokenReturn ; 

        }

    }
}