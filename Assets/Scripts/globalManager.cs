using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class globalManager : MonoBehaviour
{
    private static int key = 0;
    private static bool passed = false;
    private static bool disguise = false;
    private static string text = "Get the key!!";
    public Text logText;

    // Start is called before the first frame update
    void Start()
    {
        key = 0;
    }

    // Update is called once per frame
    void Update()
    {
         logText.text = text;
        
    }

    public static bool haveKey() {
        return key > 0;
    }

    public static void keyCollected() {
        key++;
        text = "Key collected by Rook";
    }

    public static void keyPassed()
    {
        passed = true;
        text = "Key passed to Raven";
    }

    public static bool canOpen() {
        return passed;
    }

    public static void opened() {
        text = "Treasure aquired";
    }

    public static void getMsg(string Msg)
    {
        text = Msg;
    }

    public static void disguised()
    {
        disguise = true;
    }

    public static bool isDisguised()
    {
        return disguise;
    }
}
