

using AutoMapper;
using f1api.DTOs;
using f1api.Models;

namespace F1api.Automappers
{
    public class AutoMapperProfile:  Profile
    {
       
        public AutoMapperProfile() {

            CreateMap<Driver, CardDriverDto>();
                }
    }
}
