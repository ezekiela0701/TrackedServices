using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain ; 

namespace Api.Models.DTO
{
    public class ServiceDto
    {
        public Guid Id { get; set; }
    
        public string Name { get; set; }

        public int Price { get; set; }

        public Guid IdClient { get; set; }

        public Guid IdUser { get; set; }

        //navigation properties

        public Client Client { get; set; }

        public User User { get; set; }
    }
}