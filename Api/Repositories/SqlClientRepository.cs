
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

        public async Task <Client> AddClient(Client client){

            context.Clients.AddAsync(client);
            await context.SaveChangesAsync() ;
            return client ; 

        }

        public async Task <Client> UpdateClient(Guid id , Client client){

            var clientExisting = await context.Clients.FirstOrDefaultAsync(x => x.Id == id);

            if(clientExisting == null){
                return null ; 
            }
            
            clientExisting.Name = client.Name ; 

            await context.SaveChangesAsync() ;

            return clientExisting ; 

        }

        public async Task <Client> DeleteClient(Guid id ){

            var clientExisting = await context.Clients.FirstOrDefaultAsync(x => x.Id == id);

            if(clientExisting == null){
                return null ; 
            }

            context.Clients.Remove(clientExisting) ;

            await context.SaveChangesAsync() ;

            return clientExisting ; 

        }

    }

}
