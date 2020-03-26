using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class TutorialHintStatusChecker : MonoBehaviour
{
    // Main purpose of class is to check if players have gotten all clues in the tutorial level
    public GameObject waiter;
    public GameObject guest;
    public GameObject guard;
    private infoProvider waiterProvider;
    private infoProvider guestProvider;
    private infoProvider guardProvider;
    private bool nextStep = false;
    void Start() {
        waiterProvider = waiter.GetComponent<infoProvider>();
        guestProvider = guest.GetComponent<infoProvider>();
        guardProvider = guard.GetComponent<infoProvider>();
    }
    void Update()
    {
        if(waiterProvider.getHintAcquired() && guestProvider.getHintAcquired() && guardProvider.getHintAcquired()){
            nextStep = true;
        }
    }

    public bool getNextStepStatus()
    {
        return nextStep;
    }
}
