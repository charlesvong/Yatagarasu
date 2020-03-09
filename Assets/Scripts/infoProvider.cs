using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoProvider : MonoBehaviour
{

    public int restrict_player_id;
    private GameObject caller;
    private bool providing = false;
    private bool accusing = false;
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
    private bool PopupState = false;

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
        if (providing && timer > 0.0f || accusing)
        {
            Vector3 targetDirection = caller.transform.position - this.transform.position;
            float singleStep = 5 * Time.deltaTime;
            targetDirection.y = 0;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            this.transform.rotation = Quaternion.LookRotation(newDirection);
            timer -= Time.deltaTime;
        }
        else if (providing) {
            endProviding(caller, caller_id);
        }
        
    }

    public int getRestrict() {
        return restrict_player_id;
    }

    public void provideInfo(GameObject p_caller, int p_caller_id) {
        this.GetComponent<AI>().Stand();
        p_caller.GetComponent<playerMovement2>().disableMove();
        providing = true;
        timer = talkTime;
        dManager.getPresent(p_caller_id).Show2d(Hint2D);
        HintSFX.Play();
        setCaller(p_caller, p_caller_id);
    }

    public void endProviding(GameObject p_caller, int p_caller_id) {
        timer = 0;
        providing = false;
        this.GetComponent<AI>().BackToDefault();
        p_caller.GetComponent<playerMovement2>().enableMove();
        dManager.getPresent(p_caller_id).Hide();
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

    public void Accusing(GameObject p_caller, int p_caller_id) {
        this.GetComponent<AI>().Stand();
        accusing = true;
        setCaller(p_caller, p_caller_id);
    }

    public void setCaller(GameObject obj, int id) {
        this.caller = obj;
        this.caller_id = id;
    }

    public bool isProviding() {
        return providing;
    }

    public bool isAccusing() {
        return accusing;
    }

    public void ConfirmPopup(Interactable obj, GameObject p_caller){
        p_caller.GetComponent<ConfirmationPopup>().setActive(obj);
        accusing = true;
    }
    public bool accuse(int p_caller_id) {
        if (isTarget)
        {
            victoryComponent.Victory();
        }
        else {
            dialogue.CaughtDialogue(p_caller_id);
            AccuseSFX.Play();

        }
        return isTarget;
    }

    public void TriggerHintDialogue(){
        dialogue.hint();
    }

    public void EndAccusing(){
        accusing = false;
        this.GetComponent<AI>().BackToDefault();
    }

}
