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

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
