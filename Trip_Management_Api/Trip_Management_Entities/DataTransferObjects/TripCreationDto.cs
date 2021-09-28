using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Management_Entities.DataTransferObjects
{
    public class TripCreationDto
    {
        public string TripName { get; set; }
        public DateTimeOffset TripStartDate { get; set; }
        public DateTimeOffset TripEndDate { get; set; }
        public string TripStartLocation { get; set; }
        public string TripDescription { get; set; }
        public string  TripCreatedBy { get; set; }
        public string TripCost { get; set; }

    }
}
