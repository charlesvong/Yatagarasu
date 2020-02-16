using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableProvider : Interactable
{

    private int ACTION_PROVIDE = 1;
    private int ACTION_NOTHING = 0;
    // Start is called before the first frame update

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
        if (player_id == provider.getRestrict())
        {
            return "Get information";
        }
        else {
            return "";
        }
    }

    override public int getActionCode(int player_id, GameObject player_obj)
    {
        if (player_id == provider.getRestrict())
        {
            provider.setCaller(player_obj);
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
    }
}
