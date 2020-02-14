using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCollect : MonoBehaviour
{
    public GameObject key;
    public GameObject player1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name==player1.name) {
            globalManager.keyCollected();
            Destroy(key);
        }
    }
}
