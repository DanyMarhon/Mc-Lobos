using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface ILocalityRepository : IGenericRepository<Locality>
    {
        bool Exist(Locality locality, int? excludeId = null);
        void Update(Locality locality);
    }
}
