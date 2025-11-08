using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Diario_2_LaPelicula_DLC : MonoBehaviour
{
    public Animator animator;

    private PlayerInput playerInput;
    private InputAction UpAction;

    public enum Esquina
    {
        ArribaIzquierda,
        ArribaDerecha,
        AbajoIzquierda,
        AbajoDerecha
    }

    public Esquina posicionActual = Esquina.ArribaIzquierda;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        UpAction = playerInput.actions.FindAction("PlayerMap/TouchPress");
    }

    void Update()
    {
        playerInput.SwitchCurrentActionMap("PlayerMap");

        DetectarClickZona();
    }

    void DetectarClickZona()
    {
        if (UpAction.triggered)
        {
            Vector2 clickPos = Input.mousePosition;

            float w = Screen.width;
            float h = Screen.height;

            bool zonaIzquierda = clickPos.x < w * 0.33f;
            bool zonaDerecha = clickPos.x > w * 0.66f;
            bool zonaCentroHorizontal = !zonaIzquierda && !zonaDerecha;

            bool zonaArriba = clickPos.y > h * 0.66f;
            bool zonaAbajo = clickPos.y < h * 0.33f;
            bool zonaCentroVertical = !zonaArriba && !zonaAbajo;

            ResetBools();

            switch (posicionActual)
            {
                case Esquina.ArribaIzquierda:
                    if (zonaDerecha)
                    {
                        posicionActual = Esquina.ArribaDerecha;
                        animator.SetBool("Arriba-Izq-Der", true);
                    }
                    else if (zonaAbajo && zonaCentroHorizontal)
                    {
                        posicionActual = Esquina.AbajoIzquierda;
                        animator.SetBool("ArribaIzq-Arriba-Abajo", true);
                    }
                    break;

                case Esquina.AbajoIzquierda:
                    if (zonaDerecha)
                    {
                        posicionActual = Esquina.AbajoDerecha;
                        animator.SetBool("Abajo-Izq-Der", true);
                    }
                    else if (zonaArriba && zonaCentroHorizontal)
                    {
                        posicionActual = Esquina.ArribaIzquierda;
                        animator.SetBool("AbajoIzq-Abajo-Arriba", true);
                    }
                    break;

                case Esquina.AbajoDerecha:
                    if (zonaIzquierda)
                    {
                        posicionActual = Esquina.AbajoIzquierda;
                        animator.SetBool("Abajo-Der-izq", true);
                    }
                    else if (zonaArriba && zonaCentroHorizontal)
                    {
                        posicionActual = Esquina.ArribaDerecha;
                        animator.SetBool("AbajoDer-Abajo-Arriba", true);
                    }
                    break;

                case Esquina.ArribaDerecha:
                    if (zonaIzquierda)
                    {
                        posicionActual = Esquina.ArribaIzquierda;
                        animator.SetBool("Arriba-Der-IZq", true);
                    }
                    else if (zonaAbajo && zonaCentroHorizontal)
                    {
                        posicionActual = Esquina.AbajoDerecha;
                        animator.SetBool("ArribaDer-Arriba-Abajo", true);
                    }
                    break;
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
