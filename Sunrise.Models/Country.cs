using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sunrise.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Country Name must contain only English characters.")]

        [DisplayName("Country Name")]
        public string CountryNameEN { get; set; }


        [DisplayName("اسم الدولة بالعربي")]
        [Required]
        [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessage = "اسم الدولة بالعربي must contain only Arabic characters.")]
        public string CountryNameAR { get; set; }


        //[DisplayName("Nationality EN")]
        //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Nationality EN must contain only English characters.")]
        //[Required]
        //public string NationalityEN { get; set; }


        //[DisplayName("الجنسية بالعربي للبنين")]
        //[Required]
        //[RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessage = "الجنسية بالعربي للبنين must contain only Arabic characters.")]
        //public string NationalityARMale { get; set; }


        //[DisplayName("الجنسية بالعربي للبنات")]
        //[Required]
        //[RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessage = "الجنسية بالعربي للبنات must contain only Arabic characters.")]
        //public string NationalityARFemale { get; set; }
    }
}
