using AutoMapper;
using TPInvOp.Data;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Customer;
using TPInvOp.Service.Interfaces;

namespace TPInvOp.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IQueryable<CustomerListDto> GetAll()
        {
            var customer = _unitOfWork.Customer.GetAll();
            return _mapper.ProjectTo<CustomerListDto>(customer);
        }

        public CustomerEditDto? CustomerById(int id)
        {
            var locality = _unitOfWork.Customer.Get(filter: l => l.CustomerID == id,
                tracked: true);
            if (locality is null) return null;
            return _mapper.Map<CustomerEditDto>(locality);
        }

        public bool Exist(Customer locality, int? excludeId = null)
        {
            return _unitOfWork.Customer.Exist(locality, excludeId);
        }

        public bool Save(CustomerEditDto localityDto, out List<string> errors)
        {
            errors = new List<string>();
            Customer locality = _mapper.Map<Customer>(localityDto);
            if (locality.CustomerID == 0)
            {
                if (!_unitOfWork.Customer.Exist(locality))
                {
                    _unitOfWork.Customer.Add(locality);
                    int rowsAffected = _unitOfWork.Complete();
                    return rowsAffected > 0;

                }
                else
                {
                    errors.Add("Customer Already Exist!!");
                    return false;
                }

            }
            else
            {
                if (!_unitOfWork.Customer.Exist(locality, locality.CustomerID))
                {
                    _unitOfWork.Customer.Update(locality);
                    int rowsAffected = _unitOfWork.Complete();
                    return rowsAffected > 0;

                }
                else
                {
                    errors.Add("Customer Already Exist!!");
                    return false;
                }

            }
        }

        public bool Remove(int localityId, out List<string> errors)
        {
            errors = new List<string>();
            var locality = _unitOfWork.Customer.Get(filter: l => l.CustomerID == localityId,
                tracked: true);
            if (locality is null)
            {
                errors.Add("Customer does not exist");
                return false;
            }
            _unitOfWork.Customer.Remove(locality);
            var rowsAffected = _unitOfWork.Complete();
            return rowsAffected > 0;
        }
    }
}
