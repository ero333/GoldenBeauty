using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class FinalesConAnimator : MonoBehaviour
{

    private PlayerInput playerInput;
    private InputAction forwardAction;
    private InputAction backAction;

    public Animator animator;
    public bool isUp;
    public bool isDown;
    public bool goesUp;
    public bool goesDown;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        forwardAction = playerInput.actions.FindAction("PlayerMap/SpaceBoy");
        backAction = playerInput.actions.FindAction("PlayerMap/Back");
    }

    // Update is called once per frame
    void Update()
    {
        if (forwardAction.triggered) // 0 = clic izquierdo
        {
            Debug.Log("hola");
            if (isUp && !isDown && !goesUp && !goesDown)
            {
                goesDown = true;
                goesUp = false;
                isDown = false;
                isUp = false;
            }

            if (!isUp && isDown && !goesUp && !goesDown)
            {
                goesDown = true;
                goesUp = true;
                isDown = false;
                isUp = false;
            }

            /*if (isUp && !isDown && !goesUp && !goesDown)
            {
                goesDown = true;
                goesUp = false;
                isDown = false;
            }

            if (isUp && !isDown && !goesUp && !goesDown)
            {
                goesDown = true;
                goesUp = false;
                isDown = false;
            }*/

        }

    }

    public void GoesUP()
    {
        goesDown = false;
        goesUp = false;
        isDown = false;
        isUp = true;
    }

    public void GoesDown()
    {
        goesDown = false;
        goesUp = false;
        isDown = true;
        isUp = false;
    }

}
