using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
	public string name;
	[TextArea(3,10)]
	public string[] sentences;


    public string key;
    public string text;
    public int decisions;
    public int[] links;
    public string clipart;
    public Action action;

    public string[] sounds;

    public string scene2play;

    public Dialogue(string key, string text, int decisions, int[] links, string clipart, Action action, string toparsesounds,string scene2play)
    {
        this.key = key;
        this.text = text;
        this.decisions = decisions;
        this.links = links;
        this.clipart = clipart;
        this.action = action;
        this.sounds = toparsesounds.Split('\\');
        for(int i = 0 ; i < sounds.Length; i++)
            sounds[i] = sounds[i].Trim();
        this.scene2play = scene2play.Trim();
    }
    public void Continue()
    {
        action();
    }

}


//game manager keeps track of current dialogue and resources 