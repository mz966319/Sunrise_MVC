using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models
{
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }

        [Required]
        [DisplayName("Grade Name")]
        public string GradeName { get; set; }
        //[Required]
        //[DisplayName("School Name")]
        //public string SchoolName { get; set; }

        [DisplayName("اسم المرحلة في الشهادة")]
        [Required]
        [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessage = "اسم المرحلة في الشهادة must contain only Arabic characters.")]
        public string CertificateNameAR { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Certificate Name must contain only English characters.")]
        [DisplayName("Certificate Name EN")]
        public string CertificateNameEN { get; set; }

        [Required]
        [Range(-3, 12, ErrorMessage = "Grade level must be between -3 and 12")]
        [DisplayName("Grade Level")]
        public int GradeLevel { get; set; }
    }
}
