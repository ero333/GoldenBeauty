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
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "art", 1 }
    });

        Debug.Log("wow");
    }
    public void Button2Arte()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "art", 2 }
});

    }
    public void Button3Arte()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "art", 3 }
});

    }
    public void Button4Arte()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "art", 4 }
});

    }
    public void Button5Arte()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "art", 5 }
});

    }

    public void Button1Story()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "lore", 1 }
    });
    }
    public void Button2Story()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "lore", 2 }
    });
    }
    public void Button3Story()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "lore", 3 }
    });
    }
    public void Button4Story()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "lore", 4 }
    });
    }
    public void Button5Story()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "lore", 5 }
    });
    }
    public void Button1Fun()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "fun", 1 }
    });
    }
    public void Button2Fun()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "fun", 2 }
    });
    }
    public void Button3Fun()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "fun", 3 }
    });
    }
    public void Button4Fun()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "fun", 4 }
    });
    }
    public void Button5Fun()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "fun", 5 }
    });
    }
}
