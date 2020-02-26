using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusDialogue : MonoBehaviour
{
    public Flowchart flowchart;
    private List<int> Banterlist = new List<int>{1,2,3,4,5};
    // Start is called before the first frame update
    public void banter(){
        int randomNum = Random.Range(Banterlist[0], Banterlist.Count + 1);
        string blockName = "Banter" + randomNum.ToString();
        Debug.Log(blockName);
        Banterlist.Remove(randomNum);
        flowchart.ExecuteBlock(blockName);
    }

    public void TimeAlmostUp(){
        flowchart.ExecuteBlock("Hurry");
    }
}
