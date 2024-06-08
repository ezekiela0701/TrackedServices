using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.DTO
{
    public class ServiceUpdateRequestDto
    {

        public string Name { get; set; }

        public int Price { get; set; }

        public Guid ClientId { get; set; }

        public Guid UserId { get; set; }

    }
}