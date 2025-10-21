using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CuadroTexto : MonoBehaviour
{
    public GameObject panelCuadro;  // Panel UI en el centro de la pantalla
    public Text textoCuadro;        // Texto dentro del panel

    public void Mostrar(string texto)
    {
        panelCuadro.SetActive(true);
        textoCuadro.text = "";
        StartCoroutine(MostrarTextoLetraPorLetra(texto));
    }

    IEnumerator MostrarTextoLetraPorLetra(string texto)
    {
        foreach (char c in texto)
        {
            textoCuadro.text += c;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void Ocultar()
    {
        panelCuadro.SetActive(false);
        textoCuadro.text = "";
    }
}
