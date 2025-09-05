using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStyles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //toma la pos del mouse
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetMouseButtonUp(0))
        {
            

        }
    }
}
