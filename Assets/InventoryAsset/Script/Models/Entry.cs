using System;

namespace Script.Models
{
    public interface Entry
    {
        /// <summary>
        /// 词条ID
        /// </summary>
        string ID { get;}
        
        /// <summary>
        /// 词条名称
        /// </summary>
        string Name { get;}
        
        /// <summary>
        /// 词条级别
        /// </summary>
        RankEnum EntryRankEnum { get;}
        
        /// <summary>
        /// 词条信息
        /// </summary>
        string Info { get;}
        
        /// <summary>
        /// 词条效果赋予
        /// </summary>
        Seed EntryEffectInit(Seed item);
    }
    
    // 词条基类，实现通用功能
    public abstract class BaseEntry : Entry
    {
        public string ID { get; protected set; }
        public string Name { get; protected set; }
        public string Info { get; protected set; }
        public RankEnum EntryRankEnum { get; protected set; }

        public virtual Seed EntryEffectInit(Seed item)
        {
            return item;
        }
    }
}