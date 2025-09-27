using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class Services : MonoBehaviour
{
    // Start is called before the first frame update
    async void Awake ()
    {
        await UnityServices.InitializeAsync();

        if (Input.GetKey("n"))
        {
            AnalyticsService.Instance.StartDataCollection();
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
