using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class GameOverTracker : MonoBehaviour
{
    public playerMovement2 Violet;
    public playerMovement2 Rook;
    public playerMovement2 Raven;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private Text uiText;
    [SerializeField] private GameObject MainBGM;
    [SerializeField] private GameObject GameOverBGM;
    [SerializeField] private GameObject CatchBGM;
    private bool selected = false;
    private Button firstSelected;


    // Update is called once per frame
    void Update()
    {
        if(Violet.isCaught() && Rook.isCaught() && Raven.isCaught())
        {
            GameOver();
        }
    }

    void GameOver()
    {
        for (int i = 0; i < ReInput.players.playerCount; i++)
        {
            Player player = ReInput.players.Players[i];
            player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "GameOver", "default", true);
            player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "default", "default", false);
        }

        GameOverScreen.SetActive(true);

        if(selected == false){
            firstSelected = GameOverScreen.GetComponentsInChildren<Button>()[0];
            firstSelected.Select();
            selected = true;
        }

        uiText.text = "0:00";

        // Stop main theme and start Game Over music
        AudioSource MainTheme = MainBGM.GetComponent<AudioSource>();
        AudioSource GameOverTheme = GameOverBGM.GetComponent<AudioSource>();
        AudioSource CatchTheme = CatchBGM.GetComponent<AudioSource>();
        if(MainTheme.isPlaying || CatchTheme.isPlaying){
            MainTheme.Stop();
            CatchTheme.Stop();
            GameOverTheme.Play();
        }

        
    }
}
