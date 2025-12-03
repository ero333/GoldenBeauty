using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EventManager;
using static StaticVariables;

public class NivelesCompletadosPerfectos : MonoBehaviour
{

    public GameObject recuadroNivel1;
    public GameObject recuadroNivel2;
    public GameObject recuadroNivel3;
    public GameObject recuadroNivel4;
    public GameObject recuadroNivel5;
    public GameObject recuadroNivel6;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(VerificarRetraso());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator VerificarRetraso()
    {
        yield return new WaitForSeconds(1.5f);
        VerificarPerfects();
    }
    void VerificarPerfects()
    {
        // Nivel 1
        if (!recuadroNivel1.activeInHierarchy)
        {
            EventManager.SafeLogEvent("Perfect", new Dictionary<string, object> {
                    { "level", 1 }
                    });
        }

        // Nivel 2
        if (!recuadroNivel2.activeInHierarchy)
        {
            EventManager.SafeLogEvent("Perfect", new Dictionary<string, object> {
                    { "level", 2 }
                    });
        }

        // Nivel 3
        if (!recuadroNivel3.activeInHierarchy)
        {
            EventManager.SafeLogEvent("Perfect", new Dictionary<string, object> {
                    { "level", 3 }
                    });
        }

        // Nivel 4
        if (!recuadroNivel4.activeInHierarchy)
        {
            EventManager.SafeLogEvent("Perfect", new Dictionary<string, object> {
                    { "level", 4 }
                    });
        }

        // Nivel 5
        if (!recuadroNivel5.activeInHierarchy)
        {
            EventManager.SafeLogEvent("Perfect", new Dictionary<string, object> {
                    { "level", 5 }
                    });
        }

        // Nivel 6
        if (!recuadroNivel6.activeInHierarchy)
        {
            EventManager.SafeLogEvent("Perfect", new Dictionary<string, object> {
                    { "level", 6 }
                    });
        }

        // CuadroDesbloqueado
        if (!recuadroNivel6.activeInHierarchy && !recuadroNivel5.activeInHierarchy && !recuadroNivel4.activeInHierarchy && !recuadroNivel3.activeInHierarchy && !recuadroNivel2.activeInHierarchy && !recuadroNivel1.activeInHierarchy)
        {
            EventManager.SafeLogEvent("Perfect", new Dictionary<string, object> {
                    { "level", 7 }
                    });
        }

    }
}
