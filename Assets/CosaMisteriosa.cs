using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CosaMisteriosa : MonoBehaviour
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
        VerificarPerfects();
    }

    void VerificarPerfects()
    {
        // Nivel 1
        if (PlayerPrefs.GetInt("Nivel1_Perfect", 0) == 1)
            recuadroNivel1.SetActive(false);

        // Nivel 2
        if (PlayerPrefs.GetInt("Nivel2_Perfect", 0) == 1)
            recuadroNivel2.SetActive(false);

        // Nivel 3
        if (PlayerPrefs.GetInt("Nivel3_Perfect", 0) == 1)
            recuadroNivel3.SetActive(false);

        // Nivel 4
        if (PlayerPrefs.GetInt("Nivel4_Perfect", 0) == 1)
            recuadroNivel4.SetActive(false);

        // Nivel 5
        if (PlayerPrefs.GetInt("Nivel5_Perfect", 0) == 1)
            recuadroNivel5.SetActive(false);

        // Nivel 6
        if (PlayerPrefs.GetInt("Nivel6_Perfect", 0) == 1)
            recuadroNivel6.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
