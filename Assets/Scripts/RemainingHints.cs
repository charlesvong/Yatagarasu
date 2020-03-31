using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingHints : MonoBehaviour
{
    public GameObject NPClist;
    private int startingCount;
    public Text uiText;
    private string remainingText;
    // Start is called before the first frame update
    void Start()
    {
        startingCount = NPClist.transform.childCount;
        remainingText = string.Format("Remaining: {0}", startingCount);
        uiText.text = remainingText;
    }

    // Update is called once per frame
    void Update()
    {
        remainingText = string.Format("Remaining: {0}", startingCount);
        uiText.text = remainingText;
    }

    public void decreaseCount()
    {
        startingCount--;
    }
}
