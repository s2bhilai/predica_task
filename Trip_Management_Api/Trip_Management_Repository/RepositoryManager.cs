using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Management_Contracts;
using Trip_Management_Entities;

namespace Trip_Management_Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private TripContext _tripContext;
        private ITripRepository _tripRepository;
        private ICustomerRepository _customerRepository;
        private ITripDetailRepository _tripDetailsRepository;
        private ICustomerTripRepository _customerTripRepository;

        public RepositoryManager(TripContext tripContext)
        {
            _tripContext = tripContext;
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_tripContext);

                return _customerRepository;
            }
        }

        public ITripRepository Trip
        {
            get
            {
                if (_tripRepository == null)
                    _tripRepository = new TripRepository(_tripContext);

                return _tripRepository;
            }
        }

        public ITripDetailRepository TripDetails
        {
            get
            {
                if (_tripDetailsRepository == null)
                    _tripDetailsRepository = new TripDetailsRepository(_tripContext);

                return _tripDetailsRepository;
            }
        }

        public ICustomerTripRepository CustomerTrips
        {
            get
            {
                if (_customerTripRepository == null)
                    _customerTripRepository = new CustomerTripRepository(_tripContext);

                return _customerTripRepository;
            }
        }

        public Task SaveAsync()
        {
            return _tripContext.SaveChangesAsync();
        }
    }
}
