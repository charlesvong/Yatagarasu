using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globalManager : MonoBehaviour
{
    private static int key = 0;
    public Text logText;
    // Start is called before the first frame update
    void Start()
    {
        key = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (key > 0) {
            logText.text = "key collected";
        }
        
    }

    public static void keyCollected() {
        key++;
    }
}
