using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class dialogueManager : MonoBehaviour
{
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI monologueText;

	public Dialogue currentDialogue;
	private DialogImporter di;
	private Dictionary<string,Dialogue> gd;
	private Queue<string> sentences;
	private GameObject monologue;
	private GameObject continueButton;
	private GameObject OptionA;
	private GameObject OptionB;
	private GameObject Option1;
	private GameObject Option2;
	private GameObject Option3;
	private GameObject Option4;

	private Dialogue DialogA;
	private Dialogue DialogB;
	private Dialogue Dialog1;
	private Dialogue Dialog2;
	private Dialogue Dialog3;
	private Dialogue Dialog4;
	    // Start is called before the first frame update
    void Start()
    {
		di=GetComponent<DialogImporter>();
		gd= di.GameDialog;
		monologue = GameObject.FindGameObjectWithTag("Monologue");
		continueButton = GameObject.FindGameObjectWithTag("Continue Button");
		OptionA = GameObject.FindGameObjectWithTag("2Option1");
		OptionB = GameObject.FindGameObjectWithTag("2Option2");
		Option1 = GameObject.FindGameObjectWithTag("4Option1");
		Option2 = GameObject.FindGameObjectWithTag("4Option2");
		Option3 = GameObject.FindGameObjectWithTag("4Option3");
		Option4 = GameObject.FindGameObjectWithTag("4Option4");
    }


	public void StartDialogue(Dialogue dialogue) 
	{
		currentDialogue = gd["1"];
		PrepareMonologue();
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
			PrepareMonologue();
			currentDialogue = gd[""+ currentDialogue.links[0]];
			monologueText.text = currentDialogue.text;
			//set the clipart
		}
		if(currentDialogue.decisions==2)
		{
			Prepare2Choice();
			DialogA = gd[""+ currentDialogue.links[0]];
			DialogB = gd["" + currentDialogue.links[1]]; 
			OptionA.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(DialogA.text);
			OptionB.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(DialogB.text);
			//get rid of current text
			//hide ok button
			//display hidden buttons/generate buttons using currentText.decisions as N
			//
		}
		if(currentDialogue.decisions==3) {Debug.Log("there is no 3 choice system");}
		if(currentDialogue.decisions==4)
		{
			Prepare4Choice();
			Dialog1 = gd[""+ currentDialogue.links[0]];
			Dialog2 = gd["" + currentDialogue.links[1]]; 
			Dialog3 = gd[""+ currentDialogue.links[2]];
			Dialog4 = gd[""+ currentDialogue.links[3]];

			Option1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(Dialog1.text);
			Option2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(Dialog2.text);
			Option3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(Dialog3.text);
			Option4.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(Dialog4.text);
		}
		//if decisions = 0 , ok button and load next, and change buttons, etc.
		//if decisions >0 load buttons with specific dialogues
	}

	void PrepareMonologue()
	{
		monologue.SetActive(true);
		continueButton.SetActive(true);
		OptionA.SetActive(false);
		OptionB.SetActive(false);
		Option1.SetActive(false);
		Option2.SetActive(false);
		Option3.SetActive(false);
		Option4.SetActive(false);
	}

	void Prepare2Choice()
	{
		monologue.SetActive(false);
		continueButton.SetActive(false);
		OptionA.SetActive(true);
		OptionB.SetActive(true);
		Option1.SetActive(false);
		Option2.SetActive(false);
		Option3.SetActive(false);
		Option4.SetActive(false);
	}

	void Prepare4Choice()
	{
		monologue.SetActive(true);
		continueButton.SetActive(true);
		OptionA.SetActive(false);
		OptionB.SetActive(false);
		Option1.SetActive(true);
		Option2.SetActive(true);
		Option3.SetActive(true);
		Option4.SetActive(true);
	}
	//remember to set the clipart
	void ButtonA()
	{
		PrepareMonologue();
		currentDialogue = gd[""+ DialogA.links[0]];
		monologueText.text = currentDialogue.text;
	}

	void ButtonB()
	{
		PrepareMonologue();
		currentDialogue = gd[""+ DialogA.links[0]];
		monologueText.text = currentDialogue.text;
	}

	void Button1()
	{
		PrepareMonologue();
		currentDialogue = gd[""+ Dialog1.links[0]];
		monologueText.text = currentDialogue.text;		
	}
	void Button2()
	{
		PrepareMonologue();
		currentDialogue = gd[""+ Dialog2.links[0]];
		monologueText.text = currentDialogue.text;		
	}
	void Button3()
	{
		PrepareMonologue();
		currentDialogue = gd[""+ Dialog3.links[0]];
		monologueText.text = currentDialogue.text;		
	}
	void Button4()
	{
		PrepareMonologue();
		currentDialogue = gd[""+ Dialog4.links[0]];
		monologueText.text = currentDialogue.text;		
	}
	

	void EndDialogue() //also hide text field, and all related elements.
	{
		Debug.Log("End of conversation");
	}

}
