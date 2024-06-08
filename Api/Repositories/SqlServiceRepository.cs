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

        public async Task<Service> AddService(Service service)
        {
            
            context.Services.AddAsync(service) ; 
            await context.SaveChangesAsync() ; 

            return service ; 

        }

        public async Task<Service> UpdateService(Guid id , Service service)
        {

            var serviceExisting = await context.Services.FirstOrDefaultAsync(x => x.Id == id) ; 

            if(serviceExisting == null)
            {
                return null ; 
            }

            serviceExisting.Name        = service.Name ; 
            serviceExisting.Price       = service.Price ; 
            serviceExisting.ClientId    = service.ClientId ; 
            serviceExisting.UserId      = service.UserId ; 

            
            await context.SaveChangesAsync() ; 

            return serviceExisting ; 

        }

    }
}