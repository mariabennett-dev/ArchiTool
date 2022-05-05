using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiToolLogic.Repository
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public void Add(T entity);
        public void Delete(T entity);
        public void Delete(int Id);
        public void Edit(T entity, int Id);
        public void ClearAll();
    }
}
