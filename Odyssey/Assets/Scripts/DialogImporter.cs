using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DialogImporter : MonoBehaviour
{

    


    // Start is called before the first frame update
    public string dialogCsvPath;
    [HideInInspector]
    public Dictionary<string,Dialogue> GameDialog;
    public Dictionary<string,Action> AllActions;
    //there will have to be a game manager to store all the flags
    void Awake()
    {
        AllActions = new Dictionary<string,Action>();
        GameDialog = new Dictionary<string,Dialogue>();
        initializeActions();
        string fileData  = System.IO.File.ReadAllText( Application.dataPath + "\\" + dialogCsvPath);
        string[] lines  = fileData.Split("\n"[0]);
        foreach(string line in lines)
        {
            if(line!="")
            {
                try{
                string[] lineData  = (line.Trim()).Split(","[0]);

                Dialogue d = new Dialogue(lineData[0],lineData[1],int.Parse(lineData[2]),parseDecisions(lineData[3]),
                    lineData[4],AllActions[lineData[5]] );
                GameDialog.Add(lineData[0],d);
                }
                catch(Exception e)
                {
                    Debug.LogError("Error parsing line: " + line + "\n" + e);
                }
            }
        }
        print("end");
    }

    int[] parseDecisions(string s)
    {
        if(!s.Contains("\\") )
        {
            int[] i = {int.Parse(s)};
            return i;
        }

        string[] sdecisions = s.Split('\\');
        int[] idecisions = new int[sdecisions.Length];
        for(int i = 0 ; i < sdecisions.Length ; i++)
        {
            idecisions[i] = int.Parse(sdecisions[i]);
        }
        if(idecisions[0] == 0) {Debug.Log("error parsing decisions : " + s);}
        return idecisions;

    }

    void initializeActions()
    {
        AllActions.Add("doNothing" , Actions.doNothing);
        AllActions.Add("", Actions.doNothing);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
