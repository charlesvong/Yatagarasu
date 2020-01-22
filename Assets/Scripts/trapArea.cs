using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapArea : MonoBehaviour
{

    public Material pass;
    public Material block;
    public Renderer Object;
    public guardsRotation guard1;
    public guardsRotation guard2;
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
            globalManager.getMsg("Other guards are staring at Rook!");
            Object.material = block;
            guard1.stareAt(this.transform);
            guard2.stareAt(this.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player_1")
        {
            globalManager.getMsg("");
            Object.material = pass;
            guard1.cancelStareAt();
            guard2.cancelStareAt();
        }
    }
}
