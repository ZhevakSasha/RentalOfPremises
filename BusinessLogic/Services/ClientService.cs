using DataAccess;
using DataAccess.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ClientService
    {
        private UnitOfWork _unitOfWork;

        public ClientService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Client>> GetAllClients()
        {
            return await _unitOfWork.Clients.Get();
        }

        public async Task AddClient(Client client)
        {
            await _unitOfWork.Clients.Create(client);
            _unitOfWork.Save();
        }

        public void UpdateClient(Client client)
        {
            _unitOfWork.Clients.Update(client);
            _unitOfWork.Save();
        }

        public Task<Client> GetClientById(int id)
        {
            return _unitOfWork.Clients.FindById(id);
        }

        public void DeleteClient(Client client)
        {
            _unitOfWork.Clients.Remove(client);
            _unitOfWork.Save();
        }
    }
}
