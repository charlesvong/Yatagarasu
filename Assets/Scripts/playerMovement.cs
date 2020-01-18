using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float jumpFactor;
    public float gravityFactor;
    public Vector3 gravity;
    private CharacterController controller;
    public string forward;
    public string backward;
    public string left;
    public string right;
    private Vector3 warpPosition = Vector3.zero;
    public GameObject finalplayer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = Vector3.zero;
        //if (Input.GetKey("space") && controller.isGrounded)
        //{
        //    gravity -= Physics.gravity * gravityFactor * jumpFactor;
        //    move += gravity;
        //}

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

        if (Input.GetKey(forward))
        {
            move += new Vector3(-playerSpeed * Time.deltaTime, 0, playerSpeed * Time.deltaTime);
            transform.forward = move;
        }
        if (Input.GetKey(left))
        {
            move += new Vector3(-playerSpeed * Time.deltaTime, 0, -playerSpeed * Time.deltaTime);
            transform.forward = move;
        }
        if (Input.GetKey(right))
        {
            move += new Vector3(playerSpeed * Time.deltaTime, 0, playerSpeed * Time.deltaTime);
            transform.forward = move;
        }
        if (Input.GetKey(backward))
        {
            move += new Vector3(playerSpeed * Time.deltaTime, 0, -playerSpeed * Time.deltaTime);
            transform.forward = move;
        }

        controller.Move(move);

        if (warpPosition != Vector3.zero)
        {
            transform.position = warpPosition;
            warpPosition = Vector3.zero;
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

}