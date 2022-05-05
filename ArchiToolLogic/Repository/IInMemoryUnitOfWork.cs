using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiToolLogic.Repository
{
    public interface IInMemoryUnitOfWork : IDisposable
    {
        public IRoofDimensionsRepository HistoryRoofDimensions { get; set; }
        public ICalcHistoryRepository ConversionCalcHistory { get; set; }
    }
}
