using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public SceneController sceneController;

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


    
    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("ZZZZZZZZZZZZZZ");

            if (IsButton1Selected)
            {
                sceneController.LoadScene("Nivel 1 Dialogo");
                Debug.Log("Button 1 is selected.");

            }
            else if (IsButton2Selected)
            {
                sceneController.LoadScene("Scene2");
                Debug.Log("Button 2 is selected.");
            }
            else if (IsButton3Selected)
            {
                sceneController.LoadScene("Scene3");
                Debug.Log("Button 3 is selected.");
            }
            else if (IsButton4Selected)
            {
                sceneController.LoadScene("Scene4");
                Debug.Log("Button 4 is selected.");
            }
            else if (IsButton5Selected)
            {
                sceneController.LoadScene("Scene5");
                Debug.Log("Button 5 is selected.");
            }
            else if (IsButton6Selected)
            {
                sceneController.LoadScene("Scene6");
                Debug.Log("Button 6 is selected.");
            }

            

            else
            {
                Debug.Log("No button is selected.");
            }

        
        }
    }
}
