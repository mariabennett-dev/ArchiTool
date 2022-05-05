using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchiTool.ArchiToolLogic.Models;

namespace ArchiToolLogic.Repository
{
    public class InMemoryConversionCalcHistory: InMemoryRepository<Equation>, ICalcHistoryRepository
    {
        public InMemoryConversionCalcHistory(List<Equation> equations) : base(equations)
        { }

        public new void Delete(int Id)
        {
            for (int i = 0; i < Dimensions.Count; i++)
            {
                if (Dimensions[i].Id == Id)
                {
                    Dimensions.Remove(Dimensions[i]);
                }
            }
        }
        void ICalcHistoryRepository.Edit(Equation entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
