using System.Collections.Generic;
using ResourceManger;

namespace Core.Plant
{
    public class PlantContext
    {
        public Seed seed { get; set; }

        public int startTime { get; set; }
        public int harvestTime
        {
            get
            {
                return startTime + seed.growthCostTime;;
            }
        }
    
        public bool isHarvested { get; set; }
    }
}