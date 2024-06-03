namespace Api.Models.Domain ; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain ;


public class User
{
    
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid IdService { get; set; }

    //navigation properties

    public Service Service { get; set; }

}
