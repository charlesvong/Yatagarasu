using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private playerMovement controller;

    private CharacterController temp;
    void start()
    {
        controller = GetComponent<playerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(controller);
        Debug.Log(temp);
        if(controller.getController().GetButtonDown("Pause"))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
}
