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
        IEnumerable<Locality> GetAll();
        Locality? GetById(int id);
        void Add(Locality locality);
        bool Exist(Locality locality);
        void Edit(Locality locality);
        void Delete(Locality locality);
    }
}
