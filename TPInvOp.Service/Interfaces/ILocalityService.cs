using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Locality;

namespace TPInvOp.Service.Interfaces
{
    public interface ILocalityService
    {
        IQueryable<LocalityListDto> GetAll();
        LocalityEditDto? LocalityById(int id);
        bool Exist(Locality locality, int? excludeId = null);
        bool Save(LocalityEditDto localityDto, out List<string> errors);
        bool Remove(int localityId, out List<string> errors);
    }
}
