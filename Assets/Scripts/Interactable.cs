using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    abstract public string getInstructions(int player_id);

    abstract public int getActionCode(int player_id, GameObject player_obj);

    public Interactable getInteractObject() {
        return this;
    }

    abstract public void interact(int actionCode, GameObject player, int player_id);
}
