using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class HintScreen : MonoBehaviour
{
    private bool HintNotebookOn = false;
    public GameObject HintNotebook;
    public GameObject NotebookOpen;
    public GameObject NotebookClose;
    private playerMovement2 controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<playerMovement2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.getController().GetButtonDown("Hint") && controller.getMoveStatus()){
            if(HintNotebookOn){
                HintNotebook.SetActive(false);
                HintNotebookOn = false;
                controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "HintScreen", "default", false);
                controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "default", "default", true);
                AudioSource BookClose = NotebookClose.GetComponent<AudioSource>();
                BookClose.Play();
            }
            else{
                HintNotebook.SetActive(true);
                HintNotebookOn = true;
                controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "HintScreen", "default", true);
                controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "default", "default", false);
                AudioSource BookOpen = NotebookOpen.GetComponent<AudioSource>();
                BookOpen.Play();
            }


        }
    }
}
