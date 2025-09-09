using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionGanar : MonoBehaviour
{

    public GameObject ImagenA;
    public GameObject ImagenB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarImagenes()
    {
        ImagenA.SetActive(true);
        ImagenB.SetActive(true);
        gameObject.SetActive(false);
    }
}
