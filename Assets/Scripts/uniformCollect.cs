using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uniformCollect : MonoBehaviour
{
    public GameObject uniform;
    public GameObject player1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name==player1.name) {
            globalManager.getMsg("Uniform changed");
            globalManager.disguised();


            GameObject child1 = player1.transform.GetChild(0).gameObject;
            GameObject child2 = player1.transform.GetChild(1).transform.GetChild(0).gameObject;
            child2.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = true;
            child2.GetComponent<Animator>().SetBool("uniformGet", true);

            Destroy(child1);

            Destroy(uniform);
        }
    }
}
