using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using WebApplication.Models;

namespace WebApplication.DataBase
{
    public class WebAppDbContext:DbContext
    {
        public WebAppDbContext():base("WebAppConnectionString")
        {

        }
      
        public DbSet<Device> Devices { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

       
    }
}