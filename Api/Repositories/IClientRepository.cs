namespace Api.Repositories ;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain ;


public interface IClientRepository
{

    public Task<List<Client>> GetAllClient() ;

}
