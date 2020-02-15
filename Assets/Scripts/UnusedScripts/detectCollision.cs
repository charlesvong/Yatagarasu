using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectCollision : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.name == player.name && !globalManager.isDisguised()) || other.name == "Player_3")
        {
            Destroy(other.gameObject);
            globalManager.getMsg("Player has been caught :(");
        }
    }
}
