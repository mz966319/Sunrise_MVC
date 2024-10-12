using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models.ViewModels
{
    public class CountryNationalityViewModel
    {

        public List<Country> CountryList {  get; set; }
        public List<Nationality> NationalityList { get; set; }
    }
}
