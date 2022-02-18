using AutoMapper;
using BusinessLogic.DtoModels;
using DataAccess.Entities;

namespace RentalOfPremisesAPI
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Outlet, OutletDto>().ReverseMap();
            CreateMap<Rent, RentDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
        }
    }
}
