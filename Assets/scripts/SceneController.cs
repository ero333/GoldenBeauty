using UnityEngine;
using UnityEngine.SceneManagement;
using static EventManager;
using static StaticVariables;
using System.Collections.Generic;
using static EventManager;
using static StaticVariables;

public class SceneController : MonoBehaviour
{
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // finales
        if (currentScene.name == "Nivel 1 Final Bueno")
        {
            EventManager.SafeLogEvent("End", new Dictionary<string, object> {
                    { "level", 1 }
                    });
        }


        if (currentScene.name == "Nivel 2 Final Bueno")
        {
            EventManager.SafeLogEvent("End", new Dictionary<string, object> {
                    { "level", 2 }
                    });
        }
        if (currentScene.name == "Nivel 3 Final Bueno")
        {
            EventManager.SafeLogEvent("End", new Dictionary<string, object> {
                    { "level", 3 }
                    });
        }
        if (currentScene.name == "Nivel 4 Final Bueno")
        {
            EventManager.SafeLogEvent("End", new Dictionary<string, object> {
                    { "level", 4 }
                    });
        }

        if (currentScene.name == "Nivel 5 Final Bueno")
        {
            EventManager.SafeLogEvent("End", new Dictionary<string, object> {
                    { "level", 5 }
                    });
        }
        if (currentScene.name == "Nivel 6 Final Bueno")
        {
            EventManager.SafeLogEvent("End", new Dictionary<string, object> {
                    { "level", 6 }
                    });
        }
    }
    void Update()
    {

    }

    public void PasarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PerderNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}