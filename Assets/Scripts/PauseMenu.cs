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
    public GameObject VioletAccuse;
    
    public GameObject RookAccuse;
    public GameObject RavenAccuse;
    private Button firstSelected;
    private playerMovement2 controller;

    // Update is called once per frame
    void Update()
    {
        controller = GetComponent<playerMovement2>();
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
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "PauseMenu", "default", false);
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "default", "default", true);
        pauseMenuUI.SetActive(false);
        if(VioletAccuse.gameObject.activeSelf){
            var button = VioletAccuse.GetComponentsInChildren<Button>()[0];
            button.Select();
            if(controller.controllerID == 0){
                controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "default", "default", false);
            }
        }
        else if(RookAccuse.gameObject.activeSelf){
            var button = RookAccuse.GetComponentsInChildren<Button>()[0];
            button.Select();
            if(controller.controllerID == 1){
                controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "default", "default", false);
            }
        }
        else if(RavenAccuse.gameObject.activeSelf){
            var button = RavenAccuse.GetComponentsInChildren<Button>()[0];
            button.Select();
            if(controller.controllerID == 2){
                controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "default", "default", false);
            }
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "PauseMenu", "default", true);
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "default", "default", false);
        pauseMenuUI.SetActive(true);
        
        firstSelected = pauseMenuUI.GetComponentsInChildren<Button>()[0];
        firstSelected.Select();

        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "PauseMenu", "default", false);
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "default", "default", true);
    }

    public void ReturnToTitleScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
