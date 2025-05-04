using Core.Time;
using Core.Plant;
using UnityEngine;

namespace Core
{
    public class WorldSimulator
    {
        private WorldContext worldContext;
        private PlantManager plantManager;
        private TimeManager timeManager;
        
        public void InitWorld(WorldContext context)
        {
            Debug.Log("Initializing World");
            worldContext = context;
            plantManager = new PlantManager();
            timeManager = new TimeManager();
            InitManager();
        }

        private void InitManager()
        {
            plantManager.Init(worldContext);
            timeManager.Init(worldContext);
        }

        // 每秒更新一次
        public void Update()
        {
            worldContext.time += 1;
            plantManager.Update();
            timeManager.Update();
        }

        public int GetNowTime()
        {
            return worldContext.time;
        }
    }
}
