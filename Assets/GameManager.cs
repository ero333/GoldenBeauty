//using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Variables de progreso
    public int currentZone;
    public int nvlSuperado;

    // Keys para PlayerPrefs
    private const string CURRENT_ZONE_KEY = "CurrentZone";
    private const string NIVL_SUPERADO_KEY = "NvlSuperado";

    void Awake()
    {
        // Implementaci�n del Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadGameData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Cargar datos guardados
    public void LoadGameData() // Cambiado a p�blico
    {
        currentZone = PlayerPrefs.GetInt(CURRENT_ZONE_KEY, 1);
        nvlSuperado = PlayerPrefs.GetInt(NIVL_SUPERADO_KEY, 0);
        Debug.Log($"Datos cargados: currentZone={currentZone}, nvlSuperado={nvlSuperado}");
    }

    // Guardar datos
    public void SaveGameData()
    {
        PlayerPrefs.SetInt(CURRENT_ZONE_KEY, currentZone);
        PlayerPrefs.SetInt(NIVL_SUPERADO_KEY, nvlSuperado);
        PlayerPrefs.Save();
        Debug.Log($"Datos guardados: currentZone={currentZone}, nvlSuperado={nvlSuperado}");
    }

    // Cuando se supera un nivel
    public void LevelCompleted(int levelNumber)
    {
        if (levelNumber > nvlSuperado)
        {
            nvlSuperado = levelNumber;
            currentZone = levelNumber + 1; // Desbloquea el siguiente nivel
            SaveGameData();
            Debug.Log($"Nivel {levelNumber} completado. Nuevo nivel desbloqueado: {currentZone}");
        }
    }

    // Verificar si un nivel est� desbloqueado
    public bool IsLevelUnlocked(int levelNumber)
    {
        return levelNumber <= currentZone;
    }

    // Reiniciar progreso
    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey(CURRENT_ZONE_KEY);
        PlayerPrefs.DeleteKey(NIVL_SUPERADO_KEY);
        currentZone = 1;
        nvlSuperado = 0;
        SaveGameData();
        Debug.Log("Progreso reiniciado");
    }

    // Para WebGL: guardar cuando la aplicaci�n pierde el foco
    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus) SaveGameData();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) SaveGameData();
    }

    void Update()
    {
        // Detectar tecla R para resetear progreso
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetProgress();
        }
    }
}
