using ArchiTool.ArchiToolLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiToolLogic.Repository
{
    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        public List<T> Dimensions { get; set; }

        public InMemoryRepository(List<T> dimensions)
        {
            Dimensions = dimensions;
        }

        public void Add(T entity)
        {
            Dimensions.Add(entity);
        }

        public void Delete(T entity)
        {
            if (Dimensions.Contains(entity))
            {
                Dimensions.Remove(entity);
            }
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(T entity, int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return Dimensions;
        }

        public void ClearAll()
        {
            Dimensions.Clear();
        }

    }
}
