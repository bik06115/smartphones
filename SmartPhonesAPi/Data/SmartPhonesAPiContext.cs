using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmartPhonesAPi.Models
{
    public class SmartPhonesAPiContext : DbContext
    {
        public SmartPhonesAPiContext (DbContextOptions<SmartPhonesAPiContext> options)
            : base(options)
        {
        }

        public DbSet<SmartPhonesAPi.Models.Phone> Phone { get; set; }
    }
}
