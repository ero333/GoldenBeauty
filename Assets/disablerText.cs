using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disablerText : MonoBehaviour
{
    public GameObject siguiente;
    public GameObject botonPausa;
    public GameObject menuPausa;
    public GameObject cajaDialogo1;
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
            botonPausa.SetActive(false);
            cajaDialogo1 .SetActive(false);
        }
        else
        {
            siguiente.SetActive(true);
            botonPausa.SetActive(true);
            cajaDialogo1 .SetActive(true);
        }
    }
}
