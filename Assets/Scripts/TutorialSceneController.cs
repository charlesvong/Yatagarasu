using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Rewired;
using Fungus;

public class TutorialSceneController : MonoBehaviour
{
    // Main Controller for all the tutorial events (think of the main function)
    private TutorialCutscene tutorialCutscene;
    public PlayableDirector firstCutscene;
    public Flowchart flowchart;
    public TutorialHintStatusChecker hintStatusChecker;
    public GameObject firstGraphic;
    public GameObject SkipButton;
    public Animator SkipButtonFade;
    private bool firstCutsceneFinished = false;
    private bool firstGraphicFinished = false;
    private bool secondGraphicFinished = false;
    private bool thirdGraphicFinished = false;
    private bool secondDialoguePlaying = false;
    private bool secondDialogueFinished = false;
    private bool nowPlaying;
    private float timer = 0;
    void Start() {
        tutorialCutscene = this.GetComponent<TutorialCutscene>();
    }
    void Update()
    {
        if(timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }
        if(nowPlaying){
            playMode();
        }
        if(!nowPlaying){
            cutsceneMode();
        }
        Debug.Log(nowPlaying);
        if(tutorialCutscene.GetStatus() && !firstCutsceneFinished)
        {
            firstCutscene.Play();
            firstCutsceneFinished = true;
        }
        // condition occurs right after cutscene is playing, first graphic shows and players can press the start button to proceed
        else if(tutorialCutscene.GetStatus() && !firstGraphicFinished && firstCutscene.state != PlayState.Playing){
            firstGraphic.SetActive(true);
            SkipButton.SetActive(true);
            for (int i = 0; i < ReInput.players.playerCount; i++)
            {
                Player player = ReInput.players.Players[i];
                // Check if player pressed the skip button
                if(player.GetButtonDown("Skip")){
                    SkipButtonFade.SetBool("Fade", true);
                    firstGraphic.SetActive(false);
                    firstGraphicFinished = true;
                    nowPlaying = true;
                }
            }
        }
        // Second dialogue plays
        else if(secondDialoguePlaying && timer <= 0.0f)
        {
            secondDialoguePlaying = false;
            secondDialogueFinished = true;
            nowPlaying = true;
        }
        else if(hintStatusChecker.getNextStepStatus() && !secondDialoguePlaying && !secondDialogueFinished){
            nowPlaying = false;
            flowchart.ExecuteBlock("Notebook");
            secondDialoguePlaying = true;
            timer = 7f;
        }

    }

    public void playMode()
    {
        for (int j = 0; j < ReInput.players.playerCount; j++)
        {
            Player player_again = ReInput.players.Players[j];
            player_again.controllers.maps.LoadMap(ControllerType.Joystick, player_again.id, "default", "default", true);
            player_again.controllers.maps.LoadMap(ControllerType.Joystick, player_again.id, "Cutscene", "default", false);
        }
    }

    public void cutsceneMode()
    {
        for (int i = 0; i < ReInput.players.playerCount; i++)
        {
            Player player = ReInput.players.Players[i];
            player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "default", "default", false);
            player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "Cutscene", "default", true);
        }
    }
}
