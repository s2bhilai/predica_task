using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Management_Entities.Models
{
    [Table("Trip")]
    public class Trip
    {
        public Int32 TripId { get; set; }
        public string TripName { get; set; }
        public string Trip_Start_Location { get; set; }
        public DateTime Trip_Start_Date { get; set; }
        public DateTime Trip_End_Date { get; set; }
        public string Trip_Itinerary_Desc { get; set; }
        public string Created_By { get; set; }
        public string IsCancelled { get; set; }
        public string TripExpense { get; set; }
        public DateTime Created_On { get; set; }
        public DateTime Modified_On { get; set; }
        public string Modified_By { get; set; }

        public TripDetail TripDetail { get; set; }
        public ICollection<TripCustomer> TripCustomers { get; set; }
    }
}
