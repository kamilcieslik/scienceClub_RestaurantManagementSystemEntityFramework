using KamilCieślikLab4PD.Model;
using KamilCieślikLab4PD.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KamilCieślikLab4PD.Repository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : Entity
    {
        private readonly KamilCieślikLab4PDContext context;
        public WriteRepository(KamilCieślikLab4PDContext context)
        {
            this.context = context;
        }

        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void Edit(T entity, T updated)
        {
            context.Entry<T>(entity).CurrentValues.SetValues(updated);
            context.Entry<T>(entity).Property(o => o.ID).IsModified = false;

            context.SaveChanges();
        }

     
    }
}
