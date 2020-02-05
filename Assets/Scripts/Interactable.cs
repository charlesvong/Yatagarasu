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

    abstract public string getInstructions();

    abstract public int getActionCode();

    public Interactable getInteractObject() {
        return this;
    }

    abstract public void interact(int actionCode);
}
