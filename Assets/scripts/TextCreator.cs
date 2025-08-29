using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCreator : MonoBehaviour
{
    // Start is called before the first frame update

    public static TMPro.TMP_Text viewText;
    public static bool runText;
    public static int charCount;
    [SerializeField] string transferText;
    [SerializeField] int intCount;


    // Update is called once per frame
    void Update()
    {
        intCount = charCount; //en el inspector, podremos ver la cantidad de caracteres
        charCount = GetComponent<TMPro.TMP_Text>().text.Length; //character count es la cantidad de letras en nuestro texto
        if (runText)
        {
            runText = false;
            viewText = GetComponent<TMPro.TMP_Text>();
            transferText = viewText.text; 
            viewText.text = "";
            StartCoroutine(RollText());
        }
        //viewText obtiene el texto, le da a TransferText texto en forma de string, viewText se vacía (""), e inicia la corrutina que escribe el viewText.
    }

    IEnumerator RollText()
    {
        foreach (char c in transferText)
        {
            viewText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        //por cada letra que aparece en transferText, el texto añade una cada 0,2 segundos
    }
}
