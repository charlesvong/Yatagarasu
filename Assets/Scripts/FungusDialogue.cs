using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusDialogue : MonoBehaviour
{
    public Flowchart flowchart;
    public int HintNumber;
    private List<int> Banterlist = new List<int>{1,2,3,4,5};

    private List<int> OneLinerlist = new List<int>{1,2,3};

    public void banter(){
        int randomNum = Random.Range(Banterlist[0], Banterlist.Count + 1);
        string blockName = "Banter" + randomNum.ToString();
        var sayDialog = Fungus.SayDialog.GetSayDialog(); 
        if(sayDialog.isActiveAndEnabled){
            return;
        }
        Banterlist.Remove(randomNum);
        flowchart.ExecuteBlock(blockName);
    }

    public void TimeAlmostUp(){
        var sayDialog = Fungus.SayDialog.GetSayDialog(); 
        if(sayDialog.isActiveAndEnabled){
            return;
        }
        flowchart.ExecuteBlock("Hurry");
    }

    public void hint(){
        string blockName = "Hint" + HintNumber.ToString();
        var sayDialog = Fungus.SayDialog.GetSayDialog(); 
        if(sayDialog.isActiveAndEnabled){
            return;
        }
        flowchart.ExecuteBlock(blockName);
    }

    public void CaughtDialogue(int callerID){
        string blockName = "Caught" + callerID.ToString();
        var sayDialog = Fungus.SayDialog.GetSayDialog(); 
        if(sayDialog.isActiveAndEnabled){
            return;
        }
        flowchart.ExecuteBlock(blockName);
    }

    public void OneLiner(int callerID){
        int randomNum = Random.Range(OneLinerlist[0], OneLinerlist.Count + 1);
        if(randomNum == callerID && callerID == 1){
            randomNum++;
        }
        else if(randomNum == callerID && callerID == 2){
            randomNum++;
        }
        else if(randomNum == callerID && callerID == 3){
            randomNum--;
        }
        string blockName = "OneLiner" + randomNum.ToString();
        var sayDialog = Fungus.SayDialog.GetSayDialog(); 
        if(sayDialog.isActiveAndEnabled){
            return;
        }
        flowchart.ExecuteBlock(blockName);
    }
}
