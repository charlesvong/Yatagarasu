using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guards : MonoBehaviour
{

    private int status = 0;
    private GameObject attractTarget;
    private GameObject uniformChangeTarget;
    private bool uniform = true;
    private bool list = true;
    // 0 for normal, 1 for attracted, 2 for unconscious

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAttract(GameObject target) {
        attractTarget = target;
    }

    public void attract() {
        status = 1;
        this.GetComponent<AI>().Chase(attractTarget.transform, 100);
    }

    public int getStatus() {
        return status;
    }

    public void knock() {
        status = 2;
        this.GetComponent<AI>().Stand();
        Debug.Log("I am down");
    }

    public void setUniform(GameObject target)
    {
        uniformChangeTarget = target;
    }

    public void lootUniform()
    {
        Debug.Log("Uniform gone");
        uniform = false;
    }

    public void steal()
    {
        Debug.Log("list gone");
        list = false;
    }

    public bool hasUniform() {
        return uniform;
    }

    public bool hasList() {
        return list;
    }
}
