using System.Collections.Generic;
using Core.Plant.Entry;

namespace Core.Plant
{
    public class Seed
    {
        public string name { get; set; }
        public int id { get; set; }
        public List<Entry.Entry> entries { get; set; }

        public float production { get; set; } // 产量
        public int growthCostTime { get; set; } // 成长时间
        public float growthRate { get; set; } // 成长速率
    }
}