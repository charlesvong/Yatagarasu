using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class initMeshCo: MonoBehaviour

{

    // Start is called before the first frame update

    void Start()

    {

        MeshRenderer[] kids = GetComponentsInChildren<MeshRenderer>();


        foreach (MeshRenderer child in kids)

        {

            // attach script

            child.gameObject.AddComponent<MeshCollider>();

        }


    }


    // Update is called once per frame

    void Update()

    {



    }

}

