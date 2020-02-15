using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class followPlayer2 : MonoBehaviour
{
    public playerMovement2 player;
    public Vector3 offset;
    private Player playerCon;
    // Start is called before the first frame update
    void Start()
    {
        transform.forward = player.gameObject.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        playerCon = player.getController();

        float viewHorizontal = playerCon.GetAxis("View Horizontal");

        Vector3 factor = new Vector3(offset.x * transform.forward.x, offset.y, offset.z * transform.forward.z);
        transform.position = player.gameObject.transform.position + factor;

        this.transform.RotateAround(player.transform.position, Vector3.up, viewHorizontal* 360 * Time.deltaTime);


    }
}
