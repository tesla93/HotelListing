using AutoMapper;
using HotelListing.Data;
using HotelListing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Configurations
{
    public class MapperInitialize: Profile
    {
        public MapperInitialize()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
            CreateMap<Hotel, UpdateHotelDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();

        }
    }
}
