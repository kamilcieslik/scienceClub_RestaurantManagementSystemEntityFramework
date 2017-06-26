using System.Collections.Generic;
using System.Linq;
using KamilCieślikLab4PD.Model;
using KamilCieślikLab4PD.Repository.Queries.Interfaces;

namespace KamilCieślikLab4PD.Repository.Queries
{
    public class ReadRepository<T>: IReadRepository<T> where T :Entity
    {
        private readonly KamilCieślikLab4PdContext _context;

        public ReadRepository(KamilCieślikLab4PdContext context)
        {
            _context = context;
        }
        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.ID == id);
        }
    }
}
