using System.Collections;
using System.Collections.Generic;
using Core.Base;
using UnityEngine;

namespace Core.Plant
{
    public class PlantEntity : Entity
    {
        private PlantContext context;
        private PlantView plantView;

        public void StartPlant(int now)
        {
            context.startTime = now;
            context.isHarvested = false;
        }

        public void HarvestPlant(int now)
        {
            
        }

        //todo 如果每个植物都有更新时间会不会太多了，但是如果把成熟这个时间放在外面又不好
        public void UpdateTtime(int now)
        {
            if (!context.isHarvested && now >= context.harvestTime)
            {
                context.isHarvested = true;
                
            }
        }

        public override void CreateEntity(int id,View view)
        {
            base.CreateEntity(id, view);
            plantView = view as PlantView;
        }
    }

}
