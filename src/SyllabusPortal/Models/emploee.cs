using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyllabusPortal.Models
{
    [Table("Emploees")]
    public class emploee
    {
        [Key]
        public int id_emploee { get; set; }
        public string role_emploee { get; set; }
        public string name_emploee { get; set; }
    }
}
