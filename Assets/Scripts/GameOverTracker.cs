using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class GameOverTracker : MonoBehaviour
{
    public GameObject Violet;
    public GameObject Rook;
    public GameObject Raven;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private Text uiText;
    private bool selected = false;
    private Button firstSelected;


    // Update is called once per frame
    void Update()
    {
        if(!Violet.activeSelf && !Rook.activeSelf && !Raven.activeSelf)
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

        
    }
}
