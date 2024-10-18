using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ShopItem[] items;
    public GameObject shopFace;
    public Transform container;
    public GameObject button;
    public string thisItem;
    public Object itemRef;
    public GameObject mManager;
    //public sprite background;
    
    void Start()
    {
       
    }
    void ClearShop()
    {
        thisItem = "";
        foreach (Transform item in container)
        {
            Destroy(item.gameObject);
        }
        Transform display = shopFace.transform.Find("Display");
        Transform image = display.Find("RawImage");
        image.GetComponent<RawImage>().enabled = false;

        Transform info = display.Find("Info");
        Transform priceDis = info.Find("Text");
        priceDis.GetComponent<Text>().text = "0";
    }
    void SetMenus()
    {
        gameObject.GetComponent<OpenMenu>().Open();
    }
    void AddInv()
    {
        foreach (ShopItem item in items)
        {
            if (item.name != "")
            {
                GameObject newItem = (GameObject)Instantiate(itemRef);
                newItem.transform.SetParent(container, false);
                newItem.name = item.name;
                newItem.transform.Find("RawImage").GetComponent<RawImage>().texture = item.texture;

                newItem.GetComponent<ShopSelect>().thisShop = gameObject;
            }
        }
        if (button)
        {
            button.GetComponent<ShopSelect>().thisShop = gameObject;
        }
    }
    public void SetShop()
    {
        ClearShop();
        SetMenus();
        AddInv();
    }
    void Update()
    {
        
    }
}