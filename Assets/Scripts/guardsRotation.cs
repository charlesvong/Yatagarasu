using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardsRotation : MonoBehaviour
{
    public Transform guard;
    public Transform attract;
    public float rangeLimit;
    public float lookAtSpeed;
    public float searchSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(guard.position, attract.position) <= rangeLimit){
            Vector3 targetDirection = attract.position - guard.position;
            targetDirection.y = 0;
            float singleStep = lookAtSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            guard.rotation = Quaternion.LookRotation(newDirection);
        }else {
            guard.Rotate(0, searchSpeed * Time.deltaTime, 0, Space.Self);
        }

    }
}
