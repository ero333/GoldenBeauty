using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Menuinicio : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction forwardAction;
    private InputAction backAction;

    public SceneController sceneController;
    public Button buttonStart;
    public Button buttonCredits;
    public Button buttonMenu;


    public bool IsButtonStart { get; private set; }
    public bool IsButtonCredits { get; private set; }
    public bool IsButtonMenu { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        forwardAction = playerInput.actions.FindAction("PlayerMap/Forward");
        backAction = playerInput.actions.FindAction("PlayerMap/Back");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;

        IsButtonStart = selectedObject == buttonStart.gameObject;
        IsButtonCredits = selectedObject == buttonCredits.gameObject;
        IsButtonMenu = selectedObject == buttonMenu.gameObject;


        if (forwardAction.triggered)
        {
            if (IsButtonStart)
            {
                sceneController.LoadScene("LevelSelect");
                Debug.Log("Start is selected.");
            }

            else if (IsButtonCredits)
            {
                sceneController.LoadScene("Creditos");
                Debug.Log("creditos is selected.");
            }

            else if (IsButtonMenu)
            {
                sceneController.LoadScene("Menu inicio");
                Debug.Log("creditos is selected.");
            }
        }
    }
}
