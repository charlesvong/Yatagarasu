using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;

public class ControllerScreen : MonoBehaviour
{
    private MainMenu MM;
    public AudioSource SFX;
    void Start(){
        MM = GetComponent<MainMenu>();
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ReInput.players.playerCount; i++)
        {
            Player player = ReInput.players.Players[i];
            if(player.GetButtonDown("Start")){
                MM.PlayGame();
                SFX.Play();
            }
        }
    }
}
