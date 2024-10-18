using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSelect : MonoBehaviour
{
    public GameObject thisShop;
    GameObject invSys;

    string itemName;
    ShopItem myItem;
    string itemType;
    int itemPrice;
    RenderTexture itemImage;
    Object itemRef;
    Vector3 itemAttach;
    Vector3 itemRot;

    Color32 originalCol;
    Color32 selectedCol;

    float scale;

    void Start()
    {
        invSys = GameObject.Find("InventorySys");
        originalCol = gameObject.GetComponent<Image>().color;
        selectedCol = new Color32(185, 185, 185, 255);

        scale = 1.1f;
    }
    void GetItemInfo()
    {
        //update item info
        string newItem = thisShop.GetComponent<ShopManager>().thisItem;

        foreach (ShopItem item in thisShop.GetComponent<ShopManager>().items)
        {
            if (item.name == newItem)
            {
                myItem = item;
                itemName = item.name;
                itemType = item.type;
                itemPrice = item.price;
                itemImage = item.texture;
                itemRef = item.Ref;
                itemAttach = item.attachment;
                itemRot = item.orientation;
            }
        }

    }
    void DisplayItem(string thisName, int price, RenderTexture thisImage)
    {
        GameObject shopFace = thisShop.GetComponent<ShopManager>().shopFace;
        Transform display = shopFace.transform.Find("Display");

        Transform image = display.Find("RawImage");
        image.GetComponent<RawImage>().texture = thisImage;
        image.GetComponent<RawImage>().enabled = true;

        Transform info = display.Find("Info");
        Transform priceDis = info.Find("Text");
        priceDis.GetComponent<Text>().text = price.ToString();
    }
    void ResetSelect()
    {
        Transform container = thisShop.GetComponent<ShopManager>().container;

        foreach (Transform item in container)
        {
            item.GetComponent<Image>().color = originalCol;
        }
    }
    public void SelectItem()
    {
        ResetSelect();
        gameObject.GetComponent<Image>().color = selectedCol;

        string newItem = gameObject.name;
        thisShop.GetComponent<ShopManager>().thisItem = newItem;

        GetItemInfo();
        DisplayItem(itemName, itemPrice, itemImage);
    }
    public void BuyItem()
    {
        if (thisShop.GetComponent<ShopManager>().thisItem != "")
        {
            GetItemInfo();
            if (invSys.GetComponent<Inventory>().goldCount >= itemPrice)
            {
                invSys.GetComponent<Inventory>().goldCount -= itemPrice;

                invSys.GetComponent<Inventory>().AddItem(myItem, itemType);  
            }
            else
            {
                Debug.Log("can't afford");
            }
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
    void Update()
    {
        
    }
}
