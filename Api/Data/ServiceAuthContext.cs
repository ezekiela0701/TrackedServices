using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore ;
using Microsoft.EntityFrameworkCore ; 
using Microsoft.AspNetCore.Identity ; 

namespace Api.Data
{
    public class ServiceAuthContext: IdentityDbContext
    {
        public ServiceAuthContext(DbContextOptions<ServiceAuthContext> options) : base(options)
        {
        } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            var readerRoleId = "a71a55d6-99d7-4123-b4e0-1218ecb90e3e" ; 
            var writerRoleId = "c309fa92-2123-47be-b397-a1c77adb502c" ;

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId ,
                    ConcurrencyStamp = readerRoleId, 
                    Name ="Reader" ,
                    NormalizedName = "Reader".ToUpper()
                } , 

                new IdentityRole
                {
                    Id = writerRoleId , 
                    ConcurrencyStamp = writerRoleId , 
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                } 

            } ;

            builder.Entity<IdentityRole>().HasData(roles) ;

        }

    }
}