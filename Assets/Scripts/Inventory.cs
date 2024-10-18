using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int goldCount;
    public Text[] goldTexts;
   
    public ShopItem[] hairs;
    public ShopItem[] faces;

    public Object itemRef;

    public Transform hairContain;
    public Transform faceContain;

    public GameObject hairColor;
    public GameObject eyeColor;

    public GameObject mManager;

    void Start()
    {
       
    }
    void ClearShop(Transform container)
    {
        foreach (Transform item in container)
        {
            Destroy(item.gameObject);
        }
    }
    void GetItemInfo(ShopItem[] items, string thisItem)
    {
        foreach (ShopItem item in items)
        {
            if (item.name == thisItem)
            {
                string itemName = item.name;
                string itemType = item.type;
                int itemPrice = item.price;
                RenderTexture itemImage = item.texture;
                Object itemRef = item.Ref;
                Vector3 itemAttach = item.attachment;
                Vector3 itemRot = item.orientation;

                EquipThis(itemType, itemAttach, itemRot, itemRef);
            }
        }
    }
    void AddInv(ShopItem[] items, Transform container, string type)
    {
        foreach (ShopItem item in items)
        {
            GameObject newItem = (GameObject)Instantiate(itemRef);
            newItem.transform.SetParent(container, false);
            newItem.name = item.name;
            newItem.transform.Find("RawImage").GetComponent<RawImage>().texture = item.texture;
            newItem.GetComponent<EquipSelect>().itemType = type;
        }
    }
    public void SetShop()
    {
        ClearShop(hairContain);
        ClearShop(faceContain);

        AddInv(hairs, hairContain, "Hair");
        AddInv(faces, faceContain, "Face");
    }
    void Clear(Transform thisParent)
    {
        foreach (Transform child in thisParent)
        {
            Destroy(child.gameObject);
        }
    }
    void EquipThis(string type, Vector3 attach, Vector3 rot, Object Ref)
    {
        GameObject plr = GameObject.Find("Player");
        GameObject equip = (GameObject)Instantiate(Ref);
        Vector3 Pos = plr.transform.position + attach;
        equip.transform.localPosition = Pos;

        equip.layer = 10;
        foreach (Transform child in equip.transform)
        {
            child.gameObject.layer = 10;
        }
        Transform thisParent = plr.transform.Find(type);
        equip.transform.rotation = Quaternion.Euler(rot) * thisParent.transform.rotation;

        Color32 col = new Color32(255, 255, 255, 255);
        if (type == "Hair")
        {
            col = hairColor.GetComponent<Image>().color;
            equip.transform.Find("default").GetComponent<Renderer>().material.SetColor("_Color", col);
        }
       
        Clear(thisParent);
        equip.transform.SetParent(thisParent);
    }
    public void Equip(string thisItem, string type)
    {
        if (type == "Hair")
        {
            GetItemInfo(hairs, thisItem);
        }
        else if (type == "Face")
        {
            GetItemInfo(faces, thisItem);
        }
    }
    public void AddItem(ShopItem myItem, string type)
    {
        if (type == "Hair")
        {
            ShopItem[] thisArray = hairs;
            ShopItem[] newArray = new ShopItem[thisArray.Length + 1];
            for (int i = 0; i < thisArray.Length; i++)
            {
                newArray[i] = thisArray[i];
            }
            newArray[newArray.Length - 1] = myItem;
            hairs = newArray;
        }
        else if (type == "Face")
        {
            ShopItem[] thisArray = faces;
            ShopItem[] newArray = new ShopItem[thisArray.Length + 1];
            for (int i = 0; i < thisArray.Length; i++)
            {
                newArray[i] = thisArray[i];
            }
            newArray[newArray.Length - 1] = myItem;
            faces = newArray;
        }
    }
    void Update()
    {
        foreach (Text display in goldTexts)
        {
            display.text = goldCount.ToString();
        }
    }
}
