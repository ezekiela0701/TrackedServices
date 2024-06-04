namespace Api.Repositories ;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain ;


public interface IClientRepository
{

    public Task<List<Client>> GetAllClient() ;
    
    public Task <Client?> GetClientById(Guid Id) ;

    public Task <Client> AddClient(Client client) ;

    public Task <Client?> UpdateClient(Guid id , Client client) ;

    public Task <Client?> DeleteClient(Guid id) ;

}
