using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class VictoryScreen : MonoBehaviour
{
    public GameObject victoryScreen;
    private Button firstSelected;
    private bool selected = false;
    // Start is called before the first frame update

    public void Victory()
    {
        for (int i = 0; i < ReInput.players.playerCount; i++)
        {
            Player player = ReInput.players.Players[i];
            player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "GameOver", "default", true);
            player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "default", "default", false);
        }

            victoryScreen.SetActive(true);

            firstSelected = victoryScreen.GetComponentsInChildren<Button>()[0];
            firstSelected.Select();
    }
}
