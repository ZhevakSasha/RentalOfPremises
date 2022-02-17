using AutoMapper;
using BusinessLogic.DtoModels;
using DataAccess.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
