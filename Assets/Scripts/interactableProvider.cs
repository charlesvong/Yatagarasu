﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableProvider : Interactable
{

    private int ACTION_PROVIDE = 1;
    private int ACTION_END_TALK = 2;
    private int ACTION_NOTHING = 0;
    private int ACTION_CATCH = 2;

    private infoProvider provider;

    void Start()
    {
        provider = this.GetComponent<infoProvider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public string getInstructions(int player_id)
    {
        if (player_id == provider.getRestrict() && provider.isProviding())
        {
            return "End talking";
        }
        else if (provider.isEscaping())
        {
            return "Catch";
        }
        else if (player_id == provider.getRestrict())
        {
            return "Hint \nAccuse";
        }

        else
        {
            return "Accuse";
        }
    }

    override public int getActionCode(int player_id, GameObject player_obj)
    {
        if (player_id == provider.getRestrict() && provider.isProviding())
        {
            return ACTION_END_TALK;
        }
        else if (provider.isEscaping())
        {
            return ACTION_CATCH;
        }

        else if (player_id == provider.getRestrict())
        {
            return ACTION_PROVIDE;
        }
        else if(!provider.isProviding()){
            return ACTION_NOTHING;
        }
        else
        {
            return ACTION_NOTHING;
        }
    }

    override public void interact(int actionCode, GameObject player, int player_id)
    {
        if (actionCode == ACTION_PROVIDE)
        {
            provider.provideInfo(player, player_id);
        }
        else if (actionCode == ACTION_END_TALK && provider.isEscaping())
        {
            provider.caught();
        }
        else if (actionCode == ACTION_END_TALK)
        {
            provider.endProviding(player, player_id);
        }
    }
}
