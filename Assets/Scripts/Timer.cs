using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;
using Fungus;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float maxTimer;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject MainBGM;
    [SerializeField] private GameObject GameOverBGM;
    [SerializeField] private GameObject CatchBGM;
    [SerializeField] private infoProvider target;

    private float timer;
    private bool selected = false;

    private Button firstSelected;
    private bool firstBanter = false;
    private bool secondBanter = false;
    private bool HurryUpReminder = false;
    private bool catchline = false;
    public GameObject VictoryScreen;
    private FungusDialogue dialogue;

    private AudioSource MainTheme;
    private AudioSource GameOverTheme;
    private AudioSource CatchTheme;

    private TutorialCutscene cutscene;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
        dialogue = GetComponent<FungusDialogue>();
        MainTheme = MainBGM.GetComponent<AudioSource>();
        CatchTheme = CatchBGM.GetComponent<AudioSource>();
        GameOverTheme = GameOverBGM.GetComponent<AudioSource>();
        cutscene = GameObject.Find("TutorialCutscene").GetComponent<TutorialCutscene>();
    }

    // Update is called once per frame
    void Update()
    {
        // Don't activate timer until cutscene is finished playing
        if(!cutscene.GetStatus()){
            return;
        }
        if(VictoryScreen.gameObject.activeSelf)
        {
            return;
        }
        if(timer > 0.5f)
        {
            timer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            string readableTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            uiText.text = readableTime;
        }
        if(target.isEscaping() && !catchline){
            firstBanter = true;
            secondBanter = true;
            HurryUpReminder = true;
            dialogue.CatchLine();
            catchline = true;
        }
        if(timer <= 180f && !firstBanter){
            dialogue.banter();
            firstBanter = true;
        }
        if(timer <= 120f && !secondBanter){
            dialogue.banter();
            secondBanter = true;
        }
        if(timer <= 60f && !HurryUpReminder){
            dialogue.TimeAlmostUp();
            // Also speed up music
            MainTheme.pitch = 1.5f;
            HurryUpReminder = true;
        }
        // Displays Game Over screen when timer goes to 0
        else if(timer <= 0.5f)
        {
            for (int i = 0; i < ReInput.players.playerCount; i++)
            {
                Player player = ReInput.players.Players[i];
                player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "GameOver", "default", true);
                player.controllers.maps.LoadMap(ControllerType.Joystick, player.id, "default", "default", false);
            }

            GameOverScreen.SetActive(true);

            if(selected == false){
                firstSelected = GameOverScreen.GetComponentsInChildren<Button>()[0];
                firstSelected.Select();
                selected = true;
            }

            uiText.text = "0:00";
            timer = 0.0f;

            // Stop main theme and start Game Over music
            
            if(MainTheme.isPlaying || CatchTheme.isPlaying){
                MainTheme.Stop();
                CatchTheme.Stop();
                GameOverTheme.Play();
            }
        }
    }

    public void setTimer(float value)
    {
        timer = value;
    }
}
