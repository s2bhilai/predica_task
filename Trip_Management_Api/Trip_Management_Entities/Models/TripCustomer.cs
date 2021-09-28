using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Management_Entities.Models
{
    public class TripCustomer
    {
        [Key]
        public Int32 TripCustomerId { get; set; }
        public Int32 TripId { get; set; }
        public Trip Trip { get; set; }
        public Int32 CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTimeOffset Trip_Start_Date { get; set; }
        public DateTimeOffset Trip_End_Date { get; set; }
    }
}
