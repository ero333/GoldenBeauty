using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using AnalyticsEventBase = Unity.Services.Analytics.Event;
using System.Linq;

public class EventManager : MonoBehaviour
{
    // Singleton (opcional, para llamarlo desde cualquier script)
    public static EventManager Instance { get; private set; }

    async void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            await UnityServices.InitializeAsync();
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
            {
                customEvent[kv.Key] = kv.Value;
            }

            // 🔍 Log de depuración
            Debug.Log($"[Analytics] Enviando evento: {eventName} con parámetros: {string.Join(", ", parameters.Select(kv => $"{kv.Key}: {kv.Value}"))}");
        }
        else
        {
            Debug.Log($"[Analytics] Enviando evento: {eventName} sin parámetros.");
        }

        AnalyticsService.Instance.RecordEvent(customEvent);
        AnalyticsService.Instance.Flush();
    }

    // 🚨 ESTE MÉTODO DEBE IR AQUÍ, no dentro de AnalyticsEvents
    public void LogLevelStart(int level)
    {
        var ev = AnalyticsEvents.CreateLevelStartEvent(level);
        AnalyticsService.Instance.RecordEvent(ev);
        AnalyticsService.Instance.Flush();
    }

    public void LogLevelComplete(int level)
    {
        var ev = new CustomEvent("LevelComplete");
        ev["level"] = level;
        AnalyticsService.Instance.RecordEvent(ev);
        AnalyticsService.Instance.Flush();
    }
    public void LogCalificar(int arte, int historia, int diversion)
    {
        var ev = AnalyticsEvents.CreateCalificarEvent(arte, historia, diversion);
        AnalyticsService.Instance.RecordEvent(ev);
        AnalyticsService.Instance.Flush();
    }


    public static class AnalyticsEvents
    {
        public static CustomEvent CreateLevelStartEvent(int level)
        {
            var ev = new CustomEvent("LevelStart");
            ev["level"] = level;
            return ev;
        }

        public static CustomEvent CreateLevelCompleteEvent(int level)
        {
            var ev = new CustomEvent("LevelComplete");
            ev["level"] = level;
            return ev;
        }

        public static CustomEvent CreateCalificarEvent(int? art = null, int? lore = null, int? fun = null)
        {
            var ev = new CustomEvent("Rate");
            if (art.HasValue) ev["art"] = art.Value;
            if (lore.HasValue) ev["lore"] = lore.Value;
            if (fun.HasValue) ev["fun"] = fun.Value;
            return ev;
        }


    }

}