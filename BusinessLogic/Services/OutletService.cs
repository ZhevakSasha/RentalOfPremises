using AutoMapper;
using BusinessLogic.DtoModels;
using DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace BusinessLogic.Services
{
    public class OutletService
    {
        private readonly UnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public OutletService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<OutletDto>> GetAllOutlets()
        {
            var outlets = await _unitOfWork.Outlets.Get();
            return _mapper.Map<IList<OutletDto>>(outlets);
        }

        public async Task AddOutlet(OutletDto outletDto)
        {
            var outlet = _mapper.Map<Outlet>(outletDto);
            await _unitOfWork.Outlets.Create(outlet);
            _unitOfWork.Save();
        }

        public async Task UpdateOutlet(OutletDto outletDto)
        {
            var outlet = _mapper.Map<Outlet>(outletDto);
            await _unitOfWork.Outlets.Update(outlet);
            _unitOfWork.Save();
        }

        public async Task<OutletDto> GetOutletById(int id)
        {
            var outlet = await _unitOfWork.Outlets.FindById(id);
            return _mapper.Map<OutletDto>(outlet);
        }

        public async Task DeleteOutlet(int id)
        {
            await _unitOfWork.Outlets.Remove(id);
            _unitOfWork.Save();
        }
    }
}
