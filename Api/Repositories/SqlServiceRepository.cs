using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repositories ; 
using Api.Data ;
using Api.Models.Domain ; 

namespace Api.Repositories
{
    public class SqlServiceRepository : IserviceRepository
    {

        public readonly ServiceContext context ; 

        public SqlServiceRepository(ServiceContext context)
        {

            this.context = context ;

        }

        public async Task<List<User>> GetAllServices()
        {

            return await this.context.Services.ToListAsync() ; 

        }

    }
}