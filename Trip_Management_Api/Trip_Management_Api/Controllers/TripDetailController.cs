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
    [Route("api/trips/tripdetail")]
    [ApiController]
    public class TripDetailController: ControllerBase
    {
        private IRepositoryManager _repositoryManager;
        private IMapper _mapper;

        public TripDetailController(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet("{tripId}", Name = "TripDetailsByTripId")]
        public async Task<IActionResult> GetTripDetails(int tripId)
        {
            var tripDetails = await _repositoryManager
                .TripDetails.GetTripDetailsAsync(tripId, trackChanges: false);

            if (tripDetails == null)
            {
                return NotFound();
            }
            else
            {
                var tripDetailsDto = _mapper.Map<TripDetailsDto>(tripDetails);
                return Ok(tripDetailsDto);
            }
        }

        [HttpPost("edittrip")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditTrip([FromBody] TripUpdateDto tripUpdateDto)
        {
            //Check if trip exists
            var trip = await _repositoryManager
                .Trip.GetTripAsync(tripUpdateDto.TripId, trackChanges: false);

            if (trip == null)
            {
                return NotFound();
            }

            //Check if trip details exists
            var tripDetails = await _repositoryManager.TripDetails
                .GetTripDetailsAsync(tripUpdateDto.TripId, false);

            if (tripDetails == null)
            {
                var tripDetailsToAdd = _mapper.Map<TripDetail>(tripUpdateDto);
                _repositoryManager.TripDetails.AddTripDetailsForTrip(tripUpdateDto.TripId, tripDetailsToAdd);
                await _repositoryManager.SaveAsync();

                var tripToReturn = _mapper.Map<TripDetailsDto>(tripDetailsToAdd);

                return CreatedAtRoute("TripDetailsByTripId",
                    new { tripId = tripToReturn.TripId },
                    tripToReturn);
            }

            _mapper.Map(tripUpdateDto, tripDetails);

            _repositoryManager.TripDetails.UpdateTripDetails(tripUpdateDto.TripId, tripDetails);
            await _repositoryManager.SaveAsync();

            return NoContent();

        }

    }
}
