using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogManager : MonoBehaviour
{

    public  dialogPresent violetPresent;
    public  dialogPresent rookPresent;
    public  dialogPresent ravenPresent;

    public GameObject obj;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public dialogPresent getPresent(int id) {
        if (id == 1)
        {
            return violetPresent;
        }
        else if (id == 2)
        {
            return rookPresent;
        }
        else {
            return ravenPresent;
        }
    }

    public (GameObject, Material) generateObj() {
        return (obj, mat);
    }
}
