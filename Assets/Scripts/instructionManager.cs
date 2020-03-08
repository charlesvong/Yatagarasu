using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instructionManager : MonoBehaviour
{
    public Image circleButton;
    public Image XButton;
    public Text hint;
    public string text;
    public Camera Dis_camera;
    public float factor;
    public float vert_factor;
    private Vector3 circle_offset;
    private Vector3 X_offset;

    void Start(){
        circleButton.enabled = false;
        XButton.enabled = false;
        if(Screen.width >= 1920){
            factor -= 0.03f;
        }
        if(Screen.height >= 1080){
            vert_factor -= 0.02f;
        }
        circle_offset = new Vector3(-70 + (factor * Screen.width),25,0);
        X_offset = new Vector3(-90 + (factor * Screen.width),-20,0);

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 hintPos = Dis_camera.WorldToScreenPoint(this.transform.position);
        hint.transform.position = hintPos;

        circleButton.transform.position = hintPos + circle_offset;
        XButton.transform.position = hintPos + X_offset;
    }

    public void show(int actionCode) {
        hint.text = text;
        if(actionCode == 0){
            X_offset = new Vector3(-90 + (factor * Screen.width),0,0);
            circleButton.enabled = false;
            XButton.enabled = true;
        }
        else if (actionCode == 3)
        {
            circleButton.enabled = false;
            XButton.enabled = false;
        }
        else if(actionCode == 2){
            XButton.enabled = false;
            float new_factor = factor;
            if(Screen.width >= 1920){
                new_factor -= 0.03f;
            }
            circle_offset = new Vector3(-120 + (new_factor * Screen.width),0,0);
            circleButton.enabled = true;
        }
        else{
            circle_offset = new Vector3(-70 + (factor * Screen.width),25 + (-vert_factor * Screen.height),0);
            X_offset = new Vector3(-90 + (factor * Screen.width),-20 + (vert_factor * Screen.height),0);
            circleButton.enabled = true;
            XButton.enabled = true;
        }
    }

    public void hide() {
        hint.text = "";
        circleButton.enabled = false;
        XButton.enabled = false;
    }

    public void changeHint(string newHint) {
        text = newHint;
    }

    public void changeAndUpdateHint(string newHint, int actionCode) {
        text = newHint;
        show(actionCode);
    }
}
