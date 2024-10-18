using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolSelect : MonoBehaviour
{
    string newtool;

    public GameObject cSystem;

    float scale;

    Color32 originalCol;
    Color32 selectedCol;

    void Start()
    {
        newtool = gameObject.name;
        scale = 1.1f;

        originalCol = gameObject.GetComponent<Image>().color;
        selectedCol = new Color32(185, 185, 185, 255);
    }
    void ResetSelect()
    {
        foreach (Transform tool in transform.parent)
        {
            tool.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
            Transform outline = tool.Find("Image");
            outline.GetComponent<Image>().enabled = false;
        }
    }
    public void OnEnterHover()
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(gameObject.GetComponent<RectTransform>().localScale.x * scale, gameObject.GetComponent<RectTransform>().localScale.y * scale, 1.0f);
    }
    public void OnExitHover()
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(gameObject.GetComponent<RectTransform>().localScale.x / scale, gameObject.GetComponent<RectTransform>().localScale.y / scale, 1.0f);
    }
    public void SelectTool()
    {
        ResetSelect();
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(scale * scale, scale * scale, 1.0f);
        Transform outline = transform.Find("Image");
        outline.GetComponent<Image>().enabled = true;
        cSystem.GetComponent<Customization>().tool = newtool;
    }
    public void SelectTool2D()
    {
        ResetSelect();
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(scale * scale, scale * scale, 1.0f);
        Transform outline = transform.Find("Image");
        outline.GetComponent<Image>().enabled = true;
        cSystem.GetComponent<Custom2D>().tool = newtool;
    }
    public void UpdateDesign2D()
    {
        cSystem.GetComponent<Custom2D>().UpdateDesign();
        cSystem.GetComponent<Custom2D>().canEdit = false;
    }
    public void Cancel2D()
    {
        cSystem.GetComponent<Custom2D>().Clear();
        cSystem.GetComponent<Custom2D>().canEdit = false;
    }
    public void Load2D()
    {
        cSystem.GetComponent<Custom2D>().LoadThis();
        cSystem.GetComponent<Custom2D>().canEdit = true;
    }
    public void LoadNew2D()
    {
        cSystem.GetComponent<Custom2D>().LoadNew();
        cSystem.GetComponent<Custom2D>().canEdit = true;
    }
    void Update()
    {

    }
}
