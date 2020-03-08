using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class interactiveArea : MonoBehaviour
{
    private Interactable interactObj = null;
    private int actionCode = -1;
    private bool interacted = false;
    private GameObject player;
    private instructionManager hint;
    public int player_id;
    private playerMovement2 controller;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent.gameObject;
        hint = player.GetComponentsInChildren<instructionManager>()[0];
        controller = player.GetComponent<playerMovement2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.getController().GetButtonDown("Interact") && interactObj != null) {
            interactObj.interact(actionCode);
            interacted = true;
        }

        if (controller.getController().GetButtonDown("Accuse") && interactObj.GetComponent<infoProvider>() != null)
        {
            if(!interactObj.GetComponent<infoProvider>().isProviding()){
                bool result = interactObj.GetComponent<infoProvider>().accuse();
                if (!result) {
                    actionCode = -1;
                    hint.hide();
                    player.gameObject.GetComponent<playerMovement2>().disableMove();
                }
            }
        }

        if (actionCode != -1 && interactObj == null) {
            actionCode = -1;
            hint.hide();
        }

    }

    void OnTriggerEnter(Collider other) {
        Interactable temp = other.gameObject.GetComponent<Interactable>();
        if (temp) {
            interactObj = temp.getInteractObject();
            actionCode = temp.getActionCode(player_id, player);
            hint.changeAndUpdateHint(temp.getInstructions(player_id), actionCode); 
        }
    }

    void OnTriggerStay(Collider other)
    {
        Interactable temp = other.gameObject.GetComponent<Interactable>();
        if (temp && temp == interactObj && interacted)
        {
            actionCode = temp.getActionCode(player_id, player);
            hint.changeAndUpdateHint(temp.getInstructions(player_id), actionCode);
            interacted = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Interactable temp = other.gameObject.GetComponent<Interactable>();
        if (temp && temp == interactObj)
        {
            interactObj = null;
            actionCode = -1;
            hint.hide();
        }
    }
}
