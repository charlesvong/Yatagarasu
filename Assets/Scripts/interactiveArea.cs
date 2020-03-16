using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class interactiveArea : MonoBehaviour
{
    private Interactable interactObj = null;
    private float timer = 0;
    private int actionCode = -1;
    private bool interacted = false;
    private GameObject player;
    private instructionManager hint;
    public int player_id;
    public Text DenyAccuseText;
    public Text DenyHintText;
    private playerMovement2 controller;
    public GameObject accuseTracker;

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
        if(timer > 0.0f){
            timer -= Time.deltaTime;
        }
        else{
            DenyAccuseText.gameObject.SetActive(false);
            DenyHintText.gameObject.SetActive(false);
        }
        if (controller.getController().GetButtonDown("Interact") && interactObj != null) {
            if(interactObj.GetComponent<infoProvider>()!= null && interactObj.GetComponent<infoProvider>().isAccusing()){
                if(!DenyAccuseText.gameObject.activeSelf){
                    DenyHintText.enabled = true;
                    DenyHintText.gameObject.SetActive(true);
                    timer = 2f;
                }
            }
            else{
                interactObj.interact(actionCode, player, player_id);
                interacted = true;
            }

        }

        if (controller.getController().GetButtonDown("Accuse") && interactObj.GetComponent<infoProvider>() != null)
        {
            if(!interactObj.GetComponent<infoProvider>().isProviding()){
                if(!interactObj.GetComponent<infoProvider>().isAccusing() && !accuseTracker.GetComponent<AccuseTracker>().getAccuseVarState()){
                    interactObj.GetComponent<infoProvider>().Accusing(player, player_id);
                    interactObj.GetComponent<infoProvider>().ConfirmPopup(interactObj, player);
                }
                //Debug.Log(DenyHintText.enabled);
                else if(!DenyHintText.gameObject.activeSelf)
                {
                    DenyAccuseText.enabled = true;
                    DenyAccuseText.gameObject.SetActive(true);
                    timer = 2f;
                }
                
            }
        }

        if (actionCode != -1 && interactObj == null) {
            actionCode = -1;
            hint.hide();
        }

        if (actionCode != -1 && interactObj.gameObject.activeSelf == false)
        {
            interactObj = null;
            actionCode = -1;
            hint.hide();
        }

    }

    public void initiateAccusation(){
        bool result = interactObj.GetComponent<infoProvider>().accuse(player_id);
        if (!result) {
            actionCode = -1;
            hint.hide();
            player.gameObject.GetComponent<playerMovement2>().getCaught();
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
