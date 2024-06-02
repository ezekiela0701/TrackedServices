using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Data ; 

public class ServiceContext : DbContext
{
    
    public TodoContext(DbContextOptions DbContextOptions) : base(DbContextOptions)
    {
        
    }

    public DbSet<Service> Services { get; set; }  ; 

}
