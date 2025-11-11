using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CalificarArte : MonoBehaviour
{
    public SceneController sceneController;
    public GameObject[] hoverAreas; // 5 objetos SOLO para detección (siempre activos)
    public GameObject[] starSprites; // 5 sprites visuales (se activan/desactivan)

    private Camera mainCamera;
    private int hoveredIndex = -1;
    private int selectedRating = -1;

    private void Start()
    {
        mainCamera = Camera.main;

        foreach (GameObject area in hoverAreas)
            if (area != null) area.SetActive(true);

        foreach (GameObject star in starSprites)
            if (star != null) star.SetActive(false);
    }

    private void Update()
    {
        UpdateHoveredIndex();

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (hoveredIndex >= 0)
            {
                selectedRating = hoveredIndex;
                Debug.Log($"⭐ Calificación ARTE: {selectedRating + 1}");
            }
        }

        UpdateStarVisuals();
    }

    private void UpdateHoveredIndex()
    {
        hoveredIndex = -1;

        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition2D = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);

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
    }

    private void UpdateStarVisuals()
    {
        int starsToShow = hoveredIndex >= 0 ? hoveredIndex : selectedRating;

        for (int i = 0; i < starSprites.Length; i++)
            if (starSprites[i] != null)
                starSprites[i].SetActive(i <= starsToShow && starsToShow >= 0);
    }

    public void OnButtonClick()
    {
        // Enviar evento (opcional)
        // EventManager.Instance.LogEvent("calificar_arte", new Dictionary<string, object> { { "arte", selectedRating + 1 } });

        sceneController.LoadScene("Menu inicio");
    }
}

