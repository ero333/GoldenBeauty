using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchToNextScene : MonoBehaviour
{
    void Update()
    {
        // Detecta si se tocó la pantalla (móvil)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            LoadNextScene();
        }

        // Detecta clic del mouse (PC)
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }
}
