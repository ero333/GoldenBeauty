using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disabler : MonoBehaviour
{
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


        if (menuPausa.activeSelf)
        {
            siguiente.SetActive(false);
            maus.SetActive(false);
            botonPausa.SetActive(false);
            wl.SetActive(false);
        }
        else
        {
            maus.SetActive (true);
            siguiente.SetActive(true);
            maus.SetActive(true);
            botonPausa.SetActive(true);
            wl.SetActive(true);
        }

	//if (wl.activeSelf) {
	//siguiente.SetActive(false);
           // maus.SetActive(false);
	//}

        if (!siguiente.activeInHierarchy)
        {
            botonPausa.SetActive(false);
        }
    }
}
