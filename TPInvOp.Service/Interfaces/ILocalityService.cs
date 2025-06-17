using TPInvOp.Model.Entities;

namespace TPInvOp.Service.Interfaces
{
    public interface ILocalityService
    {
        IEnumerable<Locality> GetAll();
    }
}
