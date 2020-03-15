using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuseTracker : MonoBehaviour
{
    public static bool accusing = false;
    public GameObject VioletAccuse;
    public GameObject RookAccuse;
    public GameObject RavenAccuse;


    // Update is called once per frame
    void Update()
    {
        if(VioletAccuse.gameObject.activeSelf || RookAccuse.gameObject.activeSelf || RavenAccuse.gameObject.activeSelf){
            accusing = true;
        }
        else{
            accusing = false;
        }
    }

    public bool getAccuseVarState(){
        return accusing;
    }
}
