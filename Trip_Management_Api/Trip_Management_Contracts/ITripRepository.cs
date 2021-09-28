using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Management_Entities.Models;

namespace Trip_Management_Contracts
{
    public interface ITripRepository
    {
        Task<Trip> GetTripAsync(int tripId, bool trackChanges);
        void CreateTrip(Trip trip);
        void UpdateTrip(int tripId, Trip trip);
    }
}
