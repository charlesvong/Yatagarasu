using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableProvider : Interactable
{

    private int ACTION_PROVIDE = 1;
    private int ACTION_END_TALK = 2;
    private int ACTION_NOTHING = 0;

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
            return "End talking \nAccuse";
        }
        else if (player_id == provider.getRestrict())
        {
            return "Get Info \nAccuse";
        }
        else {
            return "";
        }
    }

    override public int getActionCode(int player_id, GameObject player_obj)
    {
        if (player_id == provider.getRestrict() && provider.isProviding())
        {
            return ACTION_END_TALK;
        }

        else if (player_id == provider.getRestrict())
        {
            provider.setCaller(player_obj, player_id);
            return ACTION_PROVIDE;
        }
        else
        {
            return ACTION_NOTHING;
        }
    }

    override public void interact(int actionCode)
    {
        if (actionCode == ACTION_PROVIDE)
        {
            provider.provideInfo();
        }
        else if (actionCode == ACTION_END_TALK)
        {
            provider.endProviding();
        }
    }
}
