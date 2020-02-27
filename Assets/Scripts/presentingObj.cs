using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presentingObj : MonoBehaviour
{
    public float rotateSpeed;
    private GameObject prefab;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }

    public void setTarget(GameObject fab) {
        this.target = fab;
    }

    public void setMaterial(Material material)
    {
    }

    public void initiateObj() {
        prefab = Instantiate(target, this.transform.position, Quaternion.identity);
        prefab.transform.parent = this.transform;
        prefab.layer = 12;
    }

    public void destroyObj() {
        Destroy(prefab);
    }
}
