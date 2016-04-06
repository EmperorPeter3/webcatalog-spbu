using Microsoft.Data.Entity;
using Microsoft.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyllabusPortal.Models
{
    public class rpudContext : DbContext
    {
        //public rpudContext(): base("context") { }
        public DbSet<rpud> rpuds { get; set; }

        protected override void OnConfiguring(EntityOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["rpudContext"].ToString());
        }
    }
}
