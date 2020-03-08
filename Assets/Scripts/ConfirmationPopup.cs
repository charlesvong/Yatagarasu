using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;
public class ConfirmationPopup : MonoBehaviour
{
    public GameObject m_ConfirmationPopup;
    private playerMovement2 controller;
    private bool selected = false;
    private bool confirmed = false;
    public Button firstSelected;
    private Interactable interactObj;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<playerMovement2>();
    }

    public void setActive(Interactable obj){
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "PauseMenu", "default", true);
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "default", "default", false);
        m_ConfirmationPopup.SetActive(true);

        if(selected == false){
            firstSelected.Select();
            selected = true;
        }

        interactObj = obj;
    }

    public void reset(){
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "PauseMenu", "default", false);
        controller.getController().controllers.maps.LoadMap(ControllerType.Joystick, controller.controllerID, "default", "default", true);

        m_ConfirmationPopup.SetActive(false);
        selected = false;
        if(interactObj.GetComponent<infoProvider>() != null){
            interactObj.GetComponent<infoProvider>().EndAccusing();
        }
    }
}
