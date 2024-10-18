using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSelect : MonoBehaviour
{
    GameObject invSys;

    string itemName;
    public string itemType;

    float scale;

    void Start()
    {
        invSys = GameObject.Find("InventorySys");

        itemName = gameObject.name;

        scale = 1.1f;
    }
    public void EquipItem()
    {
        invSys.GetComponent<Inventory>().Equip(itemName, itemType);
    }
    public void OnEnterHover()
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(gameObject.GetComponent<RectTransform>().localScale.x * scale, gameObject.GetComponent<RectTransform>().localScale.y * scale, 1.0f);
    }
    public void OnExitHover()
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(gameObject.GetComponent<RectTransform>().localScale.x / scale, gameObject.GetComponent<RectTransform>().localScale.y / scale, 1.0f);
    }
    void Update()
    {

    }
}
