using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herramientas : MonoBehaviour
{
    public GameObject selectedObject;
    Vector3 offset;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //lee la posicion del mouse
        mousePosition.z = 0;

        if (Input.GetMouseButtonDown(0)) //si hago click
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition); //localiza la posicion si cuadra

            if (targetObject) //si el colider es reconocido...
            {
                selectedObject = targetObject.transform.gameObject; //modifica su posicion
                offset = selectedObject.transform.position - mousePosition; //un offset opcional
            }
        }

        if (selectedObject) // lo mueve
        {
            selectedObject.transform.position = mousePosition + offset;
        }

        if (Input.GetMouseButtonUp(0) && selectedObject) // lo suelta
        {
            selectedObject = null;
        }
    }
}
