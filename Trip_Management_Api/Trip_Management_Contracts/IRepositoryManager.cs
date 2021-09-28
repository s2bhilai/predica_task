using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip_Management_Contracts
{
    public interface IRepositoryManager
    {
        ICustomerRepository Customer { get; }
        ITripRepository Trip { get; }
        ITripDetailRepository TripDetails { get; }
        Task SaveAsync();
    }
}
