using UnityEngine;
using UnityEngine.InputSystem;

public class diariotest : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction leftAction;
    private InputAction rightAction;
    private InputAction upAction;
    private InputAction downAction;

    [Header("Required Image References")]
    [SerializeField] private GameObject imagenA;
    [SerializeField] private GameObject leftImage;
    [SerializeField] private GameObject rightImage;
    [SerializeField] private GameObject upImage;
    [SerializeField] private GameObject downImage;

    [Header("Direction Bools")]
    public bool isUp;
    public bool isDown;
    public bool isLeft;
    public bool isRight;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        if (playerInput == null)
        {
            Debug.LogError("PlayerInput component not found on GameObject.");
            enabled = false;
            return;
        }

        // Initialize input actions safely
        leftAction = playerInput.actions.FindAction("PlayerMap/Izquierda");
        rightAction = playerInput.actions.FindAction("PlayerMap/Derecha");
        upAction = playerInput.actions.FindAction("PlayerMap/Arriba");
        downAction = playerInput.actions.FindAction("PlayerMap/Abajo");

        // Log any missing actions
        if (leftAction == null) Debug.LogError("Missing input action: PlayerMap/Izquierda");
        if (rightAction == null) Debug.LogError("Missing input action: PlayerMap/Derecha");
        if (upAction == null) Debug.LogError("Missing input action: PlayerMap/Arriba");
        if (downAction == null) Debug.LogError("Missing input action: PlayerMap/Abajo");
    }

    private void Update()
    {
        if (leftAction != null && leftAction.triggered && isLeft)
        {
            ActivateImage(leftImage);
        }

        if (rightAction != null && rightAction.triggered && isRight)
        {
            ActivateImage(rightImage);
        }

        if (upAction != null && upAction.triggered && isUp)
        {
            ActivateImage(upImage);
        }

        if (downAction != null && downAction.triggered && isDown)
        {
            ActivateImage(downImage);
        }
    }

    private void ActivateImage(GameObject targetImage)
    {
        if (targetImage == null)
        {
            Debug.LogWarning("Attempted to activate a null image object.");
            return;
        }

        targetImage.SetActive(true);
        gameObject.SetActive(false);
    }

    // Optional: Public method to activate ImagenA externally
    public void ActivateImagenA()
    {
        if (imagenA != null)
        {
            imagenA.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("ImagenA is not assigned in the inspector.");
        }
    }
}
