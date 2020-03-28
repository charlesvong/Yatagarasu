using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSceneEvents : MonoBehaviour
{
    public static TutorialSceneEvents current;

    private void Awake() {
        current = this;
    }

    public event Action timelineFinish;
    public void timelineFinished()
    {
        if(timelineFinish != null)
        {
            timelineFinish();
        }
    }

    public event Action firstGraphic;
    public void firstGraphicFinished()
    {
        if(firstGraphic != null)
        {
            firstGraphicFinished();
        }
    }
}
