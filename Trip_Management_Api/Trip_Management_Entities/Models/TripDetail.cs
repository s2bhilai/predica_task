using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Management_Entities.Models
{
    public class TripDetail
    {
        [Key]
        public Int32 TripDetailsId { get; set; }
        public string Trip_Notes { get; set; }
        public Int32 Trip_Preference_Sequence { get; set; }
        public string IsActive { get; set; }
        public DateTime Created_On { get; set; }
        public DateTime Modified_On { get; set; }
        public string Modified_By { get; set; }

        public Int32 TripId { get; set; }
        public Trip Trip { get; set; }

        public Int32 TripModeId { get; set; }
        public TripMode TripMode { get; set; }

        public Int32 TripPropertyId { get; set; }
        public TripProperty TripProperty { get; set; }

        public Int32 TripSpotId { get; set; }
        public TripSpot TripSpot { get; set; }

        public Int32 TripTypeId { get; set; }
        public TripType TripType { get; set; }
    } 
}
