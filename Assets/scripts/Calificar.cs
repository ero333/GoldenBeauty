using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static EventManager;
using static StaticVariables;

public class Calificar : MonoBehaviour
{
    public SceneController sceneController;
    public GameObject[] hoverAreas; // 5 objetos SOLO para detección (siempre activos)
    public GameObject[] starSprites; // 5 sprites visuales (se activan/desactivan)

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

        // Asegurar que todas las áreas de hover estén ACTIVAS
        foreach (GameObject area in hoverAreas)
        {
            if (area != null) area.SetActive(true);
        }

        // Todas las estrellas visuales INACTIVAS al inicio
        foreach (GameObject star in starSprites)
        {
            if (star != null) star.SetActive(false);
        }
    }

    private void Update()
    {
        int hoveredIndex = -1;
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition2D = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);

        // Detectar hover en las áreas siempre activas
        for (int i = 0; i < hoverAreas.Length; i++)
        {
            if (hoverAreas[i] == null) continue;

            BoxCollider2D collider = hoverAreas[i].GetComponent<BoxCollider2D>();
            if (collider != null && collider.OverlapPoint(mousePosition2D))
            {
                hoveredIndex = i;
                break;
            }
        }

        // Actualizar las estrellas visuales
        for (int i = 0; i < starSprites.Length; i++)
        {
            if (starSprites[i] != null)
            {
                starSprites[i].SetActive(i <= hoveredIndex);
            }
        }
    }
    public void OnButtonClick()
    {
       // EventManager.Instance.LogLevelStart(1);
        sceneController.LoadScene("Menu inicio");
    }

}

