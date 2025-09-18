using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{

    public GameObject menuDePausa;
    public GameObject fondoDePausa;
    public GameObject botonDePausa;

    public GameObject AnimacionMenuDePausa;

    public bool pausado;

    // Start is called before the first frame update
    void Start()
    {
        pausado = false;
    }

    // Update is called once per frame
    void Update()
    {

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
        SceneManager.LoadScene("Menu inicio");
    }

}
