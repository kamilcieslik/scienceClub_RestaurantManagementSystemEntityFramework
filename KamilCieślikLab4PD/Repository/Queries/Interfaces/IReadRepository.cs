using System.Collections.Generic;
using KamilCieślikLab4PD.Model;

namespace KamilCieślikLab4PD.Repository.Queries.Interfaces
{
    public interface IReadRepository<T> where T :Entity
    {
        IList<T> GetAll();
        T GetByID(int id);
    }
}
