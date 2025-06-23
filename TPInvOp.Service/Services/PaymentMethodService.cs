using AutoMapper;
using TPInvOp.Data;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.PaymentMethod;
using TPInvOp.Service.Interfaces;
using TPInvOp.Service.Validators;

namespace TPInvOp.Service.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentMethodService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
   

        public bool Add(PaymentMethodEditDto paymentMethodDto, out List<string> errors)
        {
            errors = new List<string>();
            PaymentMethod payment = _mapper.Map<PaymentMethod>(paymentMethodDto);
            if (!_unitOfWork.PaymentMethod.Exist(payment.Name))
            {PaymentMethodValidator validator = new PaymentMethodValidator();
                if (!UniversalValidator.IsValid(payment, validator, out errors))
                {
                    return false;
                }
                _unitOfWork.PaymentMethod.Add(payment);
                int rowsAffected = _unitOfWork.Complete();
                return rowsAffected > 0;

            }
            else
            {
                errors.Add("Payment Method Already Exist!!");
                return false;
            }



        }

        public bool Exist(string name, int? excludeId = null)
        {
           return _unitOfWork.PaymentMethod.Exist(name, excludeId);
        }

        public IEnumerable<PaymentMethodListDto> GetAll()
        {
          var payment = _unitOfWork.PaymentMethod.GetAll();
            return _mapper.Map<List<PaymentMethodListDto>>(payment);
        }

        public PaymentMethod PaymentMethodGetById(int paymentMethodId, bool tracked = false)
        {
            return _unitOfWork.PaymentMethod.GetById(paymentMethodId, tracked);
        }

        public void Remove(int paymentMethodId)
        {
            _unitOfWork.PaymentMethod.Delete(paymentMethodId);
        }
    }
}
