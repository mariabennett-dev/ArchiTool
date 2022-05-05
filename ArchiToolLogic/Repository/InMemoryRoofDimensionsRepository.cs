using ArchiTool.ArchiToolLogic.Models;
using System.Collections.Generic;
using System.Data;

namespace ArchiToolLogic.Repository
{
    public class InMemoryRoofDimensionsRepository : InMemoryRepository<RoofDimensions>, IRoofDimensionsRepository
    {
        public InMemoryRoofDimensionsRepository(List<RoofDimensions> dimensions) : base(dimensions)
        {
           
        }

        public new void Delete(int Id)
        {
            for(int i = 0; i < Dimensions.Count; i++)
            {
                if(Dimensions[i].Id == Id)
                {
                    Dimensions.Remove(Dimensions[i]);
                }
            }
        }
    }
}