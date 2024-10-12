using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace Sunrise.Models
{
    public class GradeClass
    {
        [Key]
        public int GradeClassID { get; set; }

        [Required]
        [DisplayName("Class Name")]
        public string ClassName { get; set; }

        public int GradeID { get; set; }

        [ForeignKey("GradeID")]
        [ValidateNever]
        public Grade? Grade { get; set; }

    }
}
