using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static StaticVariables;
using static EventManager;

public class Pausa : MonoBehaviour
{

    public GameObject menuDePausa;
    public GameObject fondoDePausa;
    public GameObject botonDePausa;
    public GameObject Alerta;

    public GameObject AnimacionMenuDePausa;

    public bool pausado;

    //analytics
    public int currentLevel;
    bool isEnd;
    public int contador = 0;
    public bool detener = false;
    private int seccion = 0;
    //sonido
    public AudioSource sonido;
    public AudioClip sonido1;
    public AudioClip sonido2;
    // Start is called before the first frame update
    void Start()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        if ((currentScene.name == "Nivel 1 Dialogo") || (currentScene.name == "Nivel 1 Estilizar"))
        {
            currentLevel = 1;
        }
        else if ((currentScene.name == "Nivel 2 Dialogo") || (currentScene.name == "Nivel 2 Estilizar"))
        {
            currentLevel = 2;
        }
        else if ((currentScene.name == "Nivel 3 Dialogo") || (currentScene.name == "Nivel 3 Estilizar"))
        {
            currentLevel = 3;
        }
        else if ((currentScene.name == "Nivel 4 Dialogo") || (currentScene.name == "Nivel 4 Estilizar"))
        {
            currentLevel = 4;
        }
        else if ((currentScene.name == "Nivel 5 Dialogo") || (currentScene.name == "Nivel 5 Estilizar"))
        {
            currentLevel = 5;
        }
        else if ((currentScene.name == "Nivel 6 Dialogo") || (currentScene.name == "Nivel 6 Estilizar"))
        {
            currentLevel = 6;
        }

        if ((currentScene.name == "Nivel 1 Final Bueno") || (currentScene.name == "Nivel 2 Final Bueno") || (currentScene.name == "Nivel 3 Final Bueno") || (currentScene.name == "Nivel 4 Final Bueno") || (currentScene.name == "Nivel 5 Final Bueno") || (currentScene.name == "Nivel 6 Final Bueno") ||
            (currentScene.name == "Nivel 1 Final Malo") || (currentScene.name == "Nivel 2 Final Malo") || (currentScene.name == "Nivel 3 Final Malo") || (currentScene.name == "Nivel 4 Final Malo") || (currentScene.name == "Nivel 5 Final Malo") || (currentScene.name == "Nivel 6 Final Malo"))
        {
            currentLevel = 1;
            isEnd = true;
            Debug.Log("es un final");
            StartCoroutine(FinalesTimer());
        }
        else
        {
            isEnd = false;
        }
            pausado = false;

        if ((currentScene.name == "Nivel 1 Estilizar") || (currentScene.name == "Nivel 2 Estilizar") || (currentScene.name == "Nivel 3 Estilizar") || (currentScene.name == "Nivel 4 Estilizar") || (currentScene.name == "Nivel 5 Estilizar") || (currentScene.name == "Nivel 6 Estilizar"))
        {
            seccion = 1;
        }
        else
        {
            seccion = 0;
        }
    }

    IEnumerator FinalesTimer()
    {
        while (!detener)
        {
            contador++;
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
        {
            
            //cronometrar
        }
    }

    public void AbrirMenu()
    {
        menuDePausa.SetActive(true);
        fondoDePausa.SetActive(true);
        gameObject.SetActive(false);
    }

    public void AbrirMenu2()
    {
        sonido.PlayOneShot(sonido1);
        AnimacionMenuDePausa.SetActive(true);
        botonDePausa.SetActive(false);
    }

    public void DesPausar()
    {
        sonido.PlayOneShot(sonido1);
        menuDePausa.SetActive(false);
        botonDePausa.SetActive(true);
        fondoDePausa.SetActive(false);
    }

    public void VolverAlInicio()
    {
        detener = false;
        sonido.PlayOneShot(sonido1);
        if (isEnd)
        {
            EventManager.SafeLogEvent("End", new Dictionary<string, object> {
                    { "time", contador }
                    });
        }
        
        SceneManager.LoadScene("Menu inicio");
    }

    public void Salir()
    {
        detener = false;
        sonido.PlayOneShot(sonido1);

            EventManager.SafeLogEvent("Exit", new Dictionary<string, object> {
                    { "level", currentLevel },
                {"section", seccion }
                    });

        SceneManager.LoadScene("Menu inicio");
    }
    public void OnButtonClick ()
    {
        Alerta.SetActive(true);
        sonido.PlayOneShot(sonido1);
    }
    public void OnButton2Click ()
    {
        Alerta.SetActive(false);
        sonido.PlayOneShot(sonido2);
    }

    public void backSelect()
    {
        detener = false;
        sonido.PlayOneShot(sonido1);
        if (isEnd)
        {
            EventManager.SafeLogEvent("End", new Dictionary<string, object> {
                    { "time", contador }
                    });
        }

        SceneManager.LoadScene("LevelSelect");
    }
    }
