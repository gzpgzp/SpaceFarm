using System.Collections.Generic;
using ResourceManger;
using Tools;
using UnityEngine;

namespace Core.Plant
{
    public class PlantManager : MMEventListener<SoilClickEvent>
    {
        private List<PlantEntity> plantEntities = new List<PlantEntity>();
        private List<Seed> seeds = new List<Seed>();
        private Seed currentSeed = new Seed();
        private WorldContext worldContext;

        public void Init(WorldContext worldContext)
        {
            this.worldContext = worldContext;
            this.MMEventStartListening<SoilClickEvent>();
        }

        public void Stop()
        {
            this.MMEventStopListening<SoilClickEvent>();
        }

        public void OnMMEvent(SoilClickEvent e)
        {
            Debug.Log("On MM Event");
            if (e.isPlanted)
            {
                
            }
            else
            {
                PlantPlant(e.soil);
            }
        }

        public void Update()
        {
            foreach (PlantEntity plantEntity in plantEntities)
            {
                plantEntity.Update(worldContext.time);
            }
        }

        private void PlantPlant(Soil soil)
        {
            currentSeed = new Seed()
            {
                growthCostTime = 10,
                id = 1,
                name = "Cube",
            };//TODO 删除
            
            var plantContext = new PlantContext()
            {
                seed = currentSeed,
                startTime = worldContext.time,
                isHarvested = false,
            };
            var plantEntity = new PlantEntity(plantContext);
            var plantObj = ResourcesManager.Instance.LoadAndInstantiate($"Prefabs/Plants/Plant_{currentSeed.name}");
            var plant = plantObj.GetComponent<Plant>();
            plantEntity.BindView(plant);
            
            soil.Planting(plant);
            
            plantEntities.Add(plantEntity);
        }
    }
}