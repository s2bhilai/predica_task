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
    public class CustomerTripRepository : RepositoryBase<TripCustomer>, ICustomerTripRepository
    {
        public CustomerTripRepository(TripContext tripContext)
            : base(tripContext)
        {

        }

        public void AddCustomerToTrip(TripCustomer tripCustomer)
        {
            Create(tripCustomer);
        }

        public async Task<IEnumerable<TripCustomer>> GetAllTripsForCustomersAsync(
            int customerId,bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(c => c.CustomerId == customerId)
                .OrderBy(c => c.TripId)
                .ToListAsync();
        }
    }
}
