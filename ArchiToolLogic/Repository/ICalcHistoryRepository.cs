using System.Collections.Generic;
using ArchiTool.ArchiToolLogic.Models;

namespace ArchiToolLogic.Repository
{
    public interface ICalcHistoryRepository : IRepository<Equation>
    {
        void Add(Equation entity);
        void Delete(Equation entity);
        void Edit(Equation entity, int id);
        IEnumerable<Equation> GetAll();
    }
}