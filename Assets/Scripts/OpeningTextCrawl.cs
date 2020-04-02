using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;

public class OpeningTextCrawl : MonoBehaviour
{
    public MainMenu MM;
    public AudioSource track;

    void Update() {
        for (int i = 0; i < ReInput.players.playerCount; i++)
        {
            Player player = ReInput.players.Players[i];
            
            if(player.GetButtonDown("Skip"))
            {
                OpeningCrawlFadeComplete();
                MM.PlayGame();
            }
        }
    }
    public void OpeningCrawlFadeComplete()
    {
        StartCoroutine(AudioFadeOut.FadeOut(track, 3));
    }
}
