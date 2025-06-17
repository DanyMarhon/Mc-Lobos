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
            throw new NotImplementedException();
        }

        public void Delete(Locality locality)
        {
            throw new NotImplementedException();
        }

        public void Edit(Locality locality)
        {
            throw new NotImplementedException();
        }

        public bool Exist(Locality locality)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Locality> GetAll()
        {
            throw new NotImplementedException();
        }

        public Locality? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
