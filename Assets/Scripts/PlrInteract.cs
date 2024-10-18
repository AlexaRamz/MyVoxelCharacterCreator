using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlrInteract : MonoBehaviour
{
    public GameObject interactingWith;
    public GameObject manager;
    public GameObject mManager;
    public GameObject thisCam;

    GameObject thisLabel;
    public bool canTrigger;
    public bool canInteract;

    void Start()
    {
        canTrigger = true;
        canInteract = true;
        thisLabel = manager.GetComponent<DialogueManager>().interactLabel;
    }
    void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (tag == "Character" || tag == "Collider" || tag == "Shop")
        {
            interactingWith = other.gameObject;
        }
        if (other.tag == "Collider")
        {
            if (manager.GetComponent<DialogueManager>().canInteract)
            {
                string dialogue = "OnCollide";
                interactingWith.GetComponent<DialogueTrigger>().CheckForDialogue(dialogue);
                StartCoroutine(TriggerDelay());
                canTrigger = false;
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        string tag = other.tag;
        if (tag == "Character" || tag == "Shop")
        {
            if (manager.GetComponent<DialogueManager>().canInteract)
            {
                thisLabel.GetComponent<Image>().enabled = true;
            }
            else
            {
                thisLabel.GetComponent<Image>().enabled = false;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        string tag = other.tag;
        if (tag == "Character" || tag == "Shop")
        {
            thisLabel.GetComponent<Image>().enabled = false;
            interactingWith = null;
        }
    }
    IEnumerator TriggerDelay()
    {
        yield return new WaitForSeconds(0.1f);
        canTrigger = true;
    }
    void Update()
    {
        if (Input.GetKeyDown("e") && interactingWith && canInteract)
        {
            if (interactingWith.tag == "Character")
            {
                if (manager.GetComponent<DialogueManager>().canInteract && canTrigger)
                {
                    string dialogue = "OnInteract";
                    mManager.GetComponent<MenuManager>().CloseAll();
                    interactingWith.GetComponent<DialogueTrigger>().CheckForDialogue(dialogue);
                    canTrigger = false;
                    StartCoroutine(TriggerDelay());
                }
            }
            if (interactingWith.tag == "Shop")
            {
                if (canTrigger)
                {
                    mManager.GetComponent<MenuManager>().CloseAll();
                    mManager.GetComponent<MenuManager>().CloseFace();
                    interactingWith.GetComponent<ShopManager>().SetShop();
                    
                    canTrigger = false;
                    StartCoroutine(TriggerDelay());
                }
            }
        }
        if (Input.GetKeyDown("r"))
        {
            mManager.GetComponent<MenuManager>().CloseAll();
            thisCam.GetComponent<CameraControl>().CamOff();
        }
    }
    void LateUpdate()
    {
        if (interactingWith)
        {
            Vector3 labelPos = Camera.main.WorldToScreenPoint(interactingWith.transform.position);
            thisLabel.transform.position = labelPos;
        }
    }
}
