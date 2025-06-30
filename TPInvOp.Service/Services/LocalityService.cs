using AutoMapper;
using TPInvOp.Data;
using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Locality;
using TPInvOp.Service.Interfaces;

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

        public bool Save(LocalityEditDto localityDto, out List<string> errors)
        {
            errors = new List<string>();
            Locality locality = _mapper.Map<Locality>(localityDto);
            if (locality.LocalityId == 0)
            {
                if (!_unitOfWork.Localities.Exist(locality))
                {
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
            else
            {
                if (!_unitOfWork.Localities.Exist(locality, locality.LocalityId))
                {
                    _unitOfWork.Localities.Update(locality);
                    int rowsAffected = _unitOfWork.Complete();
                    return rowsAffected > 0;

                }
                else
                {
                    errors.Add("Locality Already Exist!!");
                    return false;
                }

            }
        }

        public bool Remove(int localityId, out List<string> errors)
        {
            errors = new List<string>();
            var locality = _unitOfWork.Localities.GetById(localityId);
            if (locality is null)
            {
                errors.Add("Locality does not exist");
                return false;
            }
            _unitOfWork.Localities.Remove(localityId);
            var rowsAffected = _unitOfWork.Complete();
            return rowsAffected > 0;
        }

        public bool Exist(Locality locality, int? excludeId = null)
        {
            return _unitOfWork.Localities.Exist(locality, excludeId);
        }

        public IQueryable<LocalityListDto> GetAll()
        {
            var localityes = _unitOfWork.Localities.GetAll();
            return _mapper.ProjectTo<LocalityListDto>(localityes);
        }

        public LocalityEditDto? LocalityById(int id)
        {
            var locality = _unitOfWork.Localities.GetById(id);
            if (locality is null) return null;
            return _mapper.Map<LocalityEditDto>(locality);
        }

    }
}
