using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screenSizeAdj : MonoBehaviour
{

    public float factor;
    // Start is called before the first frame update
    void Start()
    {
        if (Screen.width / 4 > Screen.height / 3)
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height * factor / 3 * 4, Screen.height * factor);
        }
        else {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * factor , Screen.width * factor / 4 * 3);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
