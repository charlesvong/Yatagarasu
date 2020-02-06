using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class playerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float gravityFactor;
    public Vector3 gravity;
    private CharacterController controller;
    Vector3 forward, right;
    private Vector3 warpPosition = Vector3.zero;
    public GameObject finalplayer;

    public int controllerID;
    private Player player;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        player = ReInput.players.GetPlayer(controllerID);
    }

    void Update()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        Vector3 move = Vector3.zero;

        if (controller.isGrounded == false)
        {
            move = Vector3.zero;
            gravity += Physics.gravity * gravityFactor * Time.deltaTime;
            move += gravity;
        }
        else
        {
            gravity = Vector3.zero;
        }

        float moveHorizontal = player.GetAxis("Move Horizontal");
        float moveVertical = player.GetAxis("Move Vertical");

        Vector3 rightMovement = right * playerSpeed * Time.deltaTime * player.GetAxis("Move Horizontal");
        Vector3 upMovement = forward * playerSpeed * Time.deltaTime * player.GetAxis("Move Vertical");

        if (moveHorizontal + moveVertical != 0) {
            Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
            transform.forward = heading;
        }


        // transform.position += rightMovement;
        // transform.position += upMovement;
        // transform.position += move;

        controller.Move(rightMovement);
        controller.Move(upMovement);
        controller.Move(move);

        if (warpPosition != Vector3.zero)
        {
            transform.position = warpPosition;
            warpPosition = Vector3.zero;
        }

        if ((moveHorizontal * moveHorizontal + moveVertical * moveVertical > 0))
        {
            this.transform.Find("model").GetComponent<Animator>().SetBool("walk", true);
        }
        else {
            this.transform.Find("model").GetComponent<Animator>().SetBool("walk", false);
        }



    }
    public void WarpToPosition(Vector3 newPosition)
    {
        warpPosition = newPosition;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.name == finalplayer.name)
        {
            if (globalManager.haveKey())
            {
                globalManager.keyPassed();
            }
        }
    }

    public Player getController() {
        return player;
    }

}