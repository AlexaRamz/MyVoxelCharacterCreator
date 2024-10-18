using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Custom2D : MonoBehaviour
{
    public bool canEdit;
    public Object pixelRef;

    public string tool;
    public Color32 thisColor;
    public GameObject colDisplay;

    public GameObject container;
    public GameObject savedHere;
    public Object saveRef;
    GameObject currentSave;
    public GameObject referencePixel;
  
    Vector3 leftBottomLocation;
    public int rows;
    public int columns;

    public bool InBound;

    public GameObject thisPix;
    Vector3 pixPos;

    void Start()
    {
        thisColor = new Color32(255, 0, 0, 255);
        LoadNew();
    }
    public void Clear()
    {
        foreach (Transform child in container.transform)
        {
            GameObject thisPix = child.gameObject;
            Destroy(thisPix);
        }
    }
    void ClearSaves()
    {
        foreach (Transform child in savedHere.transform)
        {
            GameObject thisPix = child.gameObject;
            Destroy(thisPix);
        }
    }
    public void LoadNew()
    {
        Clear();
        GameObject newLoad = (GameObject)Instantiate(saveRef);
        newLoad.name = "Save1";
        newLoad.transform.SetParent(container.transform);
        newLoad.transform.localPosition = new Vector3(0, 0, 0);
        currentSave = newLoad;
        Grid();
    }
    public void LoadThis()
    {
        string saveName = "Save1";
        if (savedHere.transform.Find(saveName))
        {
            Clear();
            Transform thisSave = savedHere.transform.Find(saveName);
            GameObject newLoad = (GameObject)Instantiate(thisSave.gameObject);
            newLoad.name = thisSave.name;
            newLoad.transform.SetParent(container.transform);
            newLoad.transform.localPosition = new Vector3(0, 0, 0);
            newLoad.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
            currentSave = newLoad;
        }
    }
    public void UpdateDesign()
    {
        if (currentSave != null)
        {
            ClearSaves();
            GameObject newLoad = (GameObject)Instantiate(currentSave);
            newLoad.name = currentSave.name;
            newLoad.transform.SetParent(savedHere.transform);
            newLoad.transform.localPosition = new Vector3(0, 0, 0);
            newLoad.GetComponent<RectTransform>().localScale = new Vector3(0.25f, 0.25f, 1.0f);
        }
        Clear();
    }
    void Paint(GameObject thisPix)
    {
        thisPix.GetComponent<Image>().color = thisColor;
    }
    void Fill()
    {
        foreach (Transform child in currentSave.transform)
        {
            Paint(child.gameObject);
        }
    }
    void Delete(GameObject thisPix)
    {
        thisPix.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
    }
    void Add(Vector3 newPos)
    {
        GameObject newpixel = (GameObject)Instantiate(pixelRef);
        newpixel.transform.SetParent(currentSave.transform);
        newpixel.transform.position = newPos;
        Delete(newpixel);
    }
    void Grid()
    {
        float scale1;
        float scale2;
        float objectWidth;
        float objectHeight;

        Vector2 size = container.GetComponent<RectTransform>().sizeDelta;

        objectWidth = size.x / 2;
        objectHeight = size.y / 2;

        scale1 = size.x / columns;
        scale2 = size.y / rows;

        Vector2 centerPos = container.transform.position;

        leftBottomLocation.x = centerPos.x - objectWidth + scale1 / 2;
        leftBottomLocation.y = centerPos.y - objectHeight + scale2 / 2;
        leftBottomLocation.z = 0;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector3 thisPos = new Vector3(leftBottomLocation.x + scale1 * i, leftBottomLocation.y + scale2 * j, 0);
                Add(thisPos);
            }
        }
    }
    void Update()
    {
        Vector3 centerPos = container.transform.position;
        Vector3 mousePos = Input.mousePosition;
        
        float xShift = container.GetComponent<RectTransform>().sizeDelta.x / 2;
        float yShift = container.GetComponent<RectTransform>().sizeDelta.y / 2;

        float leftBound = centerPos.x - xShift;
        float rightBound = centerPos.x + xShift;
        float topBound = centerPos.y + yShift;
        float bottomBound = centerPos.y + -yShift;

        if (canEdit == true && mousePos.x <= rightBound && mousePos.x >= leftBound && mousePos.y <= topBound && mousePos.y >= bottomBound)
        {
            InBound = true;
        }
        else
        {
            InBound = false;
        }

        if (thisPix != null && InBound)
        {
            pixPos = thisPix.transform.position;
            referencePixel.transform.position = pixPos;
            referencePixel.GetComponent<Image>().enabled = true;
        }
        else
        {
            referencePixel.GetComponent<Image>().enabled = false;
            referencePixel.transform.position = new Vector3(0, 0, 0);
        }
        if (Input.GetMouseButton(0) && InBound)
        {
            if (canEdit && thisPix != null)
            {
                if (tool == "PaintTool2D")
                {
                    Paint(thisPix);
                }
                if (tool == "DeleteTool2D")
                {
                    Delete(thisPix);
                }
                if (tool == "BucketTool2D")
                {
                    Fill();
                }
            }
        }
    }
}