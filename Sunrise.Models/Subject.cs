using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        [Required]
        [DisplayName("Subject Name")]
        public string SubjectNameEN { get; set; }

        [DisplayName("اسم المادة")]
        public string SubjectNameAR { get; set; }

        [Required]
        [DisplayName("Noor Name")]
        public string NoorName {  get; set; }

        [DisplayName("Noor ID")]
        public int NoorID { get; set; }
        [DisplayName("Static Flag")]

        public bool StaticFlag { get; set; }
    }
}
