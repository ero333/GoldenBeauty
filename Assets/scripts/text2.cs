using System.Collections;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Text2 : MonoBehaviour
{
    public Text cajaDialogo;
    private string dialogo1 = "Buenass";
    private string dialogo2 = "Yo? rebotando";

    private bool waitingForInput = false;
    public GameObject opcion1;

    public IEnumerator WriteText()
    {
        // Write first dialog
        foreach (char x in dialogo1)
        {
            cajaDialogo.text += x;
            yield return new WaitForSeconds(0.01f);
        }


        yield return StartCoroutine(WaitForInput(KeyCode.Z));

        foreach (char x in dialogo2)
        {
            cajaDialogo.text += x;
            yield return new WaitForSeconds(0.01f);
        }

        yield return StartCoroutine(WaitForInput(KeyCode.Z));

    }

    
    public IEnumerator WaitForInput(KeyCode key)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(key));
        cajaDialogo.text = "";

    }

    void Start()
    {
        StartCoroutine(WriteText());
    }


    void Update()
    {
      
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // This runs when the UI element is clicked
        Debug.Log("UI Element clicked: " + opcion1.name);

        // Your code here
    }
}


