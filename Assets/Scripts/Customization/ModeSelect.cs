using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelect : MonoBehaviour
{
    public Transform thisContain;

    float scale;

    Color32 originalCol;
    Color32 selectedCol;

    void Start()
    {
        scale = 1.1f;

        originalCol = gameObject.GetComponent<Image>().color;
        selectedCol = new Color32(185, 185, 185, 255);
    }
    public void OnEnterHover()
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(gameObject.GetComponent<RectTransform>().localScale.x * scale, gameObject.GetComponent<RectTransform>().localScale.y * scale, 1.0f);
    }
    public void OnExitHover()
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(gameObject.GetComponent<RectTransform>().localScale.x / scale, gameObject.GetComponent<RectTransform>().localScale.y / scale, 1.0f);
    }
    void ResetSelect()
    {
        foreach (Transform tool in transform.parent)
        {
            tool.GetComponent<Image>().color = originalCol;
        }
    }
    public void SelectMode()
    {
        ResetSelect();
        gameObject.GetComponent<Image>().color = selectedCol;
    }
}
