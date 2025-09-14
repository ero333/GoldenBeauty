using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaCapas : MonoBehaviour
{
    public GameObject pauseSquare;
    public GameObject accesorio_1;
    public GameObject accesorio_2;
    public GameObject accesorio_3;

    public GameObject Pelo_1;
    public GameObject Pelo_2;
    public GameObject Pelo_3;

    public GameObject Rostro_1;
    public GameObject Rostro_2;
    public GameObject Rostro_3;

    public GameObject Ropa_1;
    public GameObject Ropa_2;
    public GameObject Ropa_3;

    public GameObject accesorio_0;
    public GameObject Pelo_0;
    public GameObject Rostro_0;
    public GameObject Ropa_0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //toma la pos del mouse
        mousePosition.z = 0; //para que no se corra al iniciar (?


    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (DragMultipleObjects.mouseSuelto)
        {
            //HERRAMIENTA 1

            if (collision.gameObject.CompareTag("Accesorios-1"))
            {
                accesorio_1.SetActive(true);
                accesorio_2.SetActive(false);
                accesorio_3.SetActive(false);
                accesorio_0.SetActive(false);

                DragMultipleObjects.mouseSuelto = false;
            }

            //HERRAMIENTA 2

            if (collision.gameObject.CompareTag("Accesorios-2"))
            {
                accesorio_1.SetActive(false);
                accesorio_2.SetActive(true);
                accesorio_3.SetActive(false);
                accesorio_0.SetActive(false);

                DragMultipleObjects.mouseSuelto = false;
            }

            //HERRAMIENTA 3

            if (collision.gameObject.CompareTag("Accesorios-3"))
            {
                accesorio_1.SetActive(false);
                accesorio_2.SetActive(false);
                accesorio_3.SetActive(true);
                accesorio_0.SetActive(false);

                DragMultipleObjects.mouseSuelto = false;
            }





            //PELO 1 

            if (collision.gameObject.CompareTag("Pelo-1"))
            {
                Pelo_1.SetActive(true);
                Pelo_2.SetActive(false);
                Pelo_3.SetActive(false);
                Pelo_0.SetActive(false);

                DragMultipleObjects.mouseSuelto = false;
            }

            //PELO 2

            if (collision.gameObject.CompareTag("Pelo-2"))
            {
                Pelo_1.SetActive(false);
                Pelo_2.SetActive(true);
                Pelo_3.SetActive(false);
                Pelo_0.SetActive(false);

                DragMultipleObjects.mouseSuelto = false;
            }

            //PELO 3

            if (collision.gameObject.CompareTag("Pelo-3"))
            {
                Pelo_1.SetActive(false);
                Pelo_2.SetActive(false);
                Pelo_3.SetActive(true);
                Pelo_0.SetActive(false);

                DragMultipleObjects.mouseSuelto = false;
            }





            //ROSTRO 1 

            if (collision.gameObject.CompareTag("Rostro-1"))
            {
                Rostro_1.SetActive(true);
                Rostro_2.SetActive(false);
                Rostro_3.SetActive(false);
                Rostro_0.SetActive(false);

                DragMultipleObjects.mouseSuelto = false;
            }

            //ROSTRO 2

            if (collision.gameObject.CompareTag("Rostro-2"))
            {
                Rostro_1.SetActive(false);
                Rostro_2.SetActive(true);
                Rostro_3.SetActive(false);
                Rostro_0.SetActive(false);

                DragMultipleObjects.mouseSuelto = false;
            }

            //ROSTRO 3

            if (collision.gameObject.CompareTag("Rostro-3"))
            {
                Rostro_1.SetActive(false);
                Rostro_2.SetActive(false);
                Rostro_3.SetActive(true);
                Rostro_0.SetActive(false);

                DragMultipleObjects.mouseSuelto = false;
            }




            //ROPA 1 

            if (collision.gameObject.CompareTag("Ropa-1"))
            {
                Ropa_1.SetActive(true);
                Ropa_2.SetActive(false);
                Ropa_3.SetActive(false);
                Ropa_0.SetActive(false);

                DragMultipleObjects.mouseSuelto = false;
            }

            //ROPA 2

            if (collision.gameObject.CompareTag("Ropa-2"))
            {
                Ropa_1.SetActive(false);
                Ropa_2.SetActive(true);
                Ropa_3.SetActive(false);
                Ropa_0.SetActive(false);

                DragMultipleObjects.mouseSuelto = false;
            }

            //ROPA 3

            if (collision.gameObject.CompareTag("Ropa-3"))
            {
                Ropa_1.SetActive(false);
                Ropa_2.SetActive(false);
                Ropa_3.SetActive(true);
                Ropa_0.SetActive(false);

                DragMultipleObjects.mouseSuelto = false;
            }

        }

    }

}
