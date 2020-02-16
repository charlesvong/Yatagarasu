using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createIndicator : MonoBehaviour
{

    public mapIndicator myPrefab;
    public Transform map;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {

        myPrefab = Instantiate(myPrefab, this.transform.position, Quaternion.identity);
        myPrefab.target = this.transform;
        myPrefab.map = map;
        myPrefab.GetComponent<Renderer>().material = mat;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
