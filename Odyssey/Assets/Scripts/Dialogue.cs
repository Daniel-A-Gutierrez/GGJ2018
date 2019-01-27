using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string key;
    public string text;
    public int decisions;
    public int[] links;
    public string clipart;
    public Action action;

    public Dialogue(string key, string text, int decisions, int[] links, string clipart, Action action)
    {
        this.key = key;
        this.text = text;
        this.decisions = decisions;
        this.links = links;
        this.clipart = clipart;
        this.action = action;
    }
    public void Continue()
    {
        action();
    }

}
