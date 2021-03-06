using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/trips")]
    [ApiController]
    public class TripController: ControllerBase
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public TripController(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "TripById")]
        public async Task<IActionResult> GetTrip(int id)
        {
            var trip = await _repositoryManager
                .Trip.GetTripAsync(id, trackChanges: false);

            if(trip == null)
            {
                return NotFound();
            }
            else
            {
                var tripDto = _mapper.Map<TripDto>(trip);
                return Ok(tripDto);
            }
        }


        [HttpPost("createtrip")]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> CreateTrip([FromBody]TripCreationDto tripCreationDto)
        {
            var tripEntity = _mapper.Map<Trip>(tripCreationDto);

            tripEntity.IsCancelled = "N";
            tripEntity.Created_On = DateTime.Now;

            _repositoryManager.Trip.CreateTrip(tripEntity);
            await _repositoryManager.SaveAsync();

            var tripToReturn = _mapper.Map<TripDto>(tripEntity);

            return CreatedAtRoute("TripById", 
                new { id = tripToReturn.TripId },
                tripToReturn);
        }

        [HttpPost("cancel/{tripId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CancelTrip(int tripId)
        {
            var trip = await _repositoryManager
               .Trip.GetTripAsync(tripId, trackChanges: false);

            if (trip == null)
            {
                return NotFound();
            }
            else
            {
                //check if trip is cancelled within 7 days
                int noOfDays = (DateTime.Now - trip.Created_On).Days;

                if(noOfDays > 7)
                {
                    trip.IsCancelled = "Y";
                    _repositoryManager.Trip.UpdateTrip(tripId, trip);
                    await _repositoryManager.SaveAsync();

                    var tripDto = _mapper.Map<TripDto>(trip);
                    return Ok(tripDto);
                }

                return Ok("Trip cannot be cancelled with in 7 days.");
            }
        }



    }
}
