using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyllabusPortal.Models
{
    [Table("Classifiers")]
    public class classifier
    {
        [Key]
        public int id_classifier { get; set; }
        public string number { get; set; }
        public string nameInRus { get; set; }
        public string nameInEng { get; set; }
    }
}
