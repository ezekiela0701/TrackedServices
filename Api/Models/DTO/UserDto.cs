using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}