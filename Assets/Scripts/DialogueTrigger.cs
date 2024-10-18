using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> dialogues = new List<Dialogue>();
    bool interactingWith;

    void Start()
    {

    }
    IEnumerator DialogueDelay(Dialogue dialogue)
    {
        yield return new WaitForSeconds(0.1f);
        TriggerDialogue(dialogue);
    }
    public void CheckForDialogue(string thisDialogue)
    {
        foreach (Dialogue dialogue in dialogues)
        {
            if (dialogue.name == thisDialogue)
            {
                StartCoroutine(DialogueDelay(dialogue));
            }
        }
    }
    void TriggerDialogue(Dialogue thisDialogue)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(thisDialogue);
    }
    void Update()
    {

    }
}