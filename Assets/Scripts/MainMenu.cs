using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Rewired;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;
    public Animator animator;

    public void PlayGame()
    {
        animator.SetTrigger("FadeOut");
    }

    public void FadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
