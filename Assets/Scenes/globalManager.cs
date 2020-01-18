using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalManager : MonoBehaviour
{
    private static int key = 0;
    // Start is called before the first frame update
    void Start()
    {
        key = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void keyCollected() {
        key++;
    }
}
