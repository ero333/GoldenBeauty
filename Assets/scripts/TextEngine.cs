using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextEngine : MonoBehaviour
{
    public Text cajaDialogo;
    public Text cajaOpcion1;


    public TextAsset textAssetData;
    [SerializeField] public int nodoActual = 0;
    public string textoNodo;
    public GameObject boton1;
    public GameObject boton2;
    public GameObject boton3;

    public string textoOpcion1;
    public bool opcion1press = false; //si el boton es apretado...
    [SerializeField] public int opcion1value;


    [System.Serializable]
    public class Lectura
    {
        public string nodo;
        public string Texto;
        public string next;
        public string opcion1;
        public string opcion2;
        public string opcion3;
    }

    [System.Serializable]
    public class Lista
    {
        public Lectura[] lectura;
    }

    public Lista myDialogueList = new Lista();


    void ReadCSV()
    {
        if (textAssetData == null)
        {
            return;
        }

        string[] lines = textAssetData.text.Split('\n');

        // FILTRAR líneas válidas de manera más agresiva
        List<string> validLines = new List<string>();
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();

            // Saltar líneas completamente vacías o que solo tengan comas
            if (string.IsNullOrEmpty(line) || line == "," || line == ",,,,,")
                continue;

            // Saltar la fila de encabezados (asumiendo que contiene texto como "nodo", "texto", etc.)
            if (i == 0 && (line.ToLower().Contains("nodo") || line.ToLower().Contains("texto")))
                continue;

            validLines.Add(line);
        }

        int tableSize = validLines.Count;
        myDialogueList.lectura = new Lectura[tableSize];

        // Procesar SOLO las líneas válidas
        for (int i = 0; i < validLines.Count; i++)
        {
            string[] fields = ParseCSVLine(validLines[i]);

            if (fields.Length < 6)
            {
                Debug.LogWarning($"Línea {i} tiene solo {fields.Length} campos: {validLines[i]}");
                continue;
            }

            myDialogueList.lectura[i] = new Lectura()
            {
                nodo = fields[0].Trim(),
                Texto = fields[1].Trim(),
                next = fields[2].Trim(),
                opcion1 = fields[3].Trim(),
                opcion2 = fields[4].Trim(),
                opcion3 = fields[5].Trim()
            };
        }

        Debug.Log($"Total de nodos cargados: {myDialogueList.lectura.Length}");
    }
    private string[] ParseCSVLine(string line)
    {
        List<string> fields = new List<string>();
        bool inQuotes = false;
        StringBuilder currentField = new StringBuilder();

        for (int i = 0; i < line.Length; i++)
        {
            char currentChar = line[i];

            if (currentChar == '"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                {
                    currentField.Append('"');
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (currentChar == ',' && !inQuotes)
            {
                fields.Add(currentField.ToString());
                currentField.Clear();
            }
            else
            {
                currentField.Append(currentChar);
            }
        }

        fields.Add(currentField.ToString());

        return fields.ToArray();
    }



    public IEnumerator WriteText()
    {
        // Write first dialog
        nodoActual = 0;
        textoNodo = myDialogueList.lectura[nodoActual].Texto;

        while (textoNodo != null)
        {
            foreach (char x in textoNodo)
            {
                cajaDialogo.text += x;
                yield return new WaitForSeconds(0.01f);
            }
            foreach (char x in textoOpcion1)
            {
                cajaOpcion1.text += x;
            }
            yield return StartCoroutine(WaitForInput(KeyCode.Z));
        }

    }


    public IEnumerator WaitForInput(KeyCode key)
    {
        yield return new WaitUntil(() => Input.GetKeyDown(key));
        cajaDialogo.text = "";
        nodoActual = int.Parse(myDialogueList.lectura[nodoActual].next);
        textoNodo = myDialogueList.lectura[nodoActual].Texto; //esta es la funcion principal que determina, segun el nodo actual, que tengo mostrar

        if (myDialogueList.lectura[nodoActual].opcion1 != null) //si hay opciones a elegir...
        {
            boton1.SetActive(true); //aparece la opcion con el boton
            opcion1value = int.Parse(myDialogueList.lectura[nodoActual].opcion1); //almaceno el valor que figura en la celda
            textoOpcion1 = myDialogueList.lectura[opcion1value - 1].Texto; //el valor de celda indica el texto que figura

        }
        else
        {
            boton1.SetActive(false);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
        StartCoroutine(WriteText());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonClick()
    {
        opcion1press = true;
        Debug.Log("pressed");
    }
}
