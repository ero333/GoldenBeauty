using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DragMultipleObjects : MonoBehaviour
{
    public GameObject[] selectableObjects; // Arrays
    private GameObject selectedObject; //ojecto x al ser seleccionado
    private Vector3 offset;
    private Dictionary<GameObject, Vector3> originalPositions = new Dictionary<GameObject, Vector3>(); //define cosas
    private Dictionary<GameObject, Color> originalColors = new Dictionary<GameObject, Color>(); //define los colores originales para la opacidad

    public bool vivo;
    public GameObject menuDePausa;
    public GameObject explosion;

    public static bool mouseSuelto = false; //bool para saber si apretamos o no el mouse

    void Start()
    {
        foreach (GameObject obj in selectableObjects) //por cada objeto en el array...
        {
            originalPositions[obj] = obj.transform.position; //asigna la posicion del mouse
        }

        vivo = true;
    }

    void Update()
    {

        if (vivo == true) 
        {
            movimiento();
        }

        if (menuDePausa.activeInHierarchy)
        {
            vivo = false;
        }

        else 
        {
            vivo = true;
        }
    }
       
    public void movimiento()
    {
        // Cuando presiono click
        if (Input.GetMouseButtonDown(0))
        {
            mouseSuelto = false;
        }

        // Cuando suelto click
        if (Input.GetMouseButtonUp(0))
        {
            mouseSuelto = true;
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //toma la pos del mouse
        mousePosition.z = 0; //para que no se corra al iniciar (?

        if (Input.GetMouseButtonDown(0)) //cuando clickeo...
        {
            Collider2D targetCollider = Physics2D.OverlapPoint(mousePosition);

            if (targetCollider) //si el collider coinicide...
            {
                // Verificar si el objeto clickeado está en nuestro array de seleccionables
                foreach (GameObject obj in selectableObjects)
                {
                    if (obj == targetCollider.gameObject) //chequea que el objeto esté en el array
                    {
                        selectedObject = obj; //el selectedOject es asignado
                        offset = selectedObject.transform.position - mousePosition;
                        break;
                    }
                }
            }
        }

        if (selectedObject) //si hay un objeto seleccionado...
        {
            Vector3 newPosition = mousePosition + offset; //lo sigue con el mouse
            newPosition.z = selectedObject.transform.position.z;
            selectedObject.transform.position = newPosition;
        }

        if (Input.GetMouseButtonUp(0) && selectedObject) //si suelto...
        {
            /*selectedObject = null;
            ResetAllObjects();*/
            StartCoroutine(Amongas());
        }


        if (Input.GetKeyDown(KeyCode.R)) //reset
        {
            ResetAllObjects();
        }

        foreach (GameObject obj in selectableObjects) //por cada icono que sea seleccionable...
        {
            Collider2D col = obj.GetComponent<Collider2D>(); //obtener el colider del icono
            if (col == null) continue;

            if (col.OverlapPoint(mousePosition))  //si el mouse coordina con el colider...
            {
                SetOpacity(obj, 0.5f); //bajar opacidad
            }
            else
            {
                SetOpacity(obj, 1f);
            }
        }
    }

        public void ResetAllObjects()
    {
        foreach (GameObject obj in selectableObjects)
        {
            if (originalPositions.ContainsKey(obj))
            {
                obj.transform.position = originalPositions[obj];
            }
        }
    }

    public void AddSelectableObject(GameObject newObject)
    {
        // Crear un nuevo array con un elemento más
        GameObject[] newArray = new GameObject[selectableObjects.Length + 1];

        // Copiar los objetos existentes
        for (int i = 0; i < selectableObjects.Length; i++)
        {
            newArray[i] = selectableObjects[i];
        }

        // Agregar el nuevo objeto
        newArray[selectableObjects.Length] = newObject;

        // Guardar su posición original
        originalPositions[newObject] = newObject.transform.position;

        // Reemplazar el array
        selectableObjects = newArray;
    }

    // Método para verificar si un objeto es seleccionable
    public bool IsObjectSelectable(GameObject obj)
    {
        foreach (GameObject selectable in selectableObjects)
        {
            if (selectable == obj)
            {
                return true;
            }
        }
        return false;
    }

    void SetOpacity(GameObject obj, float alpha)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color color = sr.color;
            color.a = alpha;
            sr.color = color;
        }
    }

    private IEnumerator Amongas()
    {
        explosion.SetActive(true);
        selectedObject = null;
        yield return new WaitForSeconds(0.1f);

        ResetAllObjects();
        yield return new WaitForSeconds(0.35f);
        explosion.SetActive(false);
    }
}


