using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models
{
    public class TeacherPermission
    {
        [Key]
        public int TeacherPermissionID { get; set; }

        [Required]
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        [ValidateNever]
        public ApplicationUser? User { get; set; }

        [Required]
        public int SubjectID { get; set; }
        [ForeignKey("SubjectID")]
        [ValidateNever]
        public Subject? Subject { get; set; }

        [Required]
        public int ClassID { get; set; }
        [ForeignKey("ClassID")]
        [ValidateNever]
        public GradeClass? Class { get; set; }

        [Required]
        //[DisplayName("Driver Phone Number")]
        public bool AcitveFlag {  get; set; }
    }
}
