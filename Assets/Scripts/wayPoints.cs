using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayPoints : MonoBehaviour
{

    private int i = 0;
    private int total;
    private Transform[] transforms;

    // Start is called before the first frame update
    void Start()
    {
        transforms = GetComponentsInChildren<Transform>();
        total = transforms.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform nextDes() {
        i++;
        if (i == total) {
            i = 1;
        }


        return transforms[i];
    }
}
