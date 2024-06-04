
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore ;
using Api.Data ;
using Api.Models.Domain ; 


namespace Api.Repositories {

    public class SqlClientRepository: IClientRepository
    {
        
        private readonly ServiceContext context;

        public SqlClientRepository(ServiceContext context)
        {
            this.context = context;
        }

        public async Task<List<Client>> GetAllClient(){

            return await context.Clients.ToListAsync(); 

        }
        public async Task <Client> GetClientById(Guid id){

            return await context.Clients.FirstOrDefaultAsync(x => x.Id == id); 

        }

    }

}
