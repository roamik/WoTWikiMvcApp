using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyNewWebApp.Models
{
    public class TankContext : DbContext
    {
        public DbSet<Tank> Tanks { get; set; }
    }
}