using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Management_Entities.DataTransferObjects
{
    public class TripDto
    {
        public int TripId { get; set; }
        public string TripName { get; set; }
        public DateTimeOffset Trip_Start_Date { get; set; }
        public DateTimeOffset Trip_End_Date { get; set; }
        public string Trip_Start_Location { get; set; }
        public string IsCancelled { get; set; }
    }
}
