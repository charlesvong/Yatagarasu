using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveArea : MonoBehaviour
{
    private Interactable interactObj = null;
    private int actionCode = -1;
    private bool interacted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && interactObj != null) {
            interactObj.interact(actionCode);
            interacted = true;
        }

    }

    void OnTriggerEnter(Collider other) {
        Interactable temp = other.gameObject.GetComponent<Interactable>();
        if (temp) {
            interactObj = temp.getInteractObject();
            actionCode = temp.getActionCode();
            Debug.Log(temp.getInstructions()); 
        }
    }

    void OnTriggerStay(Collider other)
    {
        Interactable temp = other.gameObject.GetComponent<Interactable>();
        if (temp && temp == interactObj && interacted)
        {
            actionCode = temp.getActionCode();
            Debug.Log(temp.getInstructions());
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
            Debug.Log("left");
        }
    }
}
