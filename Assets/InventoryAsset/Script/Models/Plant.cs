namespace Script.Models
{
    public class Plant
    {
        /// <summary>
        /// 种子信息
        /// </summary>
        public Seed Seed { get; set; }
        
        /// <summary>
        /// 阶段数量
        /// </summary>
        public int StageNumber{ get; set; }
        
        /// <summary>
        /// 每日生长值
        /// </summary>
        public int EveryDayGrowValue { get; set; }
        
        /// <summary>
        /// 每日生长值
        /// </summary>
        public int TotalGrowthValue { get; set; }
        
        /// <summary>
        /// 产量
        /// </summary>
        public int Production { get; set; }
        
        /// <summary>
        /// 生命值
        /// </summary>
        public int Health { get; set; }
    }
}