using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableCube : Interactable
{
    private int hitCount = 1;
    private int ACTION_DESTROY = 0;
    private int ACTION_HIT = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public string getInstructions(int player_id) {
        if (hitCount >= 1)
        {
            return "press e to hit";
        }
        else {
            return "press e to destroy";
        }

    }

    override public int getActionCode(int player_id, GameObject player_obj) {
        if (hitCount >= 1) {
            return ACTION_HIT;
        }
        return ACTION_DESTROY;
    }

    override public void interact(int actionCode) {
        if (actionCode == ACTION_DESTROY)
        {
            Destroy(this.gameObject);
        }
        else {
            hitCount -= 1;
        }
    }

}
