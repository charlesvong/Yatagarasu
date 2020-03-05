using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class TutorialCutscene : MonoBehaviour
{
    private float cutsceneTimer = 20f;
    private bool TutorialFinished = false;
    public Animator BlackSlide;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cutsceneTimer);
        if(TutorialFinished){
            return;
        }
        // skip update function once tutorial is done
        if(cutsceneTimer >= 0){
            cutsceneTimer -= Time.deltaTime;
            for (int i = 0; i < ReInput.players.playerCount; i++)
            {
                Player player = ReInput.players.Players[i];
                player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "default", "default", false);
            }
        }
        else{
            for (int i = 0; i < ReInput.players.playerCount; i++)
            {
                Player player = ReInput.players.Players[i];
                player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "default", "default", true);
            }
            TutorialFinished = true;
            BlackSlide.SetBool("Slide", true);
        }
    }

    public bool GetStatus(){
        return TutorialFinished;
    }
}
