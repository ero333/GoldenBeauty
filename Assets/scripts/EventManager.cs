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

    private bool _isInitialized = false;
    private bool _consentGiven = false;

    private async void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            await InitializeUnityServices();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private async Task InitializeUnityServices()
    {
        try
        {
            await UnityServices.InitializeAsync();
            Debug.Log("[Analytics] Unity Services initialized successfully.");
            _isInitialized = true;
        }
        catch (Exception e)
        {
            Debug.LogError($"[Analytics] Initialization failed: {e.Message}");
        }
    }

    public void GiveConsent()
    {
        if (!_isInitialized)
        {
            Debug.LogWarning("[Analytics] Unity Services not initialized yet. Try again later.");
            return;
        }

        _consentGiven = true;
        Debug.Log("[Analytics] User consent manually granted. Events can now be sent.");
    }

    private bool CanSendEvents()
    {
        if (!_isInitialized)
        {
            Debug.LogWarning("[Analytics] Unity Services not initialized yet.");
            return false;
        }

        if (!_consentGiven)
        {
            Debug.LogWarning("[Analytics] Consent not yet given by the user.");
            return false;
        }

        return true;
    }

    public void LogEvent(string eventName, Dictionary<string, object> parameters = null)
    {
        if (!CanSendEvents()) return;

        var customEvent = new CustomEvent(eventName);

        if (parameters != null)
        {
            foreach (var kv in parameters)
                customEvent[kv.Key] = kv.Value;

            Debug.Log($"[Analytics] Sending event: {eventName} with parameters: {string.Join(", ", parameters.Select(kv => $"{kv.Key}: {kv.Value}"))}");
        }
        else
        {
            Debug.Log($"[Analytics] Sending event: {eventName} without parameters.");
        }

        AnalyticsService.Instance.RecordEvent(customEvent);
        AnalyticsService.Instance.Flush();
    }

    // ---------- Standard Game Events ----------

    public void LogLevelStart(int level)
    {
        var parameters = new Dictionary<string, object> { { "level", level } };
        LogEvent("LevelStart", parameters);
    }

    public void LogLevelComplete(int level)
    {
        var parameters = new Dictionary<string, object> { { "level", level } };
        LogEvent("LevelComplete", parameters);
    }

    public void LogCalificar(int arte, int historia, int diversion)
    {
        var parameters = new Dictionary<string, object>
        {
            { "art", arte },
            { "lore", historia },
            { "fun", diversion }
        };
        LogEvent("Rate", parameters);
    }
}
