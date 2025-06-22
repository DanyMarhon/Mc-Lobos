using TPInvOp.Model.Entities;
using TPInvOp.Service.DTOs.Locality;

namespace TPInvOp.Service.Interfaces
{
    public interface ILocalityService
    {
        IEnumerable<LocalityListDto> GetAll(string? sortedBy = null);
        bool Add(LocalityEditDto localityDto, out List<string> errors);
        void Delete(int localityId);
        bool Exist(string name, int? excludeId = null);
        Locality? LocalityById(int id, bool tracked = false);


    }
}
