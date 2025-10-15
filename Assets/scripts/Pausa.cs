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
    // Start is called before the first frame update
    void Start()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
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
        AnimacionMenuDePausa.SetActive(true);
        botonDePausa.SetActive(false);
    }

    public void DesPausar()
    {
        menuDePausa.SetActive(false);
        botonDePausa.SetActive(true);
        fondoDePausa.SetActive(false);
    }

    public void VolverAlInicio()
    {
        detener = false;
        if (isEnd)
        {
            EventManager.SafeLogEvent("End", new Dictionary<string, object> {
                    { "time", contador }
                    });
        }
        
        SceneManager.LoadScene("Menu inicio");
    }
    public void OnButtonClick ()
    {
        Alerta.SetActive(true);
    }
    public void OnButton2Click ()
    {
        Alerta.SetActive(false);
    }

}
