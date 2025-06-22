using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPInvOp.Model.Entities;

namespace TPInvOp.Data.Interfaces
{
    public interface ILocalityRepository
    {
        IEnumerable<Locality> GetAll(string? sortedBy = null);
        Locality? GetById(int id, bool tracked = false);
        void Add(Locality locality);
        bool Exist(string name, int? excludeId = null);
        void Edit(Locality locality);
        void Delete(int localityId);
        void SaveChanges();
    }
}
