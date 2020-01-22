using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatePass : MonoBehaviour
{
    public playerMovement player;
    public Transform outPosition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == player.name && globalManager.isDisguised())
        {
            player.WarpToPosition(outPosition.position);
        }
        else {
            globalManager.getMsg("Someone is guarding the door!\n Only guards can go through!");
        }
    }
}
