
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteAuto : MonoBehaviour
{
    [Header("Configuración Automática")]
    public int levelNumber = 1;
    public bool completeOnStart = true;
    public float delay = 0.5f; // Pequeño delay para asegurar que todo esté inicializado

    void Start()
    {
        if (completeOnStart)
        {
            // Pequeño delay para evitar problemas de inicialización
            Invoke("CompleteLevel", delay);
        }
    }

    void CompleteLevel()
    {
        if (GameManager.Instance != null)
        {
            // Verificar si este nivel ya estaba completado
            bool alreadyCompleted = GameManager.Instance.nvlSuperado >= levelNumber;

            // Completar el nivel si no lo estaba
            if (!alreadyCompleted)
            {
                GameManager.Instance.LevelCompleted(levelNumber);
                Debug.Log($"¡Nivel {levelNumber} completado automáticamente!");
            }
            else
            {
                Debug.Log($"Nivel {levelNumber} ya estaba completado previamente");
            }
        }
        else
        {
            Debug.LogError("GameManager no encontrado en la escena");
        }
    }

    // Método para forzar la completación manualmente
    public void ForceCompleteLevel()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LevelCompleted(levelNumber);
            Debug.Log($"¡Nivel {levelNumber} forzado a completado!");
        }
    }

    // Opcional: Completar al presionar una tecla (para testing)
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.C))
        {
            ForceCompleteLevel();
        }
#endif
    }
}

