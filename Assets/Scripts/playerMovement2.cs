using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class playerMovement2 : MonoBehaviour
{
    public float playerSpeed;
    public float gravityFactor;
    public Vector3 gravity;
    private CharacterController controller;
    Vector3 forward, right;
    private Vector3 warpPosition = Vector3.zero;
    public Camera camera;
    public Vector3 startPosition;
    public interactableRespawn respawn;

    public int controllerID;
    private Player player;
    private bool warpSet = false;

    private bool ableMove = true;
    private bool caught = false;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        player = ReInput.players.GetPlayer(controllerID);
        startPosition = this.transform.position;
    }

    void Update()
    {
        forward = camera.transform.forward;
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

        if (ableMove)
        {

            if (moveHorizontal != 0 || moveVertical != 0)
            {
                Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
                transform.forward = heading;
            }


            controller.Move(rightMovement);
            controller.Move(upMovement);
            controller.Move(move);

            if ((moveHorizontal * moveHorizontal + moveVertical * moveVertical > 0))
            {
                this.transform.Find("model").GetComponent<Animator>().SetBool("walk", true);
            }
            else
            {
                this.transform.Find("model").GetComponent<Animator>().SetBool("walk", false);
            }
        }
        else {
            this.transform.Find("model").GetComponent<Animator>().SetBool("walk", false);
        }

        if (warpSet)
        {
            transform.position = warpPosition;
            if (transform.position == warpPosition) {
                warpSet = false;
            }
        }

    }
    public void WarpToPosition(Vector3 newPosition)
    {
        warpPosition = newPosition;
        warpSet = true;
    }

    public Player getController() {
        return player;
    }

    public void disableMove() {
        ableMove = false;
    }

    public void enableMove() {
        ableMove = true;
    }

    public void getCaught()
    {
        WarpToPosition(respawn.gameObject.transform.position);
        disableMove();
//        respawn.gameObject.SetActive(true);
        caught = true;
    }

    public void revive() {
        enableMove();
 //       respawn.gameObject.SetActive(false);
        caught = false;
    }

    public bool isCaught() {
        return caught;
    }

    public bool getMoveStatus(){
        return ableMove;
    }
}