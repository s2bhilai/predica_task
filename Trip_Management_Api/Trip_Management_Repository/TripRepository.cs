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
    public class TripRepository : RepositoryBase<Trip>, ITripRepository
    {
        public TripRepository(TripContext tripContext)
            :base(tripContext)
        {

        }
    }
}
