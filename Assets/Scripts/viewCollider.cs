using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewCollider : MonoBehaviour
{
    private int hits = 0;
    private bool status = false;
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
        if (other.gameObject.layer == 8)
        {
            hits += 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            hits -= 1;
        }
    }

    public bool isCollide() {
        return hits != 0;
    }
}
