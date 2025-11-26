using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntajesDelosNiveles : MonoBehaviour
{
    public GameObject recuadroNivel1;
    public GameObject recuadroNivel2;
    public GameObject recuadroNivel3;
    public GameObject recuadroNivel4;
    public GameObject recuadroNivel5;
    public GameObject recuadroNivel6;

    // Start is called before the first frame update
    private void Start()
    {
        VerificarPerfects();
    }

    void VerificarPerfects()
    {
        // Nivel 1
        if (PlayerPrefs.GetInt("Nivel1_Perfect", 0) == 1)
            recuadroNivel1.SetActive(true);

        // Nivel 2
        if (PlayerPrefs.GetInt("Nivel2_Perfect", 0) == 1)
            recuadroNivel2.SetActive(true);

        // Nivel 3
        if (PlayerPrefs.GetInt("Nivel3_Perfect", 0) == 1)
            recuadroNivel3.SetActive(true);

        // Nivel 4
        if (PlayerPrefs.GetInt("Nivel4_Perfect", 0) == 1)
            recuadroNivel4.SetActive(true);

        // Nivel 5
        if (PlayerPrefs.GetInt("Nivel5_Perfect", 0) == 1)
            recuadroNivel5.SetActive(true);

        // Nivel 6
        if (PlayerPrefs.GetInt("Nivel6_Perfect", 0) == 1)
            recuadroNivel6.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
