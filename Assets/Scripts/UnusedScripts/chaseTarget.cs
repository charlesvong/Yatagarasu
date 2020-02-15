using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseTarget : MonoBehaviour
{

    private bool located = false;
    private Transform target;
    public UnityEngine.AI.NavMeshAgent agent;
    private float breakDis;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (located) {
            if (Vector3.Distance(target.position, this.transform.position) > breakDis)
            {
                disTarget();
            }
            else { 
                agent.SetDestination(target.position);
            }
           
        }

    }

    public void setTarget(Transform target_trans, float distance) {
        target = target_trans;
        breakDis = distance;
        located = true;
    }

    public void disTarget() {
        located = false;    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player_1") {
            setTarget(other.transform, 10);
               }
    }

}
