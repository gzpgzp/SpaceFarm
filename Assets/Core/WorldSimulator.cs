using System;
using System.Collections;
using System.Collections.Generic;
using Core.Plant;
using UnityEngine;

namespace Core
{
    public class WorldSimulator
    {
        private WorldContext worldContext;
        private PlantManager plantManager;
        
        public void InitWorld(WorldContext context)
        {
            Debug.Log("Initializing World");
            worldContext = context;
            plantManager = new PlantManager();
        }
        
        // 每秒更新一次
        public void Update()
        {
            worldContext.time += 1;
            plantManager.Update(worldContext.time);
        }

        public int GetNowTime()
        {
            return worldContext.time;
        }
    }
}
