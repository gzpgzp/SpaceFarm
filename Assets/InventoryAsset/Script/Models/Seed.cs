using Newtonsoft.Json;
using System.Collections.Generic;

namespace Script.Models
{
    public class Seed
    {
        /// <summary>
        /// 种子ID
        /// </summary>
        public string SeedId { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Info { get; set; }
        
        /// <summary>
        /// 稀有度等级
        /// </summary>
        public RankEnum SeedRank { get; set; }
        
        /// <summary>
        /// 植物类型
        /// </summary>
        public PlantTypeEnum PlantType { get; set; }
        
        /// <summary>
        /// 阶段数量
        /// </summary>
        public int StageNumber { get; set; }
        
        /// <summary>
        /// 每日生长值
        /// </summary>
        public int GrowTime { get; set; }
        
        /// <summary>
        /// 每日生长值
        /// </summary>
        public int TotalGrowthValue { get; set; }
        
        /// <summary>
        /// 产量
        /// </summary>
        public int Production { get; set; }
        
        /// <summary>
        /// 发芽率
        /// </summary>
        public int GerminationPercentage { get; set; }
        
        /// <summary>
        /// 生命值
        /// </summary>
        public int Health { get; set; }
        
        /// <summary>
        /// 词条列表
        /// </summary>
        public List<Entry> Entries { get; set; }
        
        public bool isOnlyWinter { get; set; }
        
        public Seed Clone()
        {
            return JsonConvert.DeserializeObject<Seed>(JsonConvert.SerializeObject(this));
        }
    }
}