using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class TutorialCutscene : MonoBehaviour
{
    private float cutsceneTimer = 26f;
    private bool TutorialFinished = false;
    private FungusDialogue dialogue;
    public Animator BlackSlide;
    public Animator ButtonFade;
    public Animator RookText;
    public Animator VioletText;
    public Animator RavenText;

    void Start(){
        dialogue = GetComponent<FungusDialogue>();
    }
    // Update is called once per frame
    void Update()
    {
        if(TutorialFinished){
            return;
        }
        if(cutsceneTimer >= 0){
            cutsceneTimer -= Time.deltaTime;
            for (int i = 0; i < ReInput.players.playerCount; i++)
            {
                Player player = ReInput.players.Players[i];
                player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "default", "default", false);
                player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "Cutscene", "default", true);

                // Check if player pressed the skip button
                if(player.GetButtonDown("Skip")){
                    dialogue.Skip();
                    cutsceneTimer = 0;
                }
            }
        }
        else{
            for (int i = 0; i < ReInput.players.playerCount; i++)
            {
                Player player = ReInput.players.Players[i];
                player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "default", "default", true);
                player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "Cutscene", "default", false);
            }
            TutorialFinished = true;
            BlackSlide.SetBool("Slide", true);
            ButtonFade.SetBool("Fade", true);
            RookText.SetBool("Fade", true);
            VioletText.SetBool("Fade", true);
            RavenText.SetBool("Fade", true);
        }
    }

    public bool GetStatus(){
        return TutorialFinished;
    }
}
