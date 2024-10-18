using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public GameObject[] menus;
    public GameObject[] other;
    bool menuOpened;
    float scale;
    public bool startOpen;

    void Start()
    {
        menuOpened = false;
        scale = 1.1f;
        if (startOpen)
        {
            Open();
            menuOpened = true;
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
    public void Open()
    {
        foreach (GameObject menu in menus)
        {
            if (menu != null)
            {
                menu.GetComponent<Canvas>().enabled = true;
            }
        }
        foreach (GameObject menu in other)
        {
            if (menu != null)
            {
                menu.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        menuOpened = true;
    }
    public void Close()
    {
        foreach (GameObject menu in menus)
        {
            if (menu != null)
            {
                menu.GetComponent<Canvas>().enabled = false;
            }
        }
        foreach (GameObject menu in other)
        {
            if (menu != null)
            {
                menu.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        menuOpened = false;
    }
    public void CloseAll()
    {
        GameObject mManager = GameObject.Find("MenuManager");
        mManager.GetComponent<MenuManager>().CloseAll();
    }
    public void CloseFace()
    {
        GameObject mManager = GameObject.Find("MenuManager");
        mManager.GetComponent<MenuManager>().CloseAll();
        mManager.GetComponent<MenuManager>().CloseFace();
    }
    public void ToggleMenu()
    {
        if (menuOpened == false)
        {
            Open();
        }
        else
        {
            Close();
        }
    }
}
