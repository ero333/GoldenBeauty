using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static StaticVariables;
using static EventManager;
using Unity.VisualScripting;

public class NotaxNivel : MonoBehaviour
{
    public int nivelActual;
    public enum Nota
    {
        A,
        B,
        C,
        D
    }

    [Header("Accesorios")]
    public GameObject acc1;
    public GameObject acc2;
    public GameObject acc3;

    public int valAcc1;
    public int valAcc2;
    public int valAcc3;

    public bool valAcc1Correcto;
    public bool valAcc2Correcto;
    public bool valAcc3Correcto;

    [Header("Pelo")]
    public GameObject pelo1;
    public GameObject pelo2;
    public GameObject pelo3;
    public int valPelo1;
    public int valPelo2;
    public int valPelo3;

    public bool valPelo1Correcto;
    public bool valPelo2Correcto;
    public bool valPelo3Correcto;

    [Header("Rostro")]
    public GameObject rostro1;
    public GameObject rostro2;
    public GameObject rostro3;
    public int valRostro1;
    public int valRostro2;
    public int valRostro3;

    public bool valRostro1Corredcto;
    public bool valRostro2Corredcto;
    public bool valRostro3Corredcto;

    [Header("Ropa")]
    public GameObject ropa1;
    public GameObject ropa2;
    public GameObject ropa3;
    public int valRopa1;
    public int valRopa2;
    public int valRopa3;

    public bool valRopa1Correcto;
    public bool valRopa2Correcto;
    public bool valRopa3Correcto;

    [Header("Recuadros")]

    public GameObject recuadroAcc1;
    public GameObject recuadroAcc2;
    public GameObject recuadroAcc3;
    public GameObject recuadroPelo1;
    public GameObject recuadroPelo2;
    public GameObject recuadroPelo3;
    public GameObject recuadroRostro1;
    public GameObject recuadroRostro2;
    public GameObject recuadroRostro3;
    public GameObject recuadroRopa1;
    public GameObject recuadroRopa2;
    public GameObject recuadroRopa3;


    private void Start()
    {
        CargarCorrectos();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetearPrefs();
        }
    }

    public int CalcularPuntaje()
    {
        int suma = 0;

        if (acc1.activeInHierarchy) suma += valAcc1;
        if (acc2.activeInHierarchy) suma += valAcc2;
        if (acc3.activeInHierarchy) suma += valAcc3;

        if (pelo1.activeInHierarchy) suma += valPelo1;
        if (pelo2.activeInHierarchy) suma += valPelo2;
        if (pelo3.activeInHierarchy) suma += valPelo3;

        if (rostro1.activeInHierarchy) suma += valRostro1;
        if (rostro2.activeInHierarchy) suma += valRostro2;
        if (rostro3.activeInHierarchy) suma += valRostro3;

        if (ropa1.activeInHierarchy) suma += valRopa1;
        if (ropa2.activeInHierarchy) suma += valRopa2;
        if (ropa3.activeInHierarchy) suma += valRopa3;

        return suma;
    }

    public Nota ObtenerLetra(int puntaje)
    {
        if (puntaje < 4)
            return Nota.D;

        if (puntaje == 4)
            return Nota.C;

        if (puntaje == 5 || puntaje == 6 || puntaje == 7)
            return Nota.B;

        if (puntaje == 8)
            return Nota.A;

        return Nota.D;
    }

    public void Ganar()
    {
        int puntaje = CalcularPuntaje();
        Nota nota = ObtenerLetra(puntaje);

        Debug.Log("Puntaje final: " + puntaje + " | Nota: " + nota);

        switch (nota)
        {
            case Nota.A:
                Debug.Log("Animación A");
                break;

            case Nota.B:
                Debug.Log("Animación B");
                break;

            case Nota.C:
                Debug.Log("Animación C");
                break;

            case Nota.D:
                Debug.Log("Animación D");
                break;
        }

        //GameManager.Instance.GuardarPuntajeMaximo(nivelActual, puntaje);

        StartCoroutine(BienSeleccionados());

        //BestScoreManager.GuardarMejorPuntaje(nivelActual, puntaje);
    }


    private IEnumerator BienSeleccionados()
    {
        yield return new WaitForSeconds(0.5f);

        // ACC1
        if (acc1.activeInHierarchy && valAcc1 == 2)
        {
            valAcc1Correcto = true;
            Debug.Log("ACC1 correcto");
        }

        // ACC2
        if (acc2.activeInHierarchy && valAcc2 == 2)
        {
            valAcc2Correcto = true;
            Debug.Log("ACC2 correcto");
        }

        // ACC3
        if (acc3.activeInHierarchy && valAcc3 == 2)
        {
            valAcc3Correcto = true;
            Debug.Log("ACC3 correcto");
        }

        // PELO1
        if (pelo1.activeInHierarchy && valPelo1 == 2)
        {
            valPelo1Correcto = true;
            Debug.Log("PELO1 correcto");
        }

        // PELO2
        if (pelo2.activeInHierarchy && valPelo2 == 2)
        {
            valPelo2Correcto = true;
            Debug.Log("PELO2 correcto");
        }

        // PELO3
        if (pelo3.activeInHierarchy && valPelo3 == 2)
        {
            valPelo3Correcto = true;
            Debug.Log("PELO3 correcto");
        }

        // ROSTRO1
        if (rostro1.activeInHierarchy && valRostro1 == 2)
        {
            valRostro1Corredcto = true;
            Debug.Log("ROSTRO1 correcto");
        }

        // ROSTRO2
        if (rostro2.activeInHierarchy && valRostro2 == 2)
        {
            valRostro2Corredcto = true;
            Debug.Log("ROSTRO2 correcto");
        }

        // ROSTRO3
        if (rostro3.activeInHierarchy && valRostro3 == 2)
        {
            valRostro3Corredcto = true;
            Debug.Log("ROSTRO3 correcto");
        }

        // ROPA1
        if (ropa1.activeInHierarchy && valRopa1 == 2)
        {
            valRopa1Correcto = true;
            Debug.Log("ROPA1 correcto");
        }

        // ROPA2
        if (ropa2.activeInHierarchy && valRopa2 == 2)
        {
            valRopa2Correcto = true;
            Debug.Log("ROPA2 correcto");
        }

        // ROPA3
        if (ropa3.activeInHierarchy && valRopa3 == 2)
        {
            valRopa3Correcto = true;
            Debug.Log("ROPA3 correcto");
        }

        GuardarCorrectos();
    }

    public void GuardarCorrectos()
    {
        Guardar("Acc1", valAcc1Correcto);
        Guardar("Acc2", valAcc2Correcto);
        Guardar("Acc3", valAcc3Correcto);

        Guardar("Pelo1", valPelo1Correcto);
        Guardar("Pelo2", valPelo2Correcto);
        Guardar("Pelo3", valPelo3Correcto);

        Guardar("Rostro1", valRostro1Corredcto);
        Guardar("Rostro2", valRostro2Corredcto);
        Guardar("Rostro3", valRostro3Corredcto);

        Guardar("Ropa1", valRopa1Correcto);
        Guardar("Ropa2", valRopa2Correcto);
        Guardar("Ropa3", valRopa3Correcto);
    }

    public void Guardar(string nombre, bool valor)
    {
        if (valor)
        {
            PlayerPrefs.SetInt("Nivel" + nivelActual + "_" + nombre, 1);
            PlayerPrefs.Save();
        }

        Debug.Log("Guardando: Nivel" + nivelActual + "_" + nombre + " = " + PlayerPrefs.GetInt("Nivel" + nivelActual + "_" + nombre));
    }


    //CARGAR EN EL START

    public void CargarCorrectos()
    {
        // ACCESORIOS
        recuadroAcc1.SetActive(PlayerPrefs.GetInt("Nivel" + nivelActual + "_Acc1", 0) == 1);
        recuadroAcc2.SetActive(PlayerPrefs.GetInt("Nivel" + nivelActual + "_Acc2", 0) == 1);
        recuadroAcc3.SetActive(PlayerPrefs.GetInt("Nivel" + nivelActual + "_Acc3", 0) == 1);

        // PELO
        recuadroPelo1.SetActive(PlayerPrefs.GetInt("Nivel" + nivelActual + "_Pelo1", 0) == 1);
        recuadroPelo2.SetActive(PlayerPrefs.GetInt("Nivel" + nivelActual + "_Pelo2", 0) == 1);
        recuadroPelo3.SetActive(PlayerPrefs.GetInt("Nivel" + nivelActual + "_Pelo3", 0) == 1);

        // ROSTRO
        recuadroRostro1.SetActive(PlayerPrefs.GetInt("Nivel" + nivelActual + "_Rostro1", 0) == 1);
        recuadroRostro2.SetActive(PlayerPrefs.GetInt("Nivel" + nivelActual + "_Rostro2", 0) == 1);
        recuadroRostro3.SetActive(PlayerPrefs.GetInt("Nivel" + nivelActual + "_Rostro3", 0) == 1);

        // ROPA
        recuadroRopa1.SetActive(PlayerPrefs.GetInt("Nivel" + nivelActual + "_Ropa1", 0) == 1);
        recuadroRopa2.SetActive(PlayerPrefs.GetInt("Nivel" + nivelActual + "_Ropa2", 0) == 1);
        recuadroRopa3.SetActive(PlayerPrefs.GetInt("Nivel" + nivelActual + "_Ropa3", 0) == 1);

    }

    public void ResetearPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs RESETADOS");
    }


}

