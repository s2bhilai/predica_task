using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Management_Entities.Models;

namespace Trip_Management_Contracts
{
    public interface ITripDetailRepository
    {
        Task<TripDetail> GetTripDetailsAsync(int tripId, bool trackChanges);
        void AddTripDetailsForTrip(int tripId, TripDetail tripDetail);
        void UpdateTripDetails(int tripId, TripDetail tripDetail);
    }
}
