using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class WorldSimulator
    {
        public WorldContext worldContext;
        
        public void InitWorld(WorldContext context)
        {
            Debug.Log("Initializing World");
            this.worldContext = context;
        }
        
        // 每秒更新一次
        public void Update()
        {
            worldContext.time += 1;
            Debug.Log(worldContext.time);
        }

        public int GetNowTime()
        {
            return worldContext.time;
        }
    }
}
