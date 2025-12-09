using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    //private bool _isInitialized = false;
    //private bool _consentGiven = false;

    private void Awake() //al empezar nivel
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //para que se mantenga entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void LogEvent(string eventName, Dictionary<string, object> parameters = null)
    {

        var customEvent = new CustomEvent(eventName);

        if (parameters != null)
        {
            foreach (var kv in parameters)
                customEvent[kv.Key] = kv.Value;

            Debug.Log($"Enviandoo: {eventName} with parameters: {string.Join(", ", parameters.Select(kv => $"{kv.Key}: {kv.Value}"))}");
        }
        else
        {

        }

        AnalyticsService.Instance.RecordEvent(customEvent);
        AnalyticsService.Instance.Flush();
    }

    // nombres de los eventos

    public static void SafeLogEvent(string eventName, Dictionary<string, object> parameters)
    {
        if (Instance != null)
        {
            Instance.LogEvent(eventName, parameters);
        }
        else
        {
            Debug.LogWarning($"⚠️ No se pudo registrar el evento {eventName}: EventManager.Instance es null");
        }
    }

    public void LogLevelStart(int level)
    {
        var parameters = new Dictionary<string, object> { { "level", level } };
        LogEvent("LevelStart", parameters);

        CustomEvent LevelStartEvent = new CustomEvent("LevelStart")
        {
        { "level", level }

        };
        AnalyticsService.Instance.RecordEvent(LevelStartEvent);
        AnalyticsService.Instance.Flush();
    }

    public void LogLevelComplete(int level, int time, int hair, int face, int clothes, int acc)
    {
        var parameters = new Dictionary<string, object> { { "level", level }, { "time", time }, { "hair", hair }, { "face", face }, { "clothes", clothes }, { "accesories", acc } };
        LogEvent("LevelComplete", parameters);

        CustomEvent LevelCompleteEvent = new CustomEvent("LevelComplete")
        {
        { "level", level },
        { "time", time },
        { "hair", hair },
        { "face", face },
        { "clothes", clothes },
        { "accesories", acc }
        };
        AnalyticsService.Instance.RecordEvent(LevelCompleteEvent);
        AnalyticsService.Instance.Flush();
    }

    public void LogRate(int arte, int historia, int diversion)
    {
        var parameters = new Dictionary<string, object> { { "art", arte }, { "lore", historia }, { "fun", diversion } };
        LogEvent("Rate", parameters);

        CustomEvent RateEvent = new CustomEvent("Rate")
        {
            { "art", arte },
            { "lore", historia },
            { "fun", diversion }
        };
        AnalyticsService.Instance.RecordEvent(RateEvent);
        AnalyticsService.Instance.Flush();
    }

    public void LogTalk(int level, int question, int answer)
    {
        var parameters = new Dictionary<string, object> { { "level", level }, { "question", question }, { "answer", answer } };
        LogEvent("Talk", parameters);

        CustomEvent TalkEvent = new CustomEvent("Talk")
        {
            { "level", level },
            { "question", question },
            { "answer", answer }
        };
        AnalyticsService.Instance.RecordEvent(TalkEvent);
        AnalyticsService.Instance.Flush();
    }

    public void LogExit(int level, int section)
    {
        var parameters = new Dictionary<string, object> { { "level", level }, { "section", section } };
        LogEvent("Exit", parameters);

        CustomEvent ExitEvent = new CustomEvent("Exit")
        {
        { "level", level },
        { "section", section }

        };
        AnalyticsService.Instance.RecordEvent(ExitEvent);
        AnalyticsService.Instance.Flush();
    }

    public void LogSkipChat(int level)
    {
        var parameters = new Dictionary<string, object> { { "level", level } };
        LogEvent("SkipChat", parameters);

        CustomEvent SkipChatEvent = new CustomEvent("SkipChat")
        {
        { "level", level }

        };
        AnalyticsService.Instance.RecordEvent(SkipChatEvent);
        AnalyticsService.Instance.Flush();
    }


    public void LogNews(int level, int time)
    {
        var parameters = new Dictionary<string, object> { { "level", level }, { "time", time }};
        LogEvent("News", parameters);

        CustomEvent NewsEvent = new CustomEvent("News")
        {
        { "level", level },
        { "time", time }
        };
        AnalyticsService.Instance.RecordEvent(NewsEvent);
        AnalyticsService.Instance.Flush();
    }


    public void LogEnd(int level, int time)
    {
        var parameters = new Dictionary<string, object> { { "level", level }, { "time", time } };
        LogEvent("End", parameters);

        CustomEvent EndEvent = new CustomEvent("End")
        {
        { "level", level },
        { "time", time }
        };
        AnalyticsService.Instance.RecordEvent(EndEvent);
        AnalyticsService.Instance.Flush();
    }

    public void LogGameOver(int level, int time, int hair, int face, int clothes, int acc)
    {
        var parameters = new Dictionary<string, object> { { "level", level }, { "time", time }, { "hair", hair }, { "face", face }, { "clothes", clothes }, { "accesories", acc } };
        LogEvent("GameOver", parameters);

        CustomEvent GameOverEvent = new CustomEvent("GameOver")
        {
        { "level", level },
        { "time", time },
        { "hair", hair },
        { "face", face },
        { "clothes", clothes },
        { "accesories", acc }
        };
        AnalyticsService.Instance.RecordEvent(GameOverEvent);
        AnalyticsService.Instance.Flush();
    }

    public void LogPerfect(int level)
    {
        var parameters = new Dictionary<string, object> { { "level", level }};
        LogEvent("Perfect", parameters);

        CustomEvent RateEvent = new CustomEvent("Perfect")
        {
            { "level", level },
        };
        AnalyticsService.Instance.RecordEvent(RateEvent);
        AnalyticsService.Instance.Flush();
    }
}






