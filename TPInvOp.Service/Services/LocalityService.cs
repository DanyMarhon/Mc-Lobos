using AutoMapper;
using TPInvOp.Data;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Locality;
using TPInvOp.Service.Interfaces;
using TPInvOp.Service.Validators;

namespace TPInvOp.Service.Services
{
    public class LocalityService : ILocalityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocalityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Add(LocalityEditDto localityDto, out List<string> errors)
        {
            errors = new List<string>();
            Locality locality = _mapper.Map<Locality>(localityDto);
            if (!_unitOfWork.Localities.Exist(locality.LocalityName))
            {
                LocalityValidator validations = new LocalityValidator();
                if (!UniversalValidator.IsValid(locality, validations, out errors))
                {
                    return false;
                }
                _unitOfWork.Localities.Add(locality);
                int rowsAffected = _unitOfWork.Complete();
                return rowsAffected > 0;
            }
            else
            {
                errors.Add("Locality Already Exist!!");
                return false;
            }
        }

        public void Delete(int localityId)
        {
            _unitOfWork.Localities.Delete(localityId);
        }

        public bool Exist(string name, int? excludeId = null)
        {
            return _unitOfWork.Localities.Exist(name, excludeId);
        }

        public IEnumerable<LocalityListDto> GetAll(string? sortedBy = null)
        {
            var localities = _unitOfWork.Localities.GetAll(sortedBy);
            return _mapper.Map<List<LocalityListDto>>(localities);
        }

        public Locality? LocalityById(int id, bool tracked = false)
        {
            return _unitOfWork.Localities.GetById(id, tracked);
        }
    }
}
