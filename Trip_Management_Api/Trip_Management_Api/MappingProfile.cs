using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip_Management_Entities.DataTransferObjects;
using Trip_Management_Entities.Models;

namespace Trip_Management_Api
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<TripCreationDto, Trip>();

            CreateMap<Trip, TripDto>();

            CreateMap<TripUpdateDto, TripDetail>();

            CreateMap<TripDetail, TripDetailsDto>();

            CreateMap<Customer, CustomerDto>();

            CreateMap<CustomerCreationDto, Customer>();
        }
    }
}
