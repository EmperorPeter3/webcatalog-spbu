using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyllabusPortal.Models
{
    public class emploeeContext : DbContext
    {
        public DbSet<emploee> emploees { get; set; }

        protected override void OnConfiguring(EntityOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["emploeeContext"].ToString());
        }
    }
}
