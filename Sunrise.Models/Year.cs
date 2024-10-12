using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models
{
    public class Year
    {
        [Key]
        public int YearID { get; set; }

        [Required]
        [DisplayName("Academic Year")]
        public string YearEN { get; set; }

        [Required]
        [DisplayName("السنة الدراسية بالهجري")]
        public string YearAR { get; set; }

        [Required]
        [DisplayName("Addmission Date")]
        public DateOnly AddmissionDate {  get; set; }

        public bool ActiveFlag { get; set; }
    }
}
