using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    // Main purpose of class is to check if players have gotten all clues in the tutorial level
    public void ButtonFadeComplete()
    {
        this.gameObject.SetActive(false);
        GetComponent<Animator>().SetBool("Fade", false);
    }
}
