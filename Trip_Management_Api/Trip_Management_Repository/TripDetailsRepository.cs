using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Management_Contracts;
using Trip_Management_Entities;
using Trip_Management_Entities.Models;

namespace Trip_Management_Repository
{
    public class TripDetailsRepository : RepositoryBase<TripDetail>, ITripDetailRepository
    {
        public TripDetailsRepository(TripContext tripContext)
            : base(tripContext)
        {

        }

        public void AddTripDetailsForTrip(int tripId, TripDetail tripDetail)
        {
            Create(tripDetail);
        }

        public async Task<TripDetail> GetTripDetailsAsync(int tripId, bool trackChanges)
        {
            return await FindByCondition(c => c.TripId.Equals(tripId), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateTripDetails(int tripId, TripDetail tripDetail)
        {
            Update(tripDetail);
        }
    }
}
