using AutoMapper;
using BusinessLogic.DtoModels;
using DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace BusinessLogic.Services
{
    public class PaymentService
    {
        private readonly UnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public PaymentService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<PaymentDto>> GetAllPayments()
        {
            var payments = await _unitOfWork.Payments.Get();
            return _mapper.Map<IList<PaymentDto>>(payments);
        }

        public async Task AddPayment(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _unitOfWork.Payments.Create(payment);
            _unitOfWork.Save();
        }

        public async Task UpdatePayment(PaymentDto paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _unitOfWork.Payments.Update(payment);
            _unitOfWork.Save();
        }

        public async Task<PaymentDto> GetPaymentById(int id)
        {
            var payment = await _unitOfWork.Payments.FindById(id);
            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task DeletePayment(int id)
        {
            await _unitOfWork.Payments.Remove(id);
            _unitOfWork.Save();
        }
    }
}
