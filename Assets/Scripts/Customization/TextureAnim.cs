using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAnim : MonoBehaviour
{
    public Material[] frames;
    public float frameSpeed;
    public bool addPause;
    public float pauseTime;
    int index;

    void Start()
    {
        NextFrame();
    }
    IEnumerator frameDelay()
    {
        yield return new WaitForSeconds(1 / frameSpeed);
        index += 1;
        if (index == frames.Length)
        {
            index = 0;
            if (addPause == true)
            {
                StartCoroutine(animDelay());
            }
            else
            {
                NextFrame();
            }
        }
        else
        {
            NextFrame();
        }
    }
    IEnumerator animDelay()
    {
        yield return new WaitForSeconds(pauseTime);
        NextFrame();
    }
    void NextFrame()
    {
        gameObject.GetComponent<Renderer>().material = frames[index];
        Debug.Log("next frame");
        StartCoroutine(frameDelay());
    }
}
