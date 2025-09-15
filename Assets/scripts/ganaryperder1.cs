using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("2"))
        {
            sceneController.PasarNivel();
        }
    }

    private IEnumerator aura()
    {
        yield return new WaitForSeconds(0.5f);

        if (accesorio_1.activeInHierarchy)
        {
            Suma_Final += ValorAccesorio_1;
        }

        if (accesorio_2.activeInHierarchy)
        {
            Suma_Final += ValorAccesorio_2;
        }

        if (accesorio_3.activeInHierarchy)
        {
            Suma_Final += ValorAccesorio_3;
        }

        if (Pelo_1.activeInHierarchy)
        {
            Suma_Final += ValorPelo_1;
        }

        if (Pelo_2.activeInHierarchy)
        {
            Suma_Final += ValorPelo_2;
        }

        if (Pelo_3.activeInHierarchy)
        {
            Suma_Final += ValorPelo_3;
        }

        if (Rostro_1.activeInHierarchy)
        {
            Suma_Final += ValorRostro_1;
        }

        if (Rostro_2.activeInHierarchy)
        {
            Suma_Final += ValorRostro_2;
        }

        if (Rostro_3.activeInHierarchy)
        {
            Suma_Final += ValorRostro_3;
        }

        if (Ropa_1.activeInHierarchy)
        {
            Suma_Final += ValorRopa_1;
        }

        if (Ropa_2.activeInHierarchy)
        {
            Suma_Final += ValorRopa_2;
        }

        if (Ropa_3.activeInHierarchy)
        {
            Suma_Final += ValorRopa_3;
        }

        if (Suma_Final > Valordeganar)
        {
            GanarNivel = true;
            Debug.Log("GANASTEEEEE");
            botonGanar.SetActive(true);
        }

        if (!GanarNivel)
        {
            Debug.Log("perdiste");
            botonPerder.SetActive(true);

        }


    }

    public void Ganar()
    {
        StartCoroutine(aura());
        
    }
}
