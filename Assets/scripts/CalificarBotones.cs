using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;
using static StaticVariables;

public class CalificarBotones : MonoBehaviour
{
    public int califArt = 0;
    public int califLore = 0;
    public int califFun = 0;
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
   
        califArt = 1;
    }
    public void Button2Arte()
    {

        califArt = 2;
    }
    public void Button3Arte()
    {
   
        califArt = 3;
    }
    public void Button4Arte()
    {
  
        califArt = 4;
    }
    public void Button5Arte()
    {

        califArt = 5;
    }

    public void Button1Story()
    {
  
        califLore = 1;
    }
    public void Button2Story()
    {

        califLore = 2;
    }
    public void Button3Story()
    {
 
        califLore = 3;
    }
    public void Button4Story()
    {

        califLore = 4;
    }
    public void Button5Story()
    {

    califLore = 5;
    }
    public void Button1Fun()
    {

    califFun = 1;
    }
    public void Button2Fun()
    {

    califFun = 2;
    }
    public void Button3Fun()
    {

    califFun = 3;
    }
    public void Button4Fun()
    {

    califFun = 4;
    }
    public void Button5Fun()
    {
        /*EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "fun", 5 }
    });*/
        califFun = 5;
    }

    public void SendRate()
    {
        EventManager.Instance.LogEvent("Rate", new Dictionary<string, object> {
    { "art", califArt },
     { "lore",  califLore },
    { "fun", califFun}
    });
    }
}
