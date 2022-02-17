using AutoMapper;
using BusinessLogic.DtoModels;
using DataAccess;
using DataAccess.Entityes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ClientService
    {
        private UnitOfWork _unitOfWork;

        private IMapper _mapper;

        public ClientService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<ClientDto>> GetAllClients()
        {
            var clients = await _unitOfWork.Clients.Get();
            return _mapper.Map<IList<ClientDto>>(clients);
        }

        public async Task AddClient(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _unitOfWork.Clients.Create(client);
            _unitOfWork.Save();
        }

        public async Task UpdateClient(ClientDto clientDto)
        {
             var client = _mapper.Map<Client>(clientDto);
             await _unitOfWork.Clients.Update(client);
            _unitOfWork.Save();
        }

        public async Task<ClientDto> GetClientById(int id)
        {
            var client = await _unitOfWork.Clients.FindById(id);
            return _mapper.Map<ClientDto>(client);
        }

        public async Task DeleteClient(int id)
        {
            await _unitOfWork.Clients.Remove(id);
            _unitOfWork.Save();
        }
    }
}
