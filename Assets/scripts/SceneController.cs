using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using static EventManager;
using static StaticVariables;
using System.Collections.Generic;
using static EventManager;
using static StaticVariables;

public class SceneController : MonoBehaviour
{

    public bool isNews;
    public int contador;
    public int currentDiario = 0;
    bool detener;

    //audio
    public AudioSource audio;

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


        //lo mismo pero con el diario
        if (currentScene.name == "Nivel 1 Diario")
        {
            currentDiario = 1;
            isNews = true;
        }


        if (currentScene.name == "Nivel 2 Diario")
        {
            currentDiario = 2;
            isNews = true;
        }
        if (currentScene.name == "Nivel 3 Diario")
        {
            currentDiario = 3;
            isNews = true;
        }
        if (currentScene.name == "Nivel 4 Diario")
        {
            currentDiario = 4;
            isNews = true;
        }

        if (currentScene.name == "Nivel 5 Diario")
        {
            currentDiario = 5;
            isNews = true;
        }
        if (currentScene.name == "Nivel 6 Diario")
        {
            currentDiario = 6;
            isNews = true;
        }

        if (isNews)
        {
            StartCoroutine(DiarioTimer());
        }
    }

    IEnumerator DiarioTimer()
    {

            while (!detener)
            {
                contador++;
                yield return new WaitForSeconds(1f);
            }
    }   


    void Update()
    {

    }

    public void PasarNivel()
    {
        detener = true;
        if (currentDiario > 0)
        {
            EventManager.SafeLogEvent("News", new Dictionary<string, object> {
                {"level", currentDiario },
                {"time", contador }
                    });
        }
        
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

    public void OnButtonMute ()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }
        else
        {
            audio.Play();
        }
    }
}