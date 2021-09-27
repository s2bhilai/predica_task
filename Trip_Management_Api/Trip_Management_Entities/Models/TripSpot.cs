using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Management_Entities.Models
{
    public class TripSpot
    {
        [Key]
        public Int32 TripSpotId { get; set; }
        public string CountryName { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }

    }
}
