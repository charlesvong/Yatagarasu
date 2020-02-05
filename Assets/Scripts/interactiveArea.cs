using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveArea : MonoBehaviour
{
    private Interactable interactObj = null;
    private int actionCode = -1;
    private bool interacted = false;
    private GameObject player;
    private instructionManager hint;
    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent.gameObject;
        hint = player.GetComponentsInChildren<instructionManager>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && interactObj != null) {
            interactObj.interact(actionCode);
            interacted = true;
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
            actionCode = temp.getActionCode(2, player);
            hint.changeAndUpdateHint(temp.getInstructions()); 
        }
    }

    void OnTriggerStay(Collider other)
    {
        Interactable temp = other.gameObject.GetComponent<Interactable>();
        if (temp && temp == interactObj && interacted)
        {
            actionCode = temp.getActionCode(2, player);
            hint.changeAndUpdateHint(temp.getInstructions());
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
