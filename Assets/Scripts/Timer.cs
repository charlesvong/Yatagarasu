using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float maxTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            string readableTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            uiText.text = readableTime;
        }

        else if(timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0:00";
            timer = 0.0f;
        }
    }
}
