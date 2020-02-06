using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instructionManager : MonoBehaviour
{

    public Text hint;
    public string text;
    public Camera Dis_camera;

    // Update is called once per frame
    void Update()
    {
        Vector3 hintPos = Dis_camera.WorldToScreenPoint(this.transform.position);
        hint.transform.position = hintPos;
    }

    public void show() {
        hint.text = text;
    }

    public void hide() {
        hint.text = "";
    }

    public void changeHint(string newHint) {
        text = newHint;
    }

    public void changeAndUpdateHint(string newHint) {
        text = newHint;
        show();
    }
}
