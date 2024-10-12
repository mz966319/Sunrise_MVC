using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sunrise.Models
{
    public class Nationality
    {
        [Key]
        public int NationalityID { get; set; }


        [DisplayName("Nationality")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Nationality EN must contain only English characters.")]
        [Required]
        public string NationalityEN { get; set; }


        [DisplayName("الجنسية للبنين")]
        [Required]
        [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessage = "الجنسية بالعربي للبنين must contain only Arabic characters.")]
        public string NationalityARMale { get; set; }


        [DisplayName("الجنسية للبنات")]
        [Required]
        [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessage = "الجنسية بالعربي للبنات must contain only Arabic characters.")]
        public string NationalityARFemale { get; set; }
    }
}
