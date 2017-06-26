using KamilCieślikLab4PD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamilCieślikLab4PD.Repository.Interfaces
{
    public interface IReadRepository<T> where T :Entity
    {
        IList<T> GetAll();
        T GetByID(int id);
    }
}
