using UnityEngine;
using UnityEngine.SceneManagement;
using static EventManager;
using static StaticVariables;
using System.Collections.Generic;


public class SceneController : MonoBehaviour
{
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        //dialogos
        if (currentScene.name == "Nivel 1 Dialogo")
        {
            EventManager.Instance.LogEvent("Talk", new Dictionary<string, object> {
    { "level", 1 }
    });
        }
        if (currentScene.name == "Nivel 2 Dialogo")
        {
            EventManager.Instance.LogEvent("Talk", new Dictionary<string, object> {
    { "level", 2 }
    });
            if (currentScene.name == "Nivel 3 Dialogo")
            {
                EventManager.Instance.LogEvent("Talk", new Dictionary<string, object> {
    { "level", 3 }
    });
            }

            if (currentScene.name == "Nivel 4 Dialogo")
            {
                EventManager.Instance.LogEvent("Talk", new Dictionary<string, object> {
    { "level", 4 }
    });
            }
            if (currentScene.name == "Nivel 5 Dialogo")
            {
                EventManager.Instance.LogEvent("Talk", new Dictionary<string, object> {
    { "level", 5 }
    });
            }

            if (currentScene.name == "Nivel 6 Dialogo")
            {
                EventManager.Instance.LogEvent("Talk", new Dictionary<string, object> {
    { "level", 6 }
    });
            }
        }

        // finales
        if (currentScene.name == "Nivel 1 Final Bueno")
        {
            EventManager.Instance.LogEvent("LevelComplete", new Dictionary<string, object> {
    { "level", 1 }
    });
            EventManager.Instance.LogEvent("End", new Dictionary<string, object> {
    { "level", 1 }
    });
        }
        if (currentScene.name == "Nivel 2 Final Bueno")
        {
            EventManager.Instance.LogEvent("LevelComplete", new Dictionary<string, object> {
    { "level", 2 }
    });
            EventManager.Instance.LogEvent("End", new Dictionary<string, object> {
    { "level", 2 }
    });
        }
        if (currentScene.name == "Nivel 3 Final Bueno")
        {
            EventManager.Instance.LogEvent("LevelComplete", new Dictionary<string, object> {
    { "level", 3 }
    });
            EventManager.Instance.LogEvent("End", new Dictionary<string, object> {
    { "level", 3 }
    });
        }
        if (currentScene.name == "Nivel 4 Final Bueno")
        {
            EventManager.Instance.LogEvent("LevelComplete", new Dictionary<string, object> {
    { "level", 4 }
    });
            EventManager.Instance.LogEvent("End", new Dictionary<string, object> {
    { "level", 4 }
    });
        }

        if (currentScene.name == "Nivel 5 Final Bueno")
        {
            EventManager.Instance.LogEvent("LevelComplete", new Dictionary<string, object> {
    { "level", 5 }
    });
            EventManager.Instance.LogEvent("End", new Dictionary<string, object> {
    { "level", 5 }
    });
        }
        if (currentScene.name == "Nivel 6 Final Bueno")
        {
            EventManager.Instance.LogEvent("LevelComplete", new Dictionary<string, object> {
    { "level", 6 }
    });
            EventManager.Instance.LogEvent("End", new Dictionary<string, object> {
    { "level", 6 }
    });
        }
    }
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Scene1");
        }

        /*if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Scene2");
        }*/
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
