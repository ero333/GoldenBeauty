using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;
using AnalyticsEvent = Unity.Services.Analytics.Event;

public class EventManager : MonoBehaviour
{
    public class LevelStartEvent : AnalyticsEvent
    {
        public LevelStartEvent() : base("LevelStart")
        {
        }
        public int level { set { SetParameter("level", value); } }
    }
}
