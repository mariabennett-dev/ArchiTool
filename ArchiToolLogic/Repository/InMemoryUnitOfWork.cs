using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchiTool.ArchiToolLogic.Models;

namespace ArchiToolLogic.Repository
{
    public class InMemoryUnitOfWork : IInMemoryUnitOfWork
    {
        private bool disposedValue;

        public IRoofDimensionsRepository HistoryRoofDimensions { get; set; }

        public RoofDimensions RoofDimensions { get; set; }
        public Calculator Calculator { get; set; }

        public ICalcHistoryRepository ConversionCalcHistory { get; set; }

        public InMemoryUnitOfWork()
        {
            List<RoofDimensions> roofDimensions= new List<RoofDimensions>();
            List<Equation> equations = new List<Equation>();
            HistoryRoofDimensions = new InMemoryRoofDimensionsRepository(roofDimensions);
            ConversionCalcHistory = new InMemoryConversionCalcHistory(equations);
            RoofDimensions = new RoofDimensions();
            Calculator = new Calculator();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach (var item in HistoryRoofDimensions.GetAll().ToList())
                    {
                        HistoryRoofDimensions.Delete(item.Id);
                    }
                    HistoryRoofDimensions = null;
                    RoofDimensions = null; 
                    Calculator = null;
                }

                disposedValue = true;
            }
        }

        //TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
         ~InMemoryUnitOfWork()
         {
             // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
         }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
