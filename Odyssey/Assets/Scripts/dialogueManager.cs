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
	public GameObject portraitGO;
	public Sprite Gary_portrait;
	public Sprite MC_portrait;
	public Sprite Robert_portrait;
	public Sprite Joe_portrait;

	private Dialogue DialogA;
	private Dialogue DialogB;
	private Dialogue Dialog1;
	private Dialogue Dialog2;
	private Dialogue Dialog3;
	private Dialogue Dialog4;

	public GameObject MasterCopies;
	public AudioManager AM;
	public Actions actions;
	    // Start is called before the first frame update
    void Start()
    {

		di=GetComponent<DialogImporter>();
		gd= di.GameDialog;
		MasterCopies = GameObject.Find("MasterCopies");
		AM = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
		actions = GetComponent<Actions>();
		monologue = GameObject.FindGameObjectWithTag("Monologue");
		continueButton = GameObject.FindGameObjectWithTag("Continue Button");
		OptionA = GameObject.FindGameObjectWithTag("2Option1");
		OptionB = GameObject.FindGameObjectWithTag("2Option2");
		Option1 = GameObject.FindGameObjectWithTag("4Option1");
		Option2 = GameObject.FindGameObjectWithTag("4Option2");
		Option3 = GameObject.FindGameObjectWithTag("4Option3");
		Option4 = GameObject.FindGameObjectWithTag("4Option4");
		portraitGO = GameObject.FindGameObjectWithTag("Portrait");
		actions.getStarted();
		StartDialogue();	
    }

	void setClipart()
	{
		if(currentDialogue.clipart == "")	{portraitGO.SetActive(false);}
		else 
		{
			portraitGO.SetActive(true);
			setPortrait(currentDialogue.clipart);
		}
	}


	public void StartDialogue() 
	{
		currentDialogue = gd["1"];
		monologue.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(currentDialogue.text);
		PrepareMonologue();

	}

	public void DisplayNextSentence()
	{
		currentDialogue.Continue();
		if(currentDialogue.decisions == -1)
		{
			PrepareMonologue();
			EndDialogue();
			return;
		}
		else if(currentDialogue.decisions == 0)
		{
			currentDialogue = gd[""+ currentDialogue.links[0]];
			monologue.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(currentDialogue.text);
			PrepareMonologue();
		}
		else if(currentDialogue.decisions==2)
		{
			DialogA = gd[""+ currentDialogue.links[0]];
			DialogB = gd["" + currentDialogue.links[1]]; 
			OptionA.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(DialogA.text);
			OptionB.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(DialogB.text);
			Prepare2Choice();
			//get rid of current text
			//hide ok button
			//display hidden buttons/generate buttons using currentText.decisions as N
			//
		}
		else if(currentDialogue.decisions==3) {Debug.Log("there is no 3 choice system");}
		else if(currentDialogue.decisions==4)
		{
			
			Dialog1 = gd[""+ currentDialogue.links[0]];
			Dialog2 = gd["" + currentDialogue.links[1]]; 
			Dialog3 = gd[""+ currentDialogue.links[2]];
			Dialog4 = gd[""+ currentDialogue.links[3]];

			Option1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(Dialog1.text);
			Option2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(Dialog2.text);
			Option3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(Dialog3.text);
			Option4.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(Dialog4.text);
			Prepare4Choice();
		}
		//if decisions = 0 , ok button and load next, and change buttons, etc.
		//if decisions >0 load buttons with specific dialogues
	}

	public void setPortrait(string clipart)
	{
		if(clipart == "MC") {portraitGO.GetComponent<Image>().sprite = MC_portrait;}
		if(clipart == "Gary") {portraitGO.GetComponent<Image>().sprite = Gary_portrait;}
		if(clipart == "Joe") {portraitGO.GetComponent<Image>().sprite = Joe_portrait;}
		if(clipart == "Robert") {portraitGO.GetComponent<Image>().sprite = Robert_portrait;}
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

		setClipart();

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
		if(DialogA.clipart == "")	{portraitGO.SetActive(false);}
		else 
		{
			portraitGO.SetActive(true);
			setPortrait(DialogA.clipart);
		}
	}

	void Prepare4Choice()
	{
		monologue.SetActive(false);
		continueButton.SetActive(false);
		OptionA.SetActive(false);
		OptionB.SetActive(false);
		Option1.SetActive(true);
		Option2.SetActive(true);
		Option3.SetActive(true);
		Option4.SetActive(true);
		if(Dialog1.clipart == "")	{portraitGO.SetActive(false);}
		else 
		{
			portraitGO.SetActive(true);
			setPortrait(Dialog1.clipart);
		}
	}
	//remember to set the clipart
	public void ButtonA()
	{
		currentDialogue = gd[""+ DialogA.links[0]];
		monologue.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(currentDialogue.text);
		PrepareMonologue();
	}

	public void ButtonB()
	{
		currentDialogue = gd[""+ DialogB.links[0]];
		monologue.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(currentDialogue.text);
		PrepareMonologue();

	}

	public void Button1()
	{
		currentDialogue = gd[""+ Dialog1.links[0]];
		monologue.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(currentDialogue.text);
		PrepareMonologue();

	}
	public void Button2()
	{
		currentDialogue = gd[""+ Dialog2.links[0]];
		monologue.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(currentDialogue.text);
		PrepareMonologue();

	}
	public void Button3()
	{
		currentDialogue = gd[""+ Dialog3.links[0]];
		monologue.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(currentDialogue.text);
		PrepareMonologue();

	}
	public void Button4()
	{
		currentDialogue = gd[""+ Dialog4.links[0]];
		monologue.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(currentDialogue.text);
		PrepareMonologue();

	}
	

	void EndDialogue() //also hide text field, and all related elements.
	{
		Debug.Log("End of conversation");
		monologue.SetActive(false);
		continueButton.SetActive(false);
		OptionA.SetActive(false);
		OptionB.SetActive(false);
		Option1.SetActive(false);
		Option2.SetActive(false);
		Option3.SetActive(false);
		Option4.SetActive(false);
		portraitGO.SetActive(false);
	}

}
