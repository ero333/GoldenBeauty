using UnityEngine;
using UnityEngine.EventSystems;

public class FinalesConAnimator : MonoBehaviour
{
    public Animator animator;
    public bool isUp;

    void Update()
    {
        // Si el click/touch se hace sobre UI, no ejecutar nada
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        // Detecta clic o toque (funciona en WebGL, móvil y PC)
        if (Input.GetMouseButtonDown(0))
        {
            isUp = !isUp;
            animator.SetBool("isUp", isUp);
            Debug.Log(isUp ? "⬆️ Sube" : "⬇️ Baja");
        }
    }
}
