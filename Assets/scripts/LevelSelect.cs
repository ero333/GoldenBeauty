//using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static EventManager;
using static StaticVariables;

public class LevelSelectManager : MonoBehaviour
{
    //LevelStartEvent levelStart = new LevelStartEvent();
    //levelStart.level = SessionData.level;
    
    public SceneController sceneController;
    private PlayerInput playerInput;
    private InputAction forwardAction;
    private InputAction backAction;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;

    // These will be true when the respective button is selected
    public bool IsButton1Selected { get; private set; }
    public bool IsButton2Selected { get; private set; }
    public bool IsButton3Selected { get; private set; }
    public bool IsButton4Selected { get; private set; }
    public bool IsButton5Selected { get; private set; }
    public bool IsButton6Selected { get; private set; }

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        forwardAction = playerInput.actions.FindAction("PlayerMap/Forward");
        backAction = playerInput.actions.FindAction("PlayerMap/Back");

       
        // NUEVO: Configurar estado de los botones según progreso
        SetupButtonsState();
    }

    // NUEVO MÉTODO: Configurar qué botones están activos
    void SetupButtonsState()
    {
        // Cargar datos guardados
        GameManager.Instance.LoadGameData();

        // Configurar cada botón según si está desbloqueado
        button1.interactable = GameManager.Instance.IsLevelUnlocked(1);
        button2.interactable = GameManager.Instance.IsLevelUnlocked(2);
        button3.interactable = GameManager.Instance.IsLevelUnlocked(3);
        button4.interactable = GameManager.Instance.IsLevelUnlocked(4);
        button5.interactable = GameManager.Instance.IsLevelUnlocked(5);
        button6.interactable = GameManager.Instance.IsLevelUnlocked(6);

        // Opcional: Cambiar apariencia de botones bloqueados
        UpdateButtonAppearance();
    }

    // NUEVO MÉTODO: Actualizar apariencia visual de botones
    void UpdateButtonAppearance()
    {
        SetButtonStyle(button1, 1);
        SetButtonStyle(button2, 2);
        SetButtonStyle(button3, 3);
        SetButtonStyle(button4, 4);
        SetButtonStyle(button5, 5);
        SetButtonStyle(button6, 6);
    }

    void SetButtonStyle(Button button, int levelNumber)
    {
        if (!button.interactable)
        {
            // Botón bloqueado
            button.image.color = Color.gray;
            Text buttonText = button.GetComponentInChildren<Text>();
            if (buttonText != null)
                buttonText.text = "BLOQUEADO";
        }
        else if (levelNumber <= GameManager.Instance.nvlSuperado)
        {
            // Botón de nivel completado
            button.image.color = Color.green;
        }
        else
        {
            // Botón desbloqueado pero no completado
            button.image.color = Color.white;
        }
    }

    void Update()
    {

        //forwardAction.Enable();
        //backAction.Enable();
        // Get the currently selected GameObject from EventSystem
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        // Check if either button is currently selected
        IsButton1Selected = selectedObject == button1.gameObject;
        IsButton2Selected = selectedObject == button2.gameObject;
        IsButton3Selected = selectedObject == button3.gameObject;
        IsButton4Selected = selectedObject == button4.gameObject;
        IsButton5Selected = selectedObject == button5.gameObject;
        IsButton6Selected = selectedObject == button6.gameObject;

        // Optional: Debug output to verify it's working
        if (forwardAction.triggered)
        {
            //Destroy(playerInput.gameObject);

            if (IsButton1Selected && button1.interactable)
            {
                
                EventManager.Instance.LogLevelStart(1);
                Debug.Log("Button 1 is selected.");
                SessionData.level = 1;
                sceneController.LoadScene("Nivel 1 Diario");
            }
            else if (IsButton2Selected && button2.interactable)
            {
                EventManager.Instance.LogLevelStart(2);
                sceneController.LoadScene("Nivel 2 Dialogo");
                Debug.Log("Button 2 is selected.");
            }
            else if (IsButton3Selected && button3.interactable)
            {
                EventManager.Instance.LogLevelStart(3);
                sceneController.LoadScene("Nivel 3 Diario");
                Debug.Log("Button 3 is selected.");
            }
            else if (IsButton4Selected && button4.interactable)
            {
                EventManager.Instance.LogLevelStart(4);
                sceneController.LoadScene("Nivel 4 Dialogo");
                Debug.Log("Button 4 is selected.");
            }
            else if (IsButton5Selected && button5.interactable)
            {
                EventManager.Instance.LogLevelStart(5);
                sceneController.LoadScene("Nivel 5 Dialogo");
                Debug.Log("Button 5 is selected.");
            }
            else if (IsButton6Selected && button6.interactable)
            {
                EventManager.Instance.LogLevelStart(6);
                sceneController.LoadScene("Nivel 6 Dialogo");
                Debug.Log("Button 6 is selected.");
            }
            else
            {
                Debug.Log("No button is selected or button is locked.");
            }
        }
    }

    // NUEVO: Método para refrescar los botones (útil si cambia el progreso)
    public void RefreshButtons()
    {
        SetupButtonsState();
    }
    public void OnButtonClick()
    {
        sceneController.LoadScene("Menu inicio");
    }
}
