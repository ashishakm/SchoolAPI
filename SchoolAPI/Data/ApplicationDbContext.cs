using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolAPI.Model;

namespace SchoolAPI.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<RegistrationModel> Registrations { get; set; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =AKM-PC\\SQLPROD2012;Initial Catalog = SchoolAPI; Integrated Security = True;Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True;ApplicationIntent = ReadWrite; MultiSubnetFailover = False"); 
      }
    }
}
