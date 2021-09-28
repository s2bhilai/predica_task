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
    public class CustomerRepository : RepositoryBase<Customer>,ICustomerRepository
    {
        public CustomerRepository(TripContext tripContext)
            :base(tripContext)
        {

        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public async Task<Customer> GetCustomerAsync(int customerId, bool trackChanges)
        {
            return await FindByCondition(c => c.CustomerId.Equals(customerId), trackChanges).SingleOrDefaultAsync();
        }
    }
}
