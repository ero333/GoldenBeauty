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
        if (UpAction.triggered) // 0 = clic izquierdo
        {
            Debug.Log("hola");
            animator.SetBool("isUp", false);
        }

        if (DownAction.triggered) // 0 = clic izquierdo
        {
            Debug.Log("holas");
            animator.SetBool("isUp", true);
        }

        if (UpAction.triggered) // 0 = clic izquierdo
        {
            Debug.Log("hola");
            animator.SetBool("IsRight", false);
        }

        if (DownAction.triggered) // 0 = clic izquierdo
        {
            Debug.Log("holas");
            animator.SetBool("IsRight", true);
        }
    }
}
