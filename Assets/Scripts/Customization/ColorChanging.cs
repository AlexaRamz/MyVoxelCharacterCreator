using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    public Color32 originalColor;
    Renderer rend;
    GameObject cSystem;
    Color32 sColor;

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        sColor = new Color32(151, 189, 255, 255);

        originalColor = rend.material.color;
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            Color32 hoverColor;
            hoverColor = sColor;
            rend.material.SetColor("_Color", hoverColor);
        }
        else
        {
            rend.material.SetColor("_Color", originalColor);
        }
    }
}
