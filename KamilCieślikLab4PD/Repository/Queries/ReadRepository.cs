using KamilCieślikLab4PD.Model;
using KamilCieślikLab4PD.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamilCieślikLab4PD.Repository
{
    public class ReadRepository<T>: IReadRepository<T> where T :Entity
    {
        private readonly KamilCieślikLab4PDContext context;

        public ReadRepository(KamilCieślikLab4PDContext context)
        {
            this.context = context;
        }
        public IList<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return context.Set<T>().Where(x => x.ID == id).FirstOrDefault();
        }
    }
}
