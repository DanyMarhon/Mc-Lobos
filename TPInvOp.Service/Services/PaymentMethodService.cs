using AutoMapper;
using TPInvOp.Data;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.PaymentMethod;
using TPInvOp.Service.Interfaces;

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


        public bool Save(PaymentMethodEditDto paymentMethodDto, out List<string> errors)
        {
            errors = new List<string>();
            PaymentMethod paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodDto);
            if (paymentMethod.PaymentMethodId == 0)
            {
                if (!_unitOfWork.PaymentMethod.Exist(paymentMethod))
                {
                    _unitOfWork.PaymentMethod.Add(paymentMethod);
                    int rowsAffected = _unitOfWork.Complete();
                    return rowsAffected > 0;
                }
                else
                {
                    errors.Add("Payment Method Already Exist!!");
                    return false;
                }

            }
            else
            {
                if (!_unitOfWork.PaymentMethod.Exist(paymentMethod))
                {
                    _unitOfWork.PaymentMethod.Update(paymentMethod);
                    int rowsAffected = _unitOfWork.Complete();
                    return rowsAffected > 0;

                }
                else
                {
                    errors.Add("Payment Method Already Exist!!");
                    return false;
                }

            }
        }

        public bool Exist(PaymentMethod paymentMethod, int? excludeId = null)
        {
            return _unitOfWork.PaymentMethod.Exist(paymentMethod, excludeId);
        }

        public PaymentMethodEditDto? PaymentMethodById(int id)
        {
            var paymentMethod = _unitOfWork.PaymentMethod.GetById(id);
            if (paymentMethod is null) return null;
            return _mapper.Map<PaymentMethodEditDto>(paymentMethod);
        }

        IQueryable<PaymentMethodListDto> IPaymentMethodService.GetAll()
        {
            var paymentMethods = _unitOfWork.PaymentMethod.GetAll();
            return _mapper.ProjectTo<PaymentMethodListDto>(paymentMethods);
        }

        public bool Remove(int paymentMethodId, out List<string> errors)
        {
            errors = new List<string>();
            var paymentMethod = _unitOfWork.PaymentMethod.GetById(paymentMethodId);
            if (paymentMethod is null)
            {
                errors.Add("Payment Method does not exist");
                return false;
            }
            _unitOfWork.PaymentMethod.Remove(paymentMethodId);
            var rowsAffected = _unitOfWork.Complete();
            return rowsAffected > 0;
        }
    }
}
