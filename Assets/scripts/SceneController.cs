using UnityEngine;
using UnityEngine.SceneManagement; // 👈 necesario


public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

    }

    public void PasarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
