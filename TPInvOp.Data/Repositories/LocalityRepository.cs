using Microsoft.EntityFrameworkCore;
using TPInvOp.Data.Interfaces;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Repositories
{
    public class LocalityRepository : ILocalityRepository
    {
        public readonly AppDbContext _dbContext;

        public LocalityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Locality locality)
        {
            _dbContext.Localities.Add(locality);
        }

        public void Delete(int localityId)
        {
            var localityInDb = GetById(localityId, true);
            if (localityInDb != null)
            {
                _dbContext.Localities.Remove(localityInDb);
            }
        }

        public void Edit(Locality locality)
        {
            var localityInDb = GetById(locality.LocalityId, true);
            if (localityInDb != null)
            {
                localityInDb.LocalityName = locality.LocalityName;
                localityInDb.Delivery = locality.Delivery;
            }
        }

        public bool Exist(string name, int? excludeId = null)
        {
            return excludeId.HasValue
                ? _dbContext.Localities.Any(l => l.LocalityName.ToUpper() == name.ToUpper()
                                && l.LocalityId != excludeId)
                : _dbContext.Localities.Any(l => l.LocalityName.ToUpper() == name.ToUpper());
        }

        public IEnumerable<Locality> GetAll(string? sortedBy = null)
        {
            return _dbContext.Localities.ToList();
        }

        public Locality? GetById(int id, bool tracked = false)
        {
            return tracked
                ? _dbContext.Localities.FirstOrDefault(l => l.LocalityId == id)
                : _dbContext.Localities.AsNoTracking().FirstOrDefault(l => l.LocalityId == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
