using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customization : MonoBehaviour
{
    public bool canEdit;
    bool canRepeat;

    public string tool;

    public Color thisColor;
    public GameObject colDisplay;
  
    public Object pixelRef;
    public GameObject thisPixel;

    Ray ray;
    RaycastHit hit;

    public float pScale;

    public GameObject container;
 
    public Transform itemContain;

    void Start()
    {
        canRepeat = true;
    }
    void SetColor()
    {
        thisPixel.GetComponent<Renderer>().material.SetColor("_Color", thisColor);
        thisPixel.GetComponent<ColorChanging>().originalColor = thisColor;
    }
    void FillColor()
    {
        foreach (Transform child in container.transform)
        {
            if (child.tag == "DrawPixel")
            {
                child.GetComponent<Renderer>().material.SetColor("_Color", thisColor);
                child.GetComponent<ColorChanging>().originalColor = thisColor;
            }
        }
    }
    void Delete()
    {
        Destroy(thisPixel);
        canRepeat = false;
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        canRepeat = true;
    }

    void Sculpt(Vector3 pointPos)
    {
        GameObject newpixel = (GameObject)Instantiate(pixelRef);
        Vector3 pixelPos = thisPixel.transform.position;

        newpixel.transform.position = thisPixel.transform.position + pointPos;
        newpixel.GetComponent<Renderer>().material.SetColor("_Color", thisColor);
        newpixel.GetComponent<ColorChanging>().originalColor = thisColor;
        newpixel.transform.SetParent(container.transform);
        canRepeat = false;
        StartCoroutine(Delay());
    }
    void Update()
    {
        Vector3 pointPos;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "DrawPixel")
        {
            thisPixel = hit.collider.gameObject;
            pointPos = hit.normal * pScale;
        }
        else
        {
            thisPixel = null;
            pointPos = new Vector3(0, 0, 0);
        }

        if (canEdit == true && Input.GetMouseButton(0) && thisPixel != null && canRepeat == true)
        {
            if (tool == "SculptTool")
            {
                Sculpt(pointPos);
            }
            if (tool == "DeleteTool")
            {
                Delete();
            }
            if (tool == "PaintTool")
            {
                SetColor();
            }
            if (tool == "BucketTool")
            {
                FillColor();
            }
        }
    }
}