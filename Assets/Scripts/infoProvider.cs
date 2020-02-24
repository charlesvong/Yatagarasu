using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class infoProvider : MonoBehaviour
{

    public int restrict_player_id;
    private GameObject caller;
    private bool providing = false;
    public float talkTime;
    private float timer;
    private int caller_id;
    public dialogManager dManager;
    public bool isTarget = false;
    public GameObject Hint;
    public Flowchart flowchart;

    private VictoryScreen victoryComponent;

    // Start is called before the first frame update
    void Start()
    {
        victoryComponent = GetComponent<VictoryScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (providing && timer > 0.0f)
        {
            Vector3 targetDirection = caller.transform.position - this.transform.position;
            float singleStep = 5 * Time.deltaTime;
            targetDirection.y = 0;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            this.transform.rotation = Quaternion.LookRotation(newDirection);
            timer -= Time.deltaTime;
        }
        else if (providing) {
            endProviding();
        }
        
    }

    public int getRestrict() {
        return restrict_player_id;
    }

    public void provideInfo() {
        this.GetComponent<AI>().Stand();
        caller.GetComponent<playerMovement2>().disableMove();
        providing = true;
        timer = talkTime;
        Debug.Log("i will give u info");
        dManager.getPresent(caller_id).Show(Hint);
        flowchart.ExecuteBlock("Test");
    }

    public void endProviding() {
        timer = 0;
        providing = false;
        this.GetComponent<AI>().BackToDefault();
        caller.GetComponent<playerMovement2>().enableMove();
        dManager.getPresent(caller_id).Hide();
    }

    public void setCaller(GameObject obj, int id) {
        this.caller = obj;
        this.caller_id = id;
    }

    public bool isProviding() {
        return providing;
    }

    public bool accuse() {
        if (isTarget)
        {
            Debug.Log("accused, game success");
            victoryComponent.Victory();
        }
        else {
            Debug.Log("wring target, game over");
        }
        return isTarget;
    }

}
