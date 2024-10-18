using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceSelect : MonoBehaviour
{
    string newFace;
    Transform thisCanvas;
    public Sprite unselected;
    public Sprite selected;
    public GameObject plrFace;
  
    void Start()
    {
        newFace = gameObject.name;
        thisCanvas = transform.parent;
    }
    IEnumerator TriggerReset(string thisAnim)
    {
        yield return new WaitForSeconds(0.2f);
        plrFace.GetComponent<Animator>().ResetTrigger(thisAnim);
    }
    void ResetSelect()
    {
        foreach (Transform item in thisCanvas)
        {
            if (item != null)
            {
                item.Find("Image").GetComponent<Image>().sprite = unselected;
            }
        }
    }
    public void SelectThis()
    {
        ResetSelect();
        transform.Find("Image").GetComponent<Image>().sprite = selected;
        plrFace.GetComponent<Animator>().SetTrigger(newFace);
        StartCoroutine(TriggerReset(newFace));
    }
    public void SelectHair()
    {
        ResetSelect();
        transform.Find("Image").GetComponent<Image>().sprite = selected;
    }
    void Update()
    {

    }
}