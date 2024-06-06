using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore ;
using Api.Models.Domain ; 
using Api.Data ; 
using Api.Repositories ;

namespace Api.Repositories
{
    public class SqlUserRepository: IUserRepository
    {

        private readonly ServiceContext context ; 

        public SqlUserRepository(ServiceContext context)
        {

            this.context = context ;

        }
        
        public async Task<List<User>> GetAllUsers()
        {

            return await context.Users.ToListAsync(); 

        }

        public async Task<User> GetUser(Guid id)
        {

            return await context.Users.FirstOrDefaultAsync(x => x.Id == id) ; 

        }

        public async Task<User> AddUser(User user)
        {
            context.Users.AddAsync(user) ;
            await context.SaveChangesAsync() ; 

            return user ; 
        }

        public async Task<User> UpdateUser(Guid id , User user)
        {
            var userExisting = await context.Users.FirstOrDefaultAsync( x => x.Id == id) ;

            if(userExisting == null)
            {
                return null ;
            }

            userExisting.Name = user.Name ;

            await context.SaveChangesAsync() ;

            return user ;

        }

        public async Task<User> DeleteUser(Guid id)
        {
            var userExisting = await context.Users.FirstOrDefaultAsync( x => x.Id == id) ;

            if(userExisting == null)
            {
                return null ;
            }

            context.Users.Remove(userExisting) ;

            await context.SaveChangesAsync() ;

            return userExisting ; 

        }

    }
}