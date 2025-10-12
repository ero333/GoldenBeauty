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

    private void Awake() //al empezar nivel
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //para que se mantenga entre escenas
            //await InitializeUnityServices();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*
    private async Task InitializeUnityServices()
    {
        try
        {
            await UnityServices.InitializeAsync(); //esperar a q se conecte
            Debug.Log("Unity Services iniciado");
            _isInitialized = true;
        }
        catch
        {
 
        }
    }
    public void GiveConsent() //lo asigno a un boton
    {
        if (!_isInitialized)
        {
            Debug.LogWarning("Unity Services no iniciado");
            return;
        }

        _consentGiven = true;
        Debug.Log("Consentimiento dado");
    }

    private bool CanSendEvents()
    {
        if (!_isInitialized)
        {
            Debug.LogWarning("Unity Services no inició");
            return false;
        }

        if (!_consentGiven)
        {
            Debug.LogWarning("No se dio consentimiento");
            return false;
        }

        return true;
    }
    */

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