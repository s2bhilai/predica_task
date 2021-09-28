using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Management_Contracts;
using Trip_Management_Entities.DataTransferObjects;
using Trip_Management_Entities.Models;

namespace Trip_Management_Api.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController: ControllerBase
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public CustomerController(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "CustomerById")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _repositoryManager
                .Customer.GetCustomerAsync(id, trackChanges: false);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                var customerDto = _mapper.Map<CustomerDto>(customer);
                return Ok(customerDto);
            }
        }

        [HttpPost("createcustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreationDto customerCreationDto)
        {
            var customerEntity = _mapper.Map<Customer>(customerCreationDto);

            _repositoryManager.Customer.CreateCustomer(customerEntity);
            await _repositoryManager.SaveAsync();

            var customerToReturn = _mapper.Map<CustomerDto>(customerEntity);

            return CreatedAtRoute("CustomerById",
                new { id = customerToReturn.CustomerId },
                customerToReturn);
        }

        [HttpPost("assigncustomertotrip")]
        public async Task<IActionResult> AssignCustomerToTrip(int customerId,int tripId)
        {
            //Check if customer and trip are valid
            var customer = await _repositoryManager
               .Customer.GetCustomerAsync(customerId, trackChanges: false);
            
            if (customer == null)
            {
                return NotFound();
            }

            var trip = await _repositoryManager
                .Trip.GetTripAsync(tripId, trackChanges: false);

            if (trip == null)
            {
                return NotFound();
            }

            //Get all existing trips for customer 
            var tripsForCustomer = await _repositoryManager.CustomerTrips
                .GetAllTripsForCustomersAsync(customerId, false);

            if(tripsForCustomer != null)
            {
                var overlappedTrips = tripsForCustomer
                    .Where(t => t.Trip_Start_Date <= trip.Trip_End_Date &&
                           t.Trip_End_Date >= trip.Trip_Start_Date);

                if(overlappedTrips != null)
                {
                    return Ok("customer cannot be added as trip will overlap");
                }
            }

            var tripCustomer = new TripCustomer()
            {
                TripId = tripId,
                CustomerId = customerId,
                Trip_Start_Date = trip.Trip_Start_Date,
                Trip_End_Date = trip.Trip_End_Date
            };

            _repositoryManager.CustomerTrips.AddCustomerToTrip(tripCustomer);
            await _repositoryManager.SaveAsync();

            return Ok();
        }
    }
}
