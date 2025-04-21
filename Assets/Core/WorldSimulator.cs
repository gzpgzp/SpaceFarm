using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class WorldSimulator
    {
        public WorldContext context;
        
        public void InitWorld(WorldContext context)
        {
            Debug.Log("Initializing World");
            this.context = context;
        }
        
        // 每秒更新一次
        public void Update()
        {
            context.time += 1;
            Debug.Log(context.time);
        }
    }
}
