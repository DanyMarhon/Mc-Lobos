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

        public void Remove(int localityId)
        {
            var localityInDb = GetById(localityId);
            if (localityInDb is not null)
            {
                _dbContext.Entry(localityInDb).State = EntityState.Deleted;
            }
        }

        public void Update(Locality locality)
        {
            var localityInDb = GetById(locality.LocalityId);
            if (localityInDb != null)
            {
                localityInDb.LocalityName = locality.LocalityName;
                localityInDb.Delivery = locality.Delivery;

                _dbContext.Entry(localityInDb).State = EntityState.Modified;
            }
        }

        public bool Exist(Locality locality, int? excludeId = null)
        {
            return excludeId.HasValue
                ? _dbContext.Localities.Any(l => l.LocalityName.ToUpper() == locality.LocalityName.ToUpper()
                                && l.LocalityId != excludeId)
                : _dbContext.Localities.Any(l => l.LocalityName.ToUpper() == locality.LocalityName.ToUpper());
        }

        public IQueryable<Locality> GetAll()
        {
            return (IQueryable<Locality>)_dbContext.Localities.AsNoTracking();
        }

        public Locality? GetById(int id)
        {
            return _dbContext.Localities.AsNoTracking().FirstOrDefault(l => l.LocalityId == id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
