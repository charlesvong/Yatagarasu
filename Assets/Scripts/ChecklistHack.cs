using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecklistHack : MonoBehaviour
{
    private bool notActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!notActive){
            this.gameObject.SetActive(false);
            notActive = true;
        }

    }
}
