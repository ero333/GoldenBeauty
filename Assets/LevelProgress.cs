using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public static LevelProgress Instance;

    [Header("Progreso por nivel (1 al 6)")]
    public int[] maxScores = new int[6];      // Puntaje máximo guardado
    public bool[] goodAcc = new bool[6];      // Accesorio correcto
    public bool[] goodPelo = new bool[6];     // Pelo correcto
    public bool[] goodRostro = new bool[6];   // Rostro correcto
    public bool[] goodRopa = new bool[6];     // Ropa correcta

    private void Awake()
    {
        // Singleton simple
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            LoadAllData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveLevelData(
        int nivel,
        int puntaje,
        bool acc, bool pelo, bool rostro, bool ropa)
    {
        int index = nivel - 1;

        // Guardar puntaje máximo
        if (puntaje > maxScores[index])
        {
            maxScores[index] = puntaje;
            PlayerPrefs.SetInt("MaxScore_" + nivel, puntaje);
        }

        // Guardar ítems correctos (si son mejores que antes)
        if (acc) PlayerPrefs.SetInt("GoodAcc_" + nivel, 1);
        if (pelo) PlayerPrefs.SetInt("GoodPelo_" + nivel, 1);
        if (rostro) PlayerPrefs.SetInt("GoodRostro_" + nivel, 1);
        if (ropa) PlayerPrefs.SetInt("GoodRopa_" + nivel, 1);

        // Actualizar variables locales
        goodAcc[index] = PlayerPrefs.GetInt("GoodAcc_" + nivel, 0) == 1;
        goodPelo[index] = PlayerPrefs.GetInt("GoodPelo_" + nivel, 0) == 1;
        goodRostro[index] = PlayerPrefs.GetInt("GoodRostro_" + nivel, 0) == 1;
        goodRopa[index] = PlayerPrefs.GetInt("GoodRopa_" + nivel, 0) == 1;

        PlayerPrefs.Save();
    }

    public void LoadAllData()
    {
        for (int i = 1; i <= 6; i++)
        {
            int index = i - 1;

            maxScores[index] = PlayerPrefs.GetInt("MaxScore_" + i, 0);

            goodAcc[index] = PlayerPrefs.GetInt("GoodAcc_" + i, 0) == 1;
            goodPelo[index] = PlayerPrefs.GetInt("GoodPelo_" + i, 0) == 1;
            goodRostro[index] = PlayerPrefs.GetInt("GoodRostro_" + i, 0) == 1;
            goodRopa[index] = PlayerPrefs.GetInt("GoodRopa_" + i, 0) == 1;
        }
    }
}

