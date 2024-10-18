using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelect : MonoBehaviour
{
    Color32 newColor;
    public GameObject cSystem;

    void Start()
    {
        newColor = gameObject.GetComponent<Image>().color;
    }
    public void SelectColor2D()
    {
        GameObject colDisplay = cSystem.GetComponent<Custom2D>().colDisplay;
        cSystem.GetComponent<Custom2D>().thisColor = newColor;
        colDisplay.GetComponent<Image>().color = newColor;
    }
    public void SelectColor()
    {
        GameObject colDisplay = cSystem.GetComponent<Customization>().colDisplay;
        cSystem.GetComponent<Customization>().thisColor = newColor;
        colDisplay.GetComponent<Image>().color = newColor;
    }
    void UpdateItems()
    {
        Transform items = cSystem.GetComponent<Customization>().itemContain;
        foreach (Transform item in items)
        {
            if (item != null)
            {
                item.Find("Image").GetComponent<Image>().color = newColor;
            }
        }
    }
    public void EyeColor()
    {
        UpdateItems();

        //Transform plrFace = cSystem.GetComponent<Customization>().plrFace;
        //plrFace.Find("Iris").GetComponent<SpriteRenderer>().color = newColor;

        SelectColor();
    }
    public void HairColor()
    {
        Transform items = GameObject.Find("HairTextures").transform;
        foreach (Transform item in items)
        {
            Transform thisModel = item.Find("Model");
            thisModel.Find("default").GetComponent<Renderer>().material.SetColor("_Color", newColor);
        }
        Transform plr = GameObject.Find("Player").transform;
        Transform part = plr.Find("Hair");
        Transform model = part.Find("Model");
        model.Find("default").GetComponent<Renderer>().material.SetColor("_Color", newColor);

        SelectColor();
    }
    void Update()
    {

    }
}
