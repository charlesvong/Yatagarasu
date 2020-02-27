using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingDoor : MonoBehaviour
{
    private Animator animator;
    private AudioSource doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorOpen = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 10) {
            animator.SetBool("Open", true);
            doorOpen.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.layer == 9 || other.gameObject.layer == 10)
        {
            animator.SetBool("Open", false);
        }
    }

}
