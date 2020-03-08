using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Texture Hint2D;
    public bool hasTanukiOrOni;
    private FungusDialogue dialogue;
    private bool dialogueTriggered = false;

    private VictoryScreen victoryComponent;
    private AudioSource AccuseSFX;
    private AudioSource HintSFX;

    // Start is called before the first frame update
    void Start()
    {
        victoryComponent = GetComponent<VictoryScreen>();
        dialogue = GetComponent<FungusDialogue>();
        AccuseSFX = this.transform.Find("AccuseSFX").GetComponent<AudioSource>();
        HintSFX = this.transform.Find("HintSFX").GetComponent<AudioSource>();
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
        dManager.getPresent(caller_id).Show2d(Hint2D);
        HintSFX.Play();
    }

    public void endProviding() {
        timer = 0;
        providing = false;
        this.GetComponent<AI>().BackToDefault();
        caller.GetComponent<playerMovement2>().enableMove();
        dManager.getPresent(caller_id).Hide();
        if(hasTanukiOrOni && !dialogueTriggered){
            TriggerHintDialogue();
            dialogueTriggered = true;
        }
        else{
            int RandomNum = Random.Range(0, 100);
            if(RandomNum < 30){
                dialogue.OneLiner(caller_id);
            }
        }
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
            victoryComponent.Victory();
        }
        else {
            dialogue.CaughtDialogue(caller_id);
            AccuseSFX.Play();

        }
        return isTarget;
    }

    public void TriggerHintDialogue(){
        dialogue.hint();
    }

}
