using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Rewired;

public class TutorialSceneController : MonoBehaviour
{
    private TutorialCutscene tutorialCutscene;
    public PlayableDirector firstCutscene;
    private bool firstCutsceneFinished = false;
    void Start() {
        tutorialCutscene = this.GetComponent<TutorialCutscene>();
    }
    void Update()
    {
        if(tutorialCutscene.GetStatus() && !firstCutsceneFinished)
        {
            firstCutscene.Play();
            firstCutsceneFinished = true;
        }
    }
}
