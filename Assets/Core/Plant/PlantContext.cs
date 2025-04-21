using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Plant
{
    public class PlantContext
    {
        public int growthCostTime { get; set; }

        public int startTime { get; set; }
        public int harvestTime
        {
            get
            {
                return startTime + growthCostTime;;
            }
        }
    
        public bool isHarvested { get; set; }
    }
}

