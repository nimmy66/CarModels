using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace CarModels.Models
{
    public class ApplicationDbContext:DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
       {
           
       }
       public DbSet<Car> Cars { get; set; }
    }
}
