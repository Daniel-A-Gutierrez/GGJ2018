using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour

{
    public dialogueManager dm;

    public void getStarted()
    {
        dm = GetComponent<dialogueManager>();
    }
    public void doNothing()
    {
        
    }

    public void Default()
    {//only under condidtion dialog manager is callling continue on currentdialogue lol
        Dialogue d = dm.currentDialogue;
        dm.AM.StopEverythingBut(d.sounds[0]);
        foreach(string sou in d.sounds)
            dm.AM.Play(sou);
        dm.MasterCopies.GetComponent<SceneChanger>().changeScene(d.scene2play);
    }
    
}
