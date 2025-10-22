using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class FinalesConAnimator : MonoBehaviour
{

    private PlayerInput playerInput;
    private InputAction UpAction;
    private InputAction DownAction;

    public Animator animator;
    public bool isUp;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        UpAction = playerInput.actions.FindAction("PlayerMap/Arriba");
        DownAction = playerInput.actions.FindAction("PlayerMap/Abajo");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (UpAction.triggered) // 0 = clic izquierdo
        {
            Debug.Log("hola");
                animator.SetBool("isUp",false);
        }

        if (DownAction.triggered) // 0 = clic izquierdo
        {
            Debug.Log("holas");
                animator.SetBool("isUp", true);
        }

    }


}
