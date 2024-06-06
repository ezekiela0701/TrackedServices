using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain ; 

namespace Api.Repositories
{
    public interface IserviceRepository
    {

        public Task <List<Service>> GetAllServices() ; 

    }
}