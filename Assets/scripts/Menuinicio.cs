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
using UnityEngine.SceneManagement;

public class Menuinicio : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction forwardAction;
    private InputAction backAction;

    public SceneController sceneController;
    public Button buttonStart;
    public Button buttonCredits;
    public Button buttonMenu;
    public Button buttonRate;


    public bool IsButtonStart { get; private set; }
    public bool IsButtonCredits { get; private set; }
    public bool IsButtonMenu { get; private set; }
    public bool IsButtonRate { get; private set; }

    //audio
    public AudioSource sonido;
    public AudioClip sonido1;
    public AudioClip sonido2;
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
        IsButtonRate = selectedObject == buttonRate.gameObject;


        if (forwardAction.triggered)
        {
            
            if (IsButtonStart)
            {
                StartCoroutine(OnButtonSound());
                
               
            }

            else if (IsButtonCredits)
            {
                StartCoroutine(OnButton2Sound());

            }

            else if (IsButtonMenu)
            {
                StartCoroutine(OnButton4Sound());
            }
            else if (IsButtonRate) {
                StartCoroutine(OnButton3Sound());
            }
        }

        if (SceneManager.GetActiveScene().name == "Creditos")
        {
            StartCoroutine(RatingSoon());
            
        }
    }
    public IEnumerator RatingSoon ()
    {
        yield return new WaitForSeconds(10f);
        sceneController.LoadScene("Calificar");
    }

    public IEnumerator OnButtonSound ()
    {
        sonido.PlayOneShot(sonido1);
        yield return new WaitForSeconds(0.3f);
        sceneController.LoadScene("LevelSelect");
        Debug.Log("Start is selected.");
    }
    public IEnumerator OnButton2Sound()
    {
        sonido.PlayOneShot(sonido1);
        yield return new WaitForSeconds(0.3f);
        sceneController.LoadScene("Creditos");
        Debug.Log("Start is selected.");
    }
    public IEnumerator OnButton3Sound()
    {
        sonido.PlayOneShot(sonido1);
        yield return new WaitForSeconds(0.3f);
        sceneController.LoadScene("Calificar");
        Debug.Log("Start is selected.");
    }
    public IEnumerator OnButton4Sound()
    {
        sonido.PlayOneShot(sonido1);
        yield return new WaitForSeconds(0.3f);
        sceneController.LoadScene("Menu inicio");
        Debug.Log("Start is selected.");
    }
}
