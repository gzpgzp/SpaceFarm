
using System;
using System.Collections.Generic;
using Script.Models;

namespace Script
{
    public class EntryManage
    {
        private Dictionary<string, Func<Entry>> entryCreators = new Dictionary<string, Func<Entry>>();
        public void InitEntryManage()
        {
            // 注册内置词条类型
            RegisterEntryType("winter_only_germination", () => new WinterOnlyGerminationEntry());
            RegisterEntryType("attack_boost", () => new HeathAddEntry(0.2f)); // 默认+20%生命
        }

        public void RegisterEntryType(string entryId, Func<Entry> creator)
        {
            entryCreators[entryId] = creator;
        }


        public class WinterOnlyGerminationEntry : BaseEntry
        {
            public WinterOnlyGerminationEntry()
            {
                ID = "winter_only_germination";
                Name = "寒冬孕育";
                Info = "此种子只能在冬季发芽";
            }

            public override Seed EntryEffectInit(Seed item)
            {
                Seed newSeed = item.Clone();
                newSeed.isOnlyWinter = true;
                return newSeed;
            }
        }

        // 具体词条示例：增加生命值
        public class HeathAddEntry : BaseEntry
        {
            private float multiplier;

            public HeathAddEntry(float _multiplier)
            {
                multiplier = _multiplier;
                ID = "Heath_Add";
                Name = "生命增加";
                Info = $"增加{multiplier * 100}%生命值";
            }

            public override Seed EntryEffectInit(Seed item)
            {
                Seed newSeed = item.Clone();
                newSeed.Health = (int)Math.Floor(newSeed.Health * multiplier);
                return newSeed;
            }
        }
    }
}