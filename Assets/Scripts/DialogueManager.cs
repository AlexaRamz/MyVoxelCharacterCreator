using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    Queue<string> sentences;
    Queue<Sprite> icons;

    public GameObject textSlide;
    public Text textDisplay;
    public Image iconDisplay;
    public Sprite defaultIcon;

    public bool canInteract;
    public GameObject interactLabel;

    public GameObject plr;

    void Start()
    {
        sentences = new Queue<string>();
        icons = new Queue<Sprite>();

        canInteract = true;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        canInteract = false;
        plr.GetComponent<PlayerController>().plrActive = false;

        sentences.Clear();
        icons.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (Sprite icon in dialogue.icons)
        {
            icons.Enqueue(icon);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        textDisplay.text = sentence;

        if (icons.Count != 0)
        {
            Sprite icon = icons.Dequeue();
            iconDisplay.GetComponent<Image>().sprite = icon;
        }
    }
    IEnumerator EndDelay()
    {
        yield return new WaitForSeconds(0.1f);
        canInteract = true;
        plr.GetComponent<PlayerController>().plrActive = true;
    }
    void EndDialogue()
    {
        textDisplay.text = "";
        iconDisplay.GetComponent<Image>().sprite = defaultIcon;
        StartCoroutine(EndDelay());
    }
    void Update()
    {
        if (Input.GetKeyDown("e") && canInteract == false)
        {
            DisplayNextSentence();
        }
    }
}