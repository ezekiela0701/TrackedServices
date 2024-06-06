using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore ;
using Api.Repositories ; 
using Api.Data ;
using Api.Models.Domain ; 

namespace Api.Repositories
{
    public class SqlServiceRepository : IServiceRepository
    {

        public readonly ServiceContext context ; 

        public SqlServiceRepository(ServiceContext context)
        {

            this.context = context ;

        }

        public async Task<List<Service>> GetAllServices()
        {

            return await this.context.Services.ToListAsync() ; 

        }

        public async Task<Service> GetService(Guid id)
        {
            return await this.context.Services.FindAsync(id) ; 
        }

    }
}