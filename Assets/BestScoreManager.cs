using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreManager : MonoBehaviour
{
    private static string Key(int nivel)
    {
        return "BestScore_Nivel_" + nivel;
    }

    public static void GuardarMejorPuntaje(int nivel, int puntaje)
    {
        string key = Key(nivel);

        int actual = PlayerPrefs.GetInt(key, 0);

        if (puntaje > actual)
        {
            PlayerPrefs.SetInt(key, puntaje);
            PlayerPrefs.Save();
        }
    }

    public static int ObtenerMejorPuntaje(int nivel)
    {
        return PlayerPrefs.GetInt(Key(nivel), 0);
    }
}
