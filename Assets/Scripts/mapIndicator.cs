using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapIndicator : MonoBehaviour
{

    public Transform target;
    public Transform map;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(target.position.x, map.position.y, target.position.z);
    }
}
