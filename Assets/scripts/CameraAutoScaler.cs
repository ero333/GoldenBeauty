using UnityEngine;

[ExecuteAlways]
public class CameraAutoScaler : MonoBehaviour
{
    public float referenceWidth = 800f;
    public float referenceHeight = 600f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        AdjustCameraSize();
    }

    void Update()
    {
#if UNITY_EDITOR
        AdjustCameraSize(); // Para ver cambios en tiempo real
#endif
    }

    void AdjustCameraSize()
    {
        if (cam == null || !cam.orthographic) return;

        float targetAspect = referenceWidth / referenceHeight;
        float windowAspect = (float)Screen.width / Screen.height;

        cam.orthographicSize = (referenceHeight / 200f);

        // Si la pantalla es más alargada (móvil 16:9, 19:9, etc.)
        if (windowAspect > targetAspect)
        {
            // Ampliamos horizontalmente para mantener la vista completa
            float scale = windowAspect / targetAspect;
            cam.orthographicSize *= scale;
        }
    }
}
