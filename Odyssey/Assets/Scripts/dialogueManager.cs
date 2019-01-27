using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class dialogueManager : MonoBehaviour
{
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;

	public Dialogue currentDialogue;
	private DialogImporter di;
	private Dictionary<string,Dialogue> gd;
	private Queue<string> sentences;

	    // Start is called before the first frame update
    void Start()
    {
		di=GetComponent<DialogImporter>();
		gd= di.GameDialog;
    }


	public void StartDialogue(Dialogue dialogue) 
	{
		currentDialogue = gd["1"];
		//nameText.text = dialogue.name;
		//foreach(string sentence in dialogue.sentences)
		//{
		//	sentences.Enqueue(sentence);
		//}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		currentDialogue.Continue();
		if(currentDialogue.decisions == -1)
		{
			EndDialogue();
			return;
		}
		if(currentDialogue.decisions == 0)
		{
			currentDialogue = gd[""+ currentDialogue.links[0]];
			dialogueText.text = currentDialogue.text;
			//set the clipart
			
		}
		if(currentDialogue.decisions>0)
		{
			//get rid of current text
			//hide ok button
			//display hidden buttons/generate buttons using currentText.decisions as N
			//


		}
		//if decisions = 0 , ok button and load next, and change buttons, etc.
		//if decisions >0 load buttons with specific dialogues
	}

	void EndDialogue() //also hide text field, and all related elements.
	{
		Debug.Log("End of conversation");
	}

}
