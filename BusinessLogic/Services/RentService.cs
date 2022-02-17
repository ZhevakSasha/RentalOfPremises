using AutoMapper;
using BusinessLogic.DtoModels;
using DataAccess;
using DataAccess.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class RentService
    {
        private UnitOfWork _unitOfWork;

        private IMapper _mapper;

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
            await _unitOfWork.Rents.Create(rent);
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
