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


public class Ganaryperder : MonoBehaviour
{
    public SceneController sceneController;
    [Header("Accesorios Valores")] 
    public GameObject accesorio_1;
    public GameObject accesorio_2;
    public GameObject accesorio_3;
    
    public int ValorAccesorio_1;
    public int ValorAccesorio_2;
    public int ValorAccesorio_3;

    [Header("Pelo Valores")]
    public GameObject Pelo_1;
    public GameObject Pelo_2;
    public GameObject Pelo_3;

    public int ValorPelo_1;
    public int ValorPelo_2;
    public int ValorPelo_3;

    [Header("Rostro Valores")]
    public GameObject Rostro_1;
    public GameObject Rostro_2;
    public GameObject Rostro_3;

    public int ValorRostro_1;
    public int ValorRostro_2;
    public int ValorRostro_3;

    [Header("Ropa Valores")]
    public GameObject Ropa_1;
    public GameObject Ropa_2;
    public GameObject Ropa_3;

    public int ValorRopa_1;
    public int ValorRopa_2;
    public int ValorRopa_3;

    private int Suma_Final;
    public int Valordeganar;
    public bool GanarNivel;

    public GameObject botonGanar;
    public GameObject botonPerder;
    public GameObject botonSiguiente;
    //analytics
    public int currentLevel;
    int currentRopa;
    int currentRostro;
    int currentAcc;
    int currentPelo;
    public int contador = 0;
    public bool detener = false;


    //audio
    public AudioSource sonido;
    public AudioClip sonidoRostro;
    public AudioClip sonidoPelo;
    public AudioClip sonidoRopa;
    public AudioClip sonidoAcc;
    bool wasPelo1Active = false;
    bool wasPelo2Active = false;
    bool wasPelo3Active = false;
    bool wasRopa1Active = false;
    bool wasRopa2Active = false;
    bool wasRopa3Active = false;
    bool wasRostro1Active = false;
    bool wasRostro2Active = false;
    bool wasRostro3Active = false;
    bool wasAcc1Active = false;
    bool wasAcc2Active = false;
    bool wasAcc3Active = false;

    // Start is called before the first frame update
    void Start()
    {

        
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Nivel 1 Estilizar")
        {
            currentLevel = 1;
        }
        else if (currentScene.name == "Nivel 2 Estilizar")
        {
            currentLevel = 2;
        }
        else if (currentScene.name == "Nivel 3 Estilizar")
        {
            currentLevel = 3;
        }
        else if (currentScene.name == "Nivel 4 Estilizar")
        {
            currentLevel = 4;
        }
        else if (currentScene.name == "Nivel 5 Estilizar")
        {
            currentLevel = 5;
        }
        else if (currentScene.name == "Nivel 6 Estilizar")
        {
            currentLevel = 6;
        }

        StartCoroutine(EstilizarTimer());
    }

    IEnumerator EstilizarTimer()
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
        /*if (Input.GetKeyDown("2"))
        {
            sceneController.PasarNivel();
        }
        */

        if (accesorio_1.activeInHierarchy && !wasAcc1Active)
        {
            sonido.PlayOneShot(sonidoAcc);
        }
        wasAcc1Active = accesorio_1.activeInHierarchy;

        if (accesorio_2.activeInHierarchy && !wasAcc2Active)
        {
            sonido.PlayOneShot(sonidoAcc);
        }
        wasAcc2Active = accesorio_2.activeInHierarchy;

        if (accesorio_3.activeInHierarchy && !wasAcc3Active)
        {
            sonido.PlayOneShot(sonidoAcc);
        }
        wasAcc3Active = accesorio_3.activeInHierarchy;

        if (Pelo_1.activeInHierarchy && !wasPelo1Active)
        {
            sonido.PlayOneShot(sonidoPelo);
        }
        wasPelo1Active = Pelo_1.activeInHierarchy;

        if (Pelo_2.activeInHierarchy && !wasPelo2Active)
        {
            sonido.PlayOneShot(sonidoPelo);
        }
        wasPelo2Active = Pelo_2.activeInHierarchy;

        if (Pelo_3.activeInHierarchy && !wasPelo3Active)
        {
            sonido.PlayOneShot(sonidoPelo);
        }
        wasPelo3Active = Pelo_3.activeInHierarchy;

        if (Rostro_1.activeInHierarchy && !wasRostro1Active)
        {
            sonido.PlayOneShot(sonidoRostro);
        }
        wasRostro1Active = Rostro_1.activeInHierarchy;

        if (Rostro_2.activeInHierarchy && !wasRostro2Active)
        {
            sonido.PlayOneShot(sonidoRostro);
        }
        wasRostro2Active = Rostro_2.activeInHierarchy;

        if (Rostro_3.activeInHierarchy && !wasRostro3Active)
        {
            sonido.PlayOneShot(sonidoRostro);
        }
        wasRostro3Active = Rostro_3.activeInHierarchy;

        if (Ropa_1.activeInHierarchy && !wasRopa1Active)
        {
            sonido.PlayOneShot(sonidoRopa);
        }
        wasRopa1Active = Ropa_1.activeInHierarchy;


        if (Ropa_2.activeInHierarchy && !wasRopa2Active)
        {
            sonido.PlayOneShot(sonidoRopa);
        }
        wasRopa2Active = Ropa_2.activeInHierarchy;


        if (Ropa_3.activeInHierarchy && !wasRopa3Active)
        {
            sonido.PlayOneShot(sonidoRopa);
        }
        wasRopa3Active = Ropa_3.activeInHierarchy;

    }

    private IEnumerator aura()
    {
        //botonSiguiente.SetActive(false);
        botonSiguiente.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        if (accesorio_1.activeInHierarchy)
        {
            Suma_Final += ValorAccesorio_1;
            currentAcc = 1;
           // sonido.PlayOneShot(sonidoAcc);
        }

        if (accesorio_2.activeInHierarchy)
        {
            Suma_Final += ValorAccesorio_2;
            currentAcc = 2;
           // sonido.PlayOneShot(sonidoAcc);
        }

        if (accesorio_3.activeInHierarchy)
        {
            Suma_Final += ValorAccesorio_3;
            currentAcc = 3;
           // sonido.PlayOneShot(sonidoAcc);
        }

        if (Pelo_1.activeInHierarchy)
        {
            Suma_Final += ValorPelo_1;
            currentPelo = 1;
           // sonido.PlayOneShot(sonidoPelo);
        }

        if (Pelo_2.activeInHierarchy)
        {
            Suma_Final += ValorPelo_2;
            currentPelo = 2;
           // sonido.PlayOneShot(sonidoPelo);
        }

        if (Pelo_3.activeInHierarchy)
        {
            Suma_Final += ValorPelo_3;
            currentPelo = 3;
           // sonido.PlayOneShot(sonidoPelo);
        }

        if (Rostro_1.activeInHierarchy)
        {
            Suma_Final += ValorRostro_1;
            currentRostro = 1;
           // sonido.PlayOneShot(sonidoRostro);
        }

        if (Rostro_2.activeInHierarchy)
        {
            Suma_Final += ValorRostro_2;
            currentRostro = 2;
           // sonido.PlayOneShot(sonidoRostro);
        }

        if (Rostro_3.activeInHierarchy)
        {
            Suma_Final += ValorRostro_3;
            currentRostro = 3;
           // sonido.PlayOneShot(sonidoRostro);
        }

        if (Ropa_1.activeInHierarchy)
        {
            Suma_Final += ValorRopa_1;
            currentRopa = 1;
           // sonido.PlayOneShot(sonidoRopa);
        }

        if (Ropa_2.activeInHierarchy)
        {
            Suma_Final += ValorRopa_2;
            currentRopa = 2;
           // sonido.PlayOneShot(sonidoRopa);
        }

        if (Ropa_3.activeInHierarchy)
        {
            Suma_Final += ValorRopa_3;
            currentRopa = 3;
           // sonido.PlayOneShot(sonidoRopa);
        }

        if (Suma_Final > Valordeganar)
        {
            detener = true;
            GanarNivel = true;
            EventManager.SafeLogEvent("LevelComplete", new Dictionary<string, object> {
        { "level", currentLevel },
        {"time", contador },
        { "hair", currentPelo },
        { "clothes", currentRopa },
        {"face", currentRostro},
        {"accesories",  currentAcc}
        });
            Debug.Log("GANASTEEEEE");
            botonGanar.SetActive(true);
        }

        if (!GanarNivel)
        {
            
            EventManager.SafeLogEvent("GameOver", new Dictionary<string, object> {
        { "level", currentLevel },
        {"time", contador },
        { "hair", currentPelo },
        { "clothes", currentRopa },
        {"face", currentRostro},
        {"accesories",  currentAcc}
        });
            Debug.Log("perdiste");
            botonPerder.SetActive(true);

        }


    }

    public void Ganar()
    {
        StartCoroutine(aura());
        
    }

}
