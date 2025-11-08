using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disabler : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject siguiente;
    public GameObject botonPausa;
    public GameObject menuPausa;
    public GameObject maus;
    public GameObject wl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial.activeSelf)
        {
            siguiente.SetActive(false);
            botonPausa.SetActive(false);
            maus.SetActive(false);
        }
        else
        {
            siguiente.SetActive(true);
            botonPausa.SetActive(true);
            maus.SetActive(true);
        }

        if (menuPausa.activeSelf)
        {
            siguiente.SetActive(false);
            maus.SetActive(false);
            botonPausa.SetActive(false);
            wl.SetActive(false);
        }
        else
        {
            siguiente.SetActive(true);
            botonPausa.SetActive(true);
            wl.SetActive(true);
        }

        if (!siguiente.activeInHierarchy)
        {
            botonPausa.SetActive(false);
        }
    }
}
