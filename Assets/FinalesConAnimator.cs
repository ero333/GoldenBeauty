using UnityEngine;
using UnityEngine.InputSystem;

public class FinalesConAnimator : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction clickAction;

    public Animator animator;
    public bool isUp;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();

        // Buscamos la acción de click (asegurate de tenerla en el mapa)
        clickAction = playerInput.actions.FindAction("Click");
    }

    void Update()
    {
        playerInput.SwitchCurrentActionMap("PlayerMap");

        if (clickAction != null && clickAction.triggered)
        {
            isUp = !isUp; // Alterna entre true/false
            animator.SetBool("isUp", isUp);

            Debug.Log(isUp ? "Sube" : "Baja");
        }
    }
}
