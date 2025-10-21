using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Diario_2_LaPelicula : MonoBehaviour
{

    private PlayerInput playerInput;
    private InputAction UpAction;
    private InputAction DownAction;
    private InputAction LeftAction;
    private InputAction RightAction;

    public Animator animator;
    public bool isUp;

    public bool ArrIzq;
    public bool ArrDer;
    public bool AbajIzq;
    public bool AbajDer;

    public enum Esquina
    {
        ArribaIzquierda,
        ArribaDerecha,
        AbajoIzquierda,
        AbajoDerecha
    }

    public Esquina posicionActual = Esquina.ArribaIzquierda;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        UpAction = playerInput.actions.FindAction("PlayerMap/Arriba");
        DownAction = playerInput.actions.FindAction("PlayerMap/Abajo");
        LeftAction = playerInput.actions.FindAction("PlayerMap/Izquierda");
        RightAction = playerInput.actions.FindAction("PlayerMap/Derecha");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
                animator.SetBool("Abajo-Der-izq", false);
                animator.SetBool("Abajo-Izq-Der", false);
                animator.SetBool("AbajoDer-Abajo-Arriba", false);
                animator.SetBool("AbajoIzq-Abajo-Arriba", false);
                animator.SetBool("Arriba-Der-IZq", false);
                animator.SetBool("Arriba-Izq-Der", false);
                animator.SetBool("ArribaDer-Arriba-Abajo", false);
                animator.SetBool("ArribaIzq-Arriba-Abajo", false);
        */


        if (posicionActual == Esquina.ArribaIzquierda)
        {
            if (RightAction.triggered) // 0 = clic izquierdo
            {
                posicionActual = Esquina.ArribaDerecha;
                ResetBools();
                animator.SetBool("Arriba-Izq-Der", true);
            }
            if (DownAction.triggered) // 0 = clic izquierdo
            {
                posicionActual = Esquina.AbajoIzquierda;
                ResetBools();
                animator.SetBool("ArribaIzq-Arriba-Abajo", true);
            }
        }

        if (posicionActual == Esquina.AbajoIzquierda)
        {
            if (UpAction.triggered) // 0 = clic izquierdo
            {
                posicionActual = Esquina.ArribaIzquierda;
                ResetBools();
                animator.SetBool("AbajoIzq-Abajo-Arriba", true);
            }
            if (RightAction.triggered) // 0 = clic izquierdo
            {
                posicionActual = Esquina.AbajoDerecha;
                ResetBools();
                animator.SetBool("Abajo-Izq-Der", true);

            }
        }

        if (posicionActual == Esquina.AbajoDerecha)
        {
            if (UpAction.triggered) // 0 = clic izquierdo
            {
                posicionActual = Esquina.ArribaDerecha;
                ResetBools();
                animator.SetBool("AbajoDer-Abajo-Arriba", true);
            }
            if (LeftAction.triggered) // 0 = clic izquierdo
            {
                posicionActual = Esquina.AbajoIzquierda;
                ResetBools();
                animator.SetBool("Abajo-Der-izq", true);

            }
        }

        if (posicionActual == Esquina.ArribaDerecha)
        {
            if (DownAction.triggered) // 0 = clic izquierdo
            {
                posicionActual = Esquina.AbajoDerecha;
                ResetBools();
                animator.SetBool("ArribaDer-Arriba-Abajo", true);
            }
            if (LeftAction.triggered) // 0 = clic izquierdo
            {
                posicionActual = Esquina.ArribaIzquierda;
                ResetBools();
                animator.SetBool("Arriba-Der-IZq", true);

            }
        }

    }

    private void ResetBools()
    {
        animator.SetBool("Abajo-Der-izq", false);
        animator.SetBool("Abajo-Izq-Der", false);
        animator.SetBool("AbajoDer-Abajo-Arriba", false);
        animator.SetBool("AbajoIzq-Abajo-Arriba", false);
        animator.SetBool("Arriba-Der-IZq", false);
        animator.SetBool("Arriba-Izq-Der", false);
        animator.SetBool("ArribaDer-Arriba-Abajo", false);
        animator.SetBool("ArribaIzq-Arriba-Abajo", false);
    }

}
