using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;
    public GameObject textBox;

    [SerializeField] string textToSpeak; //texto dicho por los personajes
    [SerializeField] int currentTextLength; //cantidad mientras se actualiza
    [SerializeField] int textLength;
    [SerializeField] GameObject textObject;

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
        yield return new WaitForSeconds(1);
        textBox.SetActive(true);
        textObject.SetActive(true); //me aseguro que el texto exista en la escena
        textToSpeak = "Buenoss días!"; //en lugar de escribirlo en el inspector, lo pongo acá
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak; //se transfiere el texto al GameObject
        currentTextLength = textToSpeak.Length;

        TextCreator.runText = true; //activa booleano del otro script
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength); //correr codigo hasta el final del texto
        yield return new WaitForSeconds(1);

    }
    
}
