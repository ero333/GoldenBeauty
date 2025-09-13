using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LoopFinalBueno : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction forwardAction;
    private InputAction backAction;
    public GameObject ImagenA;
    public GameObject ImagenB;

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

        if (forwardAction.triggered) // 0 = clic izquierdo
        {
            Debug.Log("Se hizo el espacio");
            Amongas();
        }

    }



    private void Amongas()
    {
        ImagenA.SetActive(true);
        gameObject.SetActive(false);
    }

    }
