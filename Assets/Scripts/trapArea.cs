using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapArea : MonoBehaviour
{

    public Material pass;
    public Material block;
    public Renderer Object;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "Player_1") {
            globalManager.getMsg("Monitoring activated");
            Object.material = block;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player_1")
        {
            globalManager.getMsg("Monitoring deactivated");
            Object.material = pass;

        }
    }
}
