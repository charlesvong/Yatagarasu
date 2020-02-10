using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer2 : MonoBehaviour
{
    public playerMovement player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = player.gameObject.transform.forward;
        Vector3 factor = new Vector3(-2 * transform.forward.x, 2, -2* transform.forward.z);
        transform.position = player.gameObject.transform.position + factor;


    }
}
