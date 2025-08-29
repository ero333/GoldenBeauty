using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01events : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;
    public GameObject textBox;

    [SerializeField] string textToSpeak; //texto dicho por los personajes
    [SerializeField] int currentTextLength; //cantidad mientras se actualiza
    [SerializeField] int textLength;
    [SerializeField] GameObject textObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] int eventPos = 0;


    void Start()
    {
        StartCoroutine(EventStart());
    }

    // Update is called once per frame
    void Update()
    {
        textLength = TextCreator.charCount; //se vincula con el otro script para obtener la cantidad de caracteres
    }

    public IEnumerator EventStart ()
    {
        yield return new WaitForSeconds(0.5f);
        textObject.SetActive(true); //me aseguro que el texto exista en la escena
        textToSpeak = "Buenoss días!"; //en lugar de escribirlo en el inspector, lo pongo acá
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak; //se transfiere el texto al GameObject
        currentTextLength = textToSpeak.Length;

        TextCreator.runText = true; //activa booleano del otro script
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength); //correr codigo hasta el final del texto
        yield return new WaitForSeconds(0.4f);
        nextButton.SetActive(true);
        eventPos = 1; //al finalizar esto, termina el evento 0 e inicia el evento 1
    }
    
    public IEnumerator EventOne()
    {
        nextButton.SetActive(false); //desactiva el botón una vez presionado (es evento 1) para que no se pueda apretar 2 veces
        textToSpeak = "Yo? rebotando";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;

        TextCreator.runText = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.4f);
        nextButton.SetActive(true);
        eventPos = 2;
    }

    public void NextButton ()
    {
        if (eventPos == 1)
        {
            StartCoroutine(EventOne());
        }
    }
}
