using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopFinalBueno : MonoBehaviour
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

        if (Input.GetKeyDown(KeyCode.Space)) // 0 = clic izquierdo
        {
            Debug.Log("Se hizo el espacio");
            Amongas();
        }

    }



    private void Amongas()
    {
        ImagenA.SetActive(true);
        gameObject.SetActive(false);
    }

    }
