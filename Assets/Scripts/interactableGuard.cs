using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableGuard : Interactable
{

    private int ACTION_ATTRACK = 1;
    private int ACTION_KNOCK = 2;
    private int ACTION_STEAL = 3;
    private int ACTION_LOOT_UNIFORM = 4;
    private int ACTION_NOTHING = 0;
    // Start is called before the first frame update

    private guards guard;

    void Start()
    {
        guard = this.GetComponent<guards>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public string getInstructions(int player_id)
    {
        if (player_id == 1)
        {
            if (guard.getStatus() == 0)
            {
                return "press e to attract";
            }
            else if (guard.getStatus() == 1)
            {
                return "";
            }
            else if (guard.getStatus() == 2 && guard.hasList())
            {
                return "press e to loot guest list";
            }
        }
        else if (player_id == 2)
        {
            if (guard.getStatus() == 0)
            {
                return "Cannot knock him down when guarded";
            }
            else if (guard.getStatus() == 1)
            {
                return "press e to knock down";
            }
            else if (guard.getStatus() == 2 && guard.hasUniform())
            {
                return "press e to loot uniform";
            }
        }
        return "";
    }

    override public int getActionCode(int player_id, GameObject player_obj)
    {
        if (player_id == 1)
        {
            if (guard.getStatus() == 0)
            {
                guard.setAttract(player_obj);
                return ACTION_ATTRACK;
            }
            else if (guard.getStatus() == 1)
            {
                return ACTION_NOTHING;
            }
            else if (guard.getStatus() == 2 && guard.hasList())
            {
                return ACTION_STEAL;
            }
        }
        else if (player_id == 2)
        {
            if (guard.getStatus() == 0)
            {
                return ACTION_NOTHING;
            }
            else if (guard.getStatus() == 1)
            {
                return ACTION_KNOCK;
            }
            else if (guard.getStatus() == 2 && guard.hasUniform())
            {
                guard.setUniform(player_obj);
                return ACTION_LOOT_UNIFORM;
            }
        }
        return ACTION_NOTHING;
    }

    override public void interact(int actionCode)
    {
        if (actionCode == ACTION_ATTRACK)
        {
            guard.attract();
        }
        else if (actionCode == ACTION_KNOCK)
        {
            guard.knock();
        }
        else if (actionCode == ACTION_LOOT_UNIFORM) {
            guard.lootUniform();
        }
        else if (actionCode == ACTION_STEAL)
        {
            guard.steal();
        }
    }
}
