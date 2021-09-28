using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Management_Entities.Models;

namespace Trip_Management_Contracts
{
    public interface ICustomerTripRepository
    {
        Task<IEnumerable<TripCustomer>> GetAllTripsForCustomersAsync(int customerId, bool trackChanges);

        void AddCustomerToTrip(TripCustomer tripCustomer);
    }
}
