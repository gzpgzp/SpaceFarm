using System;
using Tools;
using UnityEngine;

namespace Core.Manager
{
    public class TimeDefine
    {
        public const int TimePerDay = 1440;
        public const int TimePerHour = 60;

        public const int MorningStartTime = 6; // 日出时间
        public const int EveningStartTime = 17; // 傍晚开始的小时
        public const int NightStartTime = 19; // 日落时间
    }

    public enum TimeType
    {
        None,
        Morning,
        Evening,
        Night,
    }

    public struct TimeChangeEvent
    {
        public TimeType timeType;

        public TimeChangeEvent(TimeType timeType)
        {
            this.timeType = timeType;
        }

        static TimeChangeEvent e;

        public static void Trigger(TimeType timeType)
        {
            e.timeType = timeType;
            MMEventManager.TriggerEvent(e);
        }
    }

    public class TimeManager
    {
        private WorldContext worldContext;
        private TimeType currTimeType;
        
        public void Init(WorldContext worldContext)
        {
            this.worldContext = worldContext;
            currTimeType = TimeType.None;
        }

        public void Update()
        {
            if (worldContext.time > TimeDefine.TimePerDay)
            {
                worldContext.day += 1;
                worldContext.time -= TimeDefine.TimePerDay;
            }

            var hour = worldContext.time / TimeDefine.TimePerHour;

            if (hour >= TimeDefine.MorningStartTime && hour <= TimeDefine.EveningStartTime)
            {
                ChangeTimeType(TimeType.Morning); 
            }
            else if (hour >= TimeDefine.MorningStartTime && hour <= TimeDefine.NightStartTime)
            {
                ChangeTimeType(TimeType.Evening);
            }
            else
            {
                ChangeTimeType(TimeType.Night);
            }
        }

        private void ChangeTimeType(TimeType timeType)
        {
            if (timeType != currTimeType)
            {
                currTimeType = timeType;
                TimeChangeEvent.Trigger(timeType);
                Debug.Log($"now is {timeType.ToString()}");
            }
        }
    }
}