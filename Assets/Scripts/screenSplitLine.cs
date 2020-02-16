using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screenSplitLine : MonoBehaviour
{

    public bool vertical;
    public float width;
    // Start is called before the first frame update
    void Start()
    {
        if (vertical)
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(width, Screen.height /2);
        }
        else {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width /2 , width);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
