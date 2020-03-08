using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableRespawn : Interactable
{
    public int id;
    private bool firstTime = true;

    private int ACTION_REVIVE = 2;
    private int ACTION_NOTHING = 3;
    // Start is called before the first frame update

    public playerMovement2 player;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public string getInstructions(int player_id)
    {
        if (player_id == id)
        {
            return "";
        }
        else if (firstTime) {
            return "Revive";
        }
        return "";
    }

    override public int getActionCode(int player_id, GameObject player_obj)
    {
        if (player_id == id)
        {
            return ACTION_NOTHING;
        }
        else if (firstTime)
        {
            return ACTION_REVIVE;
        }
        return ACTION_NOTHING;
    }

    override public void interact(int actionCode)
    {
        if (actionCode == ACTION_REVIVE)
        {
            player.revive();
            firstTime = false;
        }
    }
}

