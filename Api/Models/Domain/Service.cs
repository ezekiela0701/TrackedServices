namespace Api.Models.Domain ; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Domain ; 


public class Service
{

    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public int Price { get; set; }

    public Guid ClientId { get; set; }

    public Guid UserId { get; set; }

    //navigation properties

    public Client Client { get; set; }

    public User User { get; set; }

}