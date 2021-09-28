using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Management_Entities.DataTransferObjects
{
    public class TripDetailsDto
    {
        public Int32 TripDetailsId { get; set; }
        public string Trip_Notes { get; set; }
        public Int32 Trip_Preference_Sequence { get; set; }
        public Int32 TripId { get; set; }
    }
}
