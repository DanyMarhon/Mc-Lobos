using Microsoft.EntityFrameworkCore;
using TPInvOp.Data.Interfaces;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Repositories
{
    public class LocalityRepository : GenericRepository<Locality>, ILocalityRepository
    {
        public readonly AppDbContext _dbContext;

        public LocalityRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Exist(Locality locality, int? excludeId = null)
        {
            return excludeId.HasValue
                ? _dbContext.Localities.Any(l => l.LocalityName.ToUpper() == locality.LocalityName.ToUpper()
                                && l.LocalityId != excludeId)
                : _dbContext.Localities.Any(l => l.LocalityName.ToUpper() == locality.LocalityName.ToUpper());
        }
        public void Update(Locality locality)
        {
            var localityInDb = Get(filter: l => l.LocalityId == locality.LocalityId,
                tracked: true);
            if (localityInDb != null)
            {
                localityInDb.LocalityName = locality.LocalityName;
                localityInDb.Delivery = locality.Delivery;

                _dbContext.Entry(localityInDb).State = EntityState.Modified;
            }
        }
    }
}
