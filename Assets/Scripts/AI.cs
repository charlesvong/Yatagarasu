using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    private Transform target;
    public NavMeshAgent agent;
    private int mode = 0;
    private int[] modeList = new int[] { 0, 1, 2, 3 };
    private bool modeChange = true;
    // 0: Standing
    // 1: Patrolling
    // 2: Chasing
    // 3: Moving to destination
    // Start is called before the first frame update

    public int defaultMode = 1;
    private Transform defaultTransform;

    // for patrol
    public wayPoints waypoints;
    private bool needInit = true;

    // for chase
    private float breakDis = 0;


    void Start()
    {
        GameObject temp = new GameObject();
        temp.transform.position = this.transform.position;
        temp.transform.rotation = this.transform.rotation;
        defaultTransform = temp.transform;
        mode = defaultMode;

    }

    // Update is called once per frame
    void Update()
    {
        if (mode == 0)
        {
            agent.Stop();
            this.transform.Find("guardModel").GetComponent<Animator>().SetBool("walking", false);
        }
        else {
            agent.Resume();
            this.transform.Find("guardModel").GetComponent<Animator>().SetBool("walking", true);

            if (mode == 1)
            {
                PatrolAction();
            }
            else if (mode == 2)
            {
                ChaseAction();
            }
            else if (mode == 3) {
                MoveAction();
            }

        }

        modeChange = false;
    }

    private void BackToDefault()
    {
        if (defaultMode == 0)
        {
            Move(defaultTransform);
        }
        else if (defaultMode == 1)
        {
            Patrol();
        }

    }

    public void Stand()
    {
        modeChange = true;
        mode = 0;
    }

    public void Patrol()
    {
        modeChange = true;
        mode = 1;
        needInit = true;
    }

    private void PatrolAction()
    {
        if (needInit)
        {
            target = waypoints.nextDes();
            needInit = false;
        }
        if (Vector3.Distance(this.transform.position , target.position) < 0.5)
        {
            target = waypoints.nextDes();
        }
        agent.SetDestination(target.position);
    }

    public void Chase(Transform transform, float distance)
    {
        modeChange = true;
        breakDis = distance;
        mode = 2;
        target = transform;
    }

    public void disTarget()
    {
        BackToDefault();
    }

    private void ChaseAction()
    {

        if (Vector3.Distance(target.position, this.transform.position) > breakDis)
        {
            disTarget();
        }
        else if (Vector3.Distance(target.position, this.transform.position) < 1.5) {
            this.transform.Find("guardModel").GetComponent<Animator>().SetBool("walking", false);
            agent.Stop();
        }
        else
        {
            agent.SetDestination(target.position);
        }

    }

    public void Move(Transform transform)
    {
        modeChange = true;
        mode = 3;
        target = transform;
    }

    private void MoveAction()
    {
        if (Vector3.Distance(this.transform.position, target.position) < 0.5)
        {
            BackToDefault();
        }
        else {
            agent.SetDestination(target.position);
        }
    }

    public void setDefaultMode(int i) {
        defaultMode = i;
    }

    public void setDefaultTrans(Transform newTrans)
    {
        defaultTransform.position = newTrans.position;
        defaultTransform.rotation = newTrans.rotation;
    }
}
