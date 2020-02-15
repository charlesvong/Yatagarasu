using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Rewired;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private playerMovement controller;

    // Update is called once per frame
    void Update()
    {
        controller = GetComponent<playerMovement>();
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

    public void Resume()
    {
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, 0, "PauseMenu", "default", false);
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, 0, "default", "default", true);
        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, 0, "PauseMenu", "default", true);
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, 0, "default", "default", false);
        pauseMenuUI.SetActive(true);

        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, 0, "PauseMenu", "default", false);
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, 0, "default", "default", true);
    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
