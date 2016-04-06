using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyllabusPortal.Models
{
    [Table("Rpuds")]
    public class rpud
    {
        [Key]
        public int id_rpud { get; set; }
        public string resourses { get; set; }
        public string assessment { get; set; }
        public string requirements { get; set; }
        
        [ForeignKey("id_classifier")]
        public virtual DbSet<classifier> classifier { get; set; }
        [ForeignKey("id_emploee")]
        public virtual DbSet<emploee> emploee { get; set; }
    }
}
