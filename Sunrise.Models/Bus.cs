using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunrise.Models
{
    public class Bus
    {
        [Key]
        public int BusID { get; set; }

        [Required]
        [DisplayName("Bus Number")]
        public int BusNumber { get; set; }

        [DisplayName("Driver Name")]
        public string DriverName { get; set; }

        [DisplayName("Driver Phone Number")]
        public string DriverPhone {  get; set; }

        [DisplayName("Bus Plate Number")]

        public string BusPlate { get; set; }

        [DisplayName("Path")]
        public string BusPath { get; set; }

        [DisplayName("Bus Type")]
        public string BusType { get; set; }

    }
}
