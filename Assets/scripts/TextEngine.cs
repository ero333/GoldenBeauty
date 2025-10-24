using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static StaticVariables;
using static EventManager;

public class TextEngine : MonoBehaviour
{
    public SceneController sceneController;
    public GameObject pauseMenu;
    private PlayerInput playerInput;
    private InputAction forwardAction;
    private InputAction backAction;

    public Text cajaDialogo;
    public Text cajaOpcion1;
    public Text cajaOpcion2;
    public Text cajaOpcion3;

    public TextAsset textAssetData;
    [SerializeField] public int nodoActual = 0;
    public string textoNodo;
    public GameObject boton1;
    public GameObject boton2;
    public GameObject boton3;
    public GameObject botonReanudar;

    public bool IsButton1Selected { get; private set; }
    public bool IsButton2Selected { get; private set; }
    public bool IsButton3Selected { get; private set; }

    public string textoOpcion1;
    public string textoOpcion2;
    public string textoOpcion3;

    //valores de botones
    private int optionNum; // si el botón es apretado...
    [SerializeField] private int opcion1value;
    [SerializeField] private int opcion2value;
    private int opcion3value;

    //nombre del personaje visible
    public Text nombrePersonaje;
    public GameObject nombreSlot;

    //leyenda tutorial
    public GameObject tutorialText;

    //pausa
    //public GameObject pauseSquare;
    public GameObject pauseCanvas;
    public GameObject alerta;
    public bool canWrite;
    public GameObject diario;


    //analytics
    public int currentLevel;
    public int currentQuestion;

    //sonido
    public AudioSource sonido;
    public AudioClip audio1;
    public AudioClip audio2;


    [System.Serializable]
    public class Lectura
    {
        public string nodo;
        public string Texto;
        public string next;
        public string opcion1;
        public string opcion2;
        public string opcion3;
        public string back;
        public string personaje;
        public string nosotros;
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

        List<string> validLines = new List<string>();
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i].Trim();

            if (string.IsNullOrEmpty(line) || line == "," || line == ",,,,,")
                continue;

            if (i == 0 && (line.ToLower().Contains("nodo") || line.ToLower().Contains("texto")))
                continue;

            validLines.Add(line);
        }

        int tableSize = validLines.Count;
        myDialogueList.lectura = new Lectura[tableSize];

        for (int i = 0; i < validLines.Count; i++)
        {
            string[] fields = ParseCSVLine(validLines[i]);

            if (fields.Length < 9)
            {
                Debug.LogWarning($"⚠️ Línea {i + 1} tiene solo {fields.Length} columnas: {validLines[i]}");
                Array.Resize(ref fields, 9);
            }

            myDialogueList.lectura[i] = new Lectura()
            {
                nodo = fields[0]?.Trim(),
                Texto = fields[1]?.Trim(),
                next = fields[2]?.Trim(),
                opcion1 = fields[3]?.Trim(),
                opcion2 = fields[4]?.Trim(),
                opcion3 = fields[5]?.Trim(),
                back = fields[6]?.Trim(),
                personaje = fields[7]?.Trim(),
                nosotros = fields[8]?.Trim()
            };
        }

        Debug.Log($"✅ Total de nodos cargados: {myDialogueList.lectura.Length}");
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
        //diario.SetActive(true);
        //yield return new WaitUntil(() => diario.activeSelf == false);
        nodoActual = 0;
        textoNodo = myDialogueList.lectura[nodoActual].Texto;

        while (textoNodo != null)
        {
            if (myDialogueList.lectura[nodoActual].personaje == "1")
            {
                nombrePersonaje.text = nombreSlot.name;
            }
            else
            {
                nombrePersonaje.text = "Yo";
            }

            cajaDialogo.text = "";

                foreach (char x in textoNodo)
                {
                    cajaDialogo.text += x;
                    yield return new WaitForSeconds(0.001f);
                }

            

            cajaOpcion1.text = "";
            cajaOpcion2.text = "";
            cajaOpcion3.text = "";
            boton1.SetActive(false);
            boton2.SetActive(false);
            boton3.SetActive(false);

            
            if (!string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].opcion1))
            {
                boton1.SetActive(true);
                opcion1value = int.Parse(myDialogueList.lectura[nodoActual].opcion1);
                textoOpcion1 = myDialogueList.lectura[opcion1value - 1].Texto;
                cajaOpcion1.text = textoOpcion1;
            }

            if (!string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].opcion2))
            {
                boton2.SetActive(true);
                opcion2value = int.Parse(myDialogueList.lectura[nodoActual].opcion2);
                textoOpcion2 = myDialogueList.lectura[opcion2value - 1].Texto;
                cajaOpcion2.text = textoOpcion2;
            }

            if (!string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].opcion3))
            {
                boton3.SetActive(true);
                opcion3value = int.Parse(myDialogueList.lectura[nodoActual].opcion3);
                textoOpcion3 = myDialogueList.lectura[opcion3value - 1].Texto;
                cajaOpcion3.text = textoOpcion3;
            }

            // ⬇️ Aquí usamos la versión modificada
            //yield return StartCoroutine(WaitForInput(KeyCode.Z));

                yield return StartCoroutine(WaitForInput());

           

        }
    }

    public IEnumerator WaitForInput(KeyCode key)
    {
        // Si hay opciones disponibles
        if (!string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].opcion1) ||
            !string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].opcion2) ||
            !string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].opcion3))
        {
            optionNum = 0;
            esperandoOpcion = true;

            // 🔹 Espera hasta que se elija una opción O se presione X
            yield return new WaitUntil(() =>
                optionNum > 0 || Input.GetKeyDown(KeyCode.X));

            esperandoOpcion = false;

            if (Input.GetKeyDown(KeyCode.X))
            {
                // retrocede SOLO si la celda back tiene un número válido
                if (!string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].back) &&
                    int.TryParse(myDialogueList.lectura[nodoActual].back, out int backNodo))
                {
                    nodoActual = backNodo - 1;
                    textoNodo = myDialogueList.lectura[nodoActual].Texto;
                }
            }
            else
            {
                int siguienteNodo = 0;
                if (optionNum == 1)
                    siguienteNodo = int.Parse(myDialogueList.lectura[opcion1value - 1].nodo);
                else if (optionNum == 2)
                    siguienteNodo = int.Parse(myDialogueList.lectura[opcion2value - 1].nodo);
                else if (optionNum == 3)
                    siguienteNodo = int.Parse(myDialogueList.lectura[opcion3value - 1].nodo);

                nodoActual = siguienteNodo - 1;
                textoNodo = myDialogueList.lectura[nodoActual].Texto;
            }
        }
        else
        {
            // 🔹 Espera Z o X cuando no hay opciones
            yield return new WaitUntil(() => Input.GetKeyDown(key) || Input.GetKeyDown(KeyCode.X));

            if (Input.GetKeyDown(KeyCode.X))
            {
                if (!string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].back) &&
                    int.TryParse(myDialogueList.lectura[nodoActual].back, out int backNodo))
                {
                    nodoActual = backNodo - 1;
                    textoNodo = myDialogueList.lectura[nodoActual].Texto;
                }
            }
            else if (Input.GetKeyDown(key))
            {
                if (!string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].next) && canWrite)
                {
                    nodoActual = int.Parse(myDialogueList.lectura[nodoActual].next) - 1;
                    textoNodo = myDialogueList.lectura[nodoActual].Texto;

                    if (nodoActual == 40 - 1)
                    {
                        sceneController.PasarNivel();
                        yield break;
                    }
                }
                else
                {
                    textoNodo = null;
                }
            }
        }
    }
    public IEnumerator WaitForInput()
    {
        // Habilitar acciones necesarias
        forwardAction.Enable();
        backAction.Enable();
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        // Check if either button is currently selected
        IsButton1Selected = selectedObject == boton1.gameObject;
        IsButton2Selected = selectedObject == boton2.gameObject;
        IsButton3Selected = selectedObject == boton3.gameObject;

        bool inputReceived = false;

        // Si hay opciones disponibles
        if (!string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].opcion1) ||
            !string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].opcion2) ||
            !string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].opcion3))
        {
            optionNum = 0;
            esperandoOpcion = true;
            currentQuestion++;

            // Esperar hasta que se elija una opción O se presione back (X)
            yield return new WaitUntil(() =>
                optionNum > 0 || backAction.triggered);

            esperandoOpcion = false;

            if (backAction.triggered)
            {
                // Retrocede si la celda back tiene un número válido
                if (!string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].back) &&
                    int.TryParse(myDialogueList.lectura[nodoActual].back, out int backNodo))
                {
                    nodoActual = backNodo - 1;
                    textoNodo = myDialogueList.lectura[nodoActual].Texto;
                }
            }
            else
            {
                int siguienteNodo = 0;
                if (optionNum == 1)
                {
                    EventManager.SafeLogEvent("Talk", new Dictionary<string, object> {
    { "level", currentLevel },
    { "question", currentQuestion },
    { "answer", 1 }
    });
                    //EventManager.Instance.LogTalk(1,1,1);
                    siguienteNodo = int.Parse(myDialogueList.lectura[opcion1value - 1].nodo);
                }

                else if (optionNum == 2)
                {
                    EventManager.SafeLogEvent("Talk", new Dictionary<string, object> {
    { "level", currentLevel },
    { "question", currentQuestion },
    { "answer", 2 }
    });
                    //EventManager.Instance.LogTalk(0, currentQuestion, 2);
                    siguienteNodo = int.Parse(myDialogueList.lectura[opcion2value - 1].nodo);
                }

                else if (optionNum == 3)
                {
                    EventManager.SafeLogEvent("Talk", new Dictionary<string, object> {
    { "level", currentLevel },
    { "question", currentQuestion },
    { "answer", 3 }
    });
                    //EventManager.Instance.LogTalk(0, currentQuestion, 3);
                    siguienteNodo = int.Parse(myDialogueList.lectura[opcion3value - 1].nodo);
                }


                nodoActual = siguienteNodo - 1;
                textoNodo = myDialogueList.lectura[nodoActual].Texto;
            }
        }
        else
        {
                yield return new WaitUntil(() =>
                forwardAction.triggered || backAction.triggered);
           
            if (backAction.triggered)
            {
                if (!string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].back) &&
                    int.TryParse(myDialogueList.lectura[nodoActual].back, out int backNodo))
                {
                    nodoActual = backNodo - 1;
                    textoNodo = myDialogueList.lectura[nodoActual].Texto;
                }
            }
            else if (forwardAction.triggered && canWrite)
            {
                sonido.PlayOneShot(audio1);
                if (!string.IsNullOrWhiteSpace(myDialogueList.lectura[nodoActual].next))
                {
                    nodoActual = int.Parse(myDialogueList.lectura[nodoActual].next) - 1;
                    textoNodo = myDialogueList.lectura[nodoActual].Texto;

                    if (nodoActual == 40 - 1)
                    {
                        sceneController.PasarNivel();
                        yield break;
                    }
                }
                else
                {
                    textoNodo = null;
                }
            }
    
        }

        // Deshabilitar acciones
        forwardAction.Disable();
        backAction.Disable();


    }

   
    private bool esperandoOpcion = false;

    public void OnButton1Click()
    {
        if (esperandoOpcion)
        {
            optionNum = 1;
            Debug.Log($"Botón 1 clickeado - optionNum: {optionNum}");
        }
        else
        {
            Debug.Log("Botón 1 clickeado pero no se espera opción actualmente");
        }
    }

    public void OnButton2Click()
    {
        if (esperandoOpcion)
        {
            optionNum = 2;
            Debug.Log($"Botón 2 clickeado - optionNum: {optionNum}");
        }
        else
        {
            Debug.Log("Botón 2 clickeado pero no se espera opción actualmente");
        }
    }

    public void OnButton3Click()
    {
        if (esperandoOpcion)
        {
            optionNum = 3;
            Debug.Log($"Botón 3 clickeado - optionNum: {optionNum}");
        }
        else
        {
            Debug.Log("Botón 3 clickeado pero no se espera opción actualmente");
        }
    }

    /*public void OnButton4Click() // reanudar
    {
        playerInput.enabled = true;
        Time.timeScale = 1f;
        pauseSquare.SetActive(!pauseSquare.activeSelf);
        pauseCanvas.SetActive(!pauseCanvas.activeSelf);
        EnableButton();
    }
    */

    public void OnButton5Click() //volver a inicio
    {
        botonReanudar.SetActive(false);
        alerta.SetActive(true);
    }

    public void OnButton6Click() //confirmación
    {
        EventManager.SafeLogEvent("Exit", new Dictionary<string, object> {
                    { "level", currentLevel }
                    });
        sceneController.LoadScene("levelSelect");
    }
    public void OnButton7Click() //rechazar
    {
        alerta.SetActive(false);
        botonReanudar.SetActive(true);
    }
    public void OnButton8Click() //diario
    {
        diario.SetActive(false);
    }
    /*
     * public void OnButton9Click() //pausa
    {
        pauseSquare.SetActive(!pauseSquare.activeSelf);
        pauseCanvas.SetActive(!pauseCanvas.activeSelf);

        if (playerInput.enabled)
        {
            playerInput.enabled = false;
            Time.timeScale = 0f;
            DisableButton();
        }
        else
        {
            playerInput.enabled = true;
            Time.timeScale = 1f;
            EnableButton();
        }
    }
    */
    public void OnButton10Click() //skip
    {
        EventManager.SafeLogEvent("SkipChat", new Dictionary<string, object> {
                    { "level", currentLevel }
                    });
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
         
        //dialogos
        if (currentScene.name == "Nivel 1 Dialogo")
        {
            currentLevel = 1;
        }
        else if (currentScene.name == "Nivel 2 Dialogo")
        {
            currentLevel = 2;
        }
        else if (currentScene.name == "Nivel 3 Dialogo")
        {
            currentLevel = 3;
        }
        else if (currentScene.name == "Nivel 4 Dialogo")
        {
            currentLevel = 4;
        }
        else if (currentScene.name == "Nivel 5 Dialogo")
        {
            currentLevel = 5;
        }
        else if (currentScene.name == "Nivel 6 Dialogo")
        {
            currentLevel = 6;
        }

        playerInput = GetComponent<PlayerInput>();
        forwardAction = playerInput.actions.FindAction("PlayerMap/Forward");
        backAction = playerInput.actions.FindAction("PlayerMap/Back");
        ReadCSV();
        StartCoroutine(WriteText());
        StartCoroutine(TutoText());
        
    }

    void Update()
    {
        if (Input.GetKeyDown("2"))
        {
            sceneController.PasarNivel();
        }

        
        if (pauseMenu.activeSelf)
        {
            canWrite = false;
            forwardAction.Disable();
        }
        else
        {
            canWrite= true;
            forwardAction.Enable();
        }


    }

    public IEnumerator TutoText()
    {
        yield return new WaitForSeconds(4f);
        tutorialText.SetActive(true);
        yield return new WaitForSeconds(10f);
        tutorialText.SetActive(false);
    }

    public void DisableButton()
    {

        Button buttonComponent1 = boton1.GetComponent<Button>();
        if (buttonComponent1 != null)
        {
            buttonComponent1.interactable = false;
        }

        Button buttonComponent2 = boton2.GetComponent<Button>();
        if (buttonComponent2 != null)
        {
            buttonComponent2.interactable = false;
        }

        Button buttonComponent3 = boton3.GetComponent<Button>();
        if (buttonComponent3 != null)
        {
            buttonComponent3.interactable = false;
        }
    }

    public void EnableButton()
    {
        Button buttonComponent1 = boton1.GetComponent<Button>();
        if (buttonComponent1 != null)
        {
            buttonComponent1.interactable = true;
        }
        Button buttonComponent2 = boton2.GetComponent<Button>();
        if (buttonComponent2 != null)
        {
            buttonComponent2.interactable = true;
        }

        Button buttonComponent3 = boton3.GetComponent<Button>();
        if (buttonComponent3 != null)
        {
            buttonComponent3.interactable = true;
        }
    }
}