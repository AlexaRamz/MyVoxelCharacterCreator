using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pixel2D : MonoBehaviour, IPointerEnterHandler
{
    GameObject cSystem;
    void Start()
    {
        cSystem = GameObject.Find("CustomSys");
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        cSystem.GetComponent<Custom2D>().thisPix = gameObject;
    }
    void Update()
    {
        
    }
}
