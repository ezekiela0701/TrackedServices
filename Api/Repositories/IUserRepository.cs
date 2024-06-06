using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain ; 


namespace Api.Repositories
{
    public interface IUserRepository
    {

        public Task<List<User>> GetAllUsers() ;

        public Task<User?> GetUser(Guid id) ;

        public Task<User> AddUser (User user) ;

        public Task<User> UpdateUser (Guid id , User user) ;

        public Task<User> DeleteUser (Guid id ) ;
    
    }
}