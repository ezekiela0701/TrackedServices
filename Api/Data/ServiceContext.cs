namespace Api.Data ; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore ; 
using Api.Models.Domain ;


public class ServiceContext : DbContext
{
    
    public ServiceContext(DbContextOptions<ServiceContext> DbContextOption) : base(DbContextOption)
    {
        
    }

    public DbSet<Service> Services { get; set; }  

    public DbSet<Client> Clients { get; set; }  
    
    public DbSet<User> Users { get; set; }  

}
