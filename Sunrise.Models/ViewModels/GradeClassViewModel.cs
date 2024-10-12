using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models.ViewModels
{
    public class GradeClassViewModel
    {
        public GradeClass GradeClass {  get; set; }
        public IEnumerable<SelectListItem> GradeList { get; set; }
    }
}
