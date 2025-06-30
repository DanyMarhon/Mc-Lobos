using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface ILocalityRepository
    {
        IQueryable<Locality> GetAll();
        Locality? GetById(int id);
        void Add(Locality locality);
        bool Exist(Locality locality, int? excludeId = null);
        void Update(Locality locality);
        void Remove(int localityId);
        void SaveChanges();
    }
}
