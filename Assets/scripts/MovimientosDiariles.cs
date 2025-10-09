using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientosDiariles : MonoBehaviour
{

    private PlayerInput playerInput;
    private InputAction LEFT;
    private InputAction RIGHT;
    private InputAction UP;
    private InputAction DOWN;
    public GameObject ImagenA;

    public GameObject LEFTimg;
    public GameObject RIGHTimg;
    public GameObject UPimg;
    public GameObject DOWNimg;

    public bool isUP;
    public bool isDOWN;
    public bool isLeft;
    public bool isRight;



    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        //playerInput.SwitchCurrentActionMap("PlayerMap"); // <--- esto es clave

        LEFT = playerInput.actions.FindAction("PlayerMap/Izquierda");
        RIGHT = playerInput.actions.FindAction("PlayerMap/Derecha");
        UP = playerInput.actions.FindAction("PlayerMap/Arriba");
        DOWN = playerInput.actions.FindAction("PlayerMap/Abajo");
    }

    // Update is called once per frame
    void Update()
    {
        playerInput.SwitchCurrentActionMap("PlayerMap");

        if (LEFT.triggered && isLeft == true) // 0 = Felcha Izquierda
        {
            HaciaIzq();
        }

        if (RIGHT.triggered && isRight == true) // 0 = Flecha Derecha
        {
            HaciaDer();
        }

        if (UP.triggered && isUP == true) // 0 = Flecha Arriba
        {
            HaciaArriba();
        }

        if (DOWN.triggered && isDOWN) // 0 = Flecha Abajo
        {
            HaciaAbajo();
        }
    }


    private void Amongas()
    {
        ImagenA.SetActive(true);
        gameObject.SetActive(false);
    }

    private void HaciaArriba()
    {
        UPimg.SetActive(true);
        gameObject.SetActive(false);
    }

    private void HaciaAbajo()
    {
        DOWNimg.SetActive(true);
        gameObject.SetActive(false);
    }

    private void HaciaDer()
    {
        RIGHTimg.SetActive(true);
        gameObject.SetActive(false);
    }

    private void HaciaIzq()
    {
        LEFTimg.SetActive(true);
        gameObject.SetActive(false);
    }
}


