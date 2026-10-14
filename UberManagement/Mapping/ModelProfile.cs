using AutoMapper;
using UberManagement.DTOs.Ride;
using UberManagement.DTOs.User;
using UberManagement.DTOs.Vehicle;
using UberManagement.Models;

namespace UberManagement.Mapping
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<User, GetUserDTO>();
            CreateMap<CreateUserDTO, User>();


            CreateMap<Vehicle, GetVehicleDTO>();
            CreateMap<CreateVehicleDTO, Vehicle>();


            CreateMap<Ride, GetRideDTO>();
            CreateMap<CreateRideDTO, Ride>();
        }
    }
}
