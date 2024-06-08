using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain ; 

namespace Api.Repositories
{
    public interface IServiceRepository
    {

        public Task <List<Service>> GetAllServices() ; 

        public Task <Service?> GetService(Guid id) ; 

        public Task <Service> AddService(Service service) ; 

        public Task <Service> UpdateService(Guid id , Service service) ; 

    }
}