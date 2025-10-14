using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

public class StartAnalytics : MonoBehaviour
{

    async void Start()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
        Debug.Log("Unity Services iniciado");

        //AskForConsent();
    }

    /*public void ConsentGiven()
    {
        
    }
    */
}
