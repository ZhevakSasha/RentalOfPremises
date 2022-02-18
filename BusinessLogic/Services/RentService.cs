using AutoMapper;
using BusinessLogic.DtoModels;
using DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace BusinessLogic.Services
{
    public class RentService
    {
        private readonly UnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public RentService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<RentDto>> GetAllRents()
        {
            var rents = await _unitOfWork.Rents.Get();
            return _mapper.Map<IList<RentDto>>(rents);
        }

        public async Task AddRent(RentDto rentDto)
        {   
            var rent = _mapper.Map<Rent>(rentDto);

            var paymentPerDay = (await _unitOfWork.Outlets.FindById(rentDto.OutletId)).RentalCostPerDay;

            var rentDays = (int)(rentDto.DownPayment / paymentPerDay);
            var balance = rentDto.DownPayment - (rentDays * paymentPerDay);

            rent.DateOfEnd.AddDays(rentDays);

            await _unitOfWork.Rents.Create(rent);

            _unitOfWork.Save();

            var paymentDto = new PaymentDto { 
                RentId = rent.Id, 
                Date = rent.DateOfStart,
                Contribution = rentDto.DownPayment
            };

            await _unitOfWork.Payments.Create(_mapper.Map<Payment>(paymentDto));

            _unitOfWork.Save();
        }

        public async Task UpdateRent(RentDto rentDto)
        {
            var rent = _mapper.Map<Rent>(rentDto);
            await _unitOfWork.Rents.Update(rent);
            _unitOfWork.Save();
        }

        public async Task<RentDto> GetRentById(int id)
        {
            var rent = await _unitOfWork.Rents.FindById(id);
            return _mapper.Map<RentDto>(rent);
        }

        public async Task DeleteRent(int id)
        {
            await _unitOfWork.Rents.Remove(id);
            _unitOfWork.Save();
        }
    }
}
