using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;
using static StaticVariables;

public class CalificarBotones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button1Arte ()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "arte", 1 }
    });

        Debug.Log("wow");
    }
    public void Button2Arte()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "arte", 2 }
});

    }
    public void Button3Arte()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "arte", 3 }
});

    }
    public void Button4Arte()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "arte", 4 }
});

    }
    public void Button5Arte()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "arte", 5 }
});

    }

    public void Button1Story()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "historia", 1 }
    });
    }
    public void Button2Story()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "historia", 2 }
    });
    }
    public void Button3Story()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "historia", 3 }
    });
    }
    public void Button4Story()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "historia", 4 }
    });
    }
    public void Button5Story()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "historia", 5 }
    });
    }
    public void Button1Fun()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "diversion", 1 }
    });
    }
    public void Button2Fun()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "diversion", 2 }
    });
    }
    public void Button3Fun()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "diversion", 3 }
    });
    }
    public void Button4Fun()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "diversion", 4 }
    });
    }
    public void Button5Fun()
    {
        EventManager.Instance.LogEvent("calificar", new Dictionary<string, object> {
    { "diversion", 5 }
    });
    }
}
