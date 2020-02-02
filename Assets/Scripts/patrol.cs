using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrol : MonoBehaviour
{
    public wayPoints points;
    private Transform dest;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {    
    }

    // Update is called once per frame
    void Update()
    {
        if (dest == null) {
            dest = points.nextDes();
        }
        if (Vector3.SqrMagnitude(this.transform.position - dest.position) < 0.5)
        {
            dest = points.nextDes();
        }

        agent.SetDestination(dest.position);
    }
}
