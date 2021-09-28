using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Management_Entities.DataTransferObjects
{
    public class TripUpdateDto
    {
        public string Trip_Notes { get; set; }
        public Int32 Trip_Preference_Sequence { get; set; }
        public Int32 TripId { get; set; }
        public Int32 TripModeId { get; set; }
        public Int32 TripPropertyId { get; set; }
        public Int32 TripSpotId { get; set; }
        public Int32 TripTypeId { get; set; }
    }
}
