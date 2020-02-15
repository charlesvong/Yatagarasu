using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeBox : MonoBehaviour
{
    public GameObject box;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == player.name)
        {
            if (globalManager.canOpen()) {
                globalManager.opened();
            }
        }
    }
}
