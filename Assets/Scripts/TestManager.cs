using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public AI npc;
    public Transform moveTarget;
    public Transform chaseTarget;
    public float breakDis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            npc.Stand();
        }

        if (Input.GetKeyDown("1")) {
            npc.Patrol();
        }

        if (Input.GetKeyDown("2"))
        {
            npc.Chase(chaseTarget, breakDis);
        }

        if (Input.GetKeyDown("3"))
        {
            npc.Move(moveTarget);
        }

        if (Input.GetKeyDown("4"))
        {
            npc.setDefaultMode(1);
        }

        if (Input.GetKeyDown("5"))
        {
            npc.setDefaultMode(0);
        }

        if (Input.GetKey("space"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }
}
