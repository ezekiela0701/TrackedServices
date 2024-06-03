namespace Api.Models.Domain ; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Service
{

    public Guid Id { get; set; }
    
    public string Name { get; set; }

    private int Price { get; set; }

}