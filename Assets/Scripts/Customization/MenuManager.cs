using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject[] menus;
    public GameObject[] intrfce;
    public GameObject plr;

    void Start()
    {
        
    }

    public void CloseAll()
    {
        foreach (GameObject menu in menus)
        {
            if (menu != null)
            {
                menu.GetComponent<Canvas>().enabled = false;
            }
        }
        OpenFace();
    }
    void OpenFace()
    {
        foreach (GameObject menu in intrfce)
        {
            if (menu != null)
            {
                menu.GetComponent<Canvas>().enabled = true;
            }
        }
        plr.GetComponent<PlayerController>().plrActive = true;
        plr.GetComponent<PlrInteract>().canInteract = true;
    }
    public void CloseFace()
    {
        foreach (GameObject menu in intrfce)
        {
            if (menu != null)
            {
                menu.GetComponent<Canvas>().enabled = false;
            }
        }
        plr.GetComponent<PlayerController>().plrActive = false;
        plr.GetComponent<PlrInteract>().canInteract = false;
    }
    void Update()
    {
        
    }
}
