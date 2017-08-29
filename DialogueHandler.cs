using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour {

	public static DialogueHandler Instance { get; set; }
	public GameObject dialougePanel;

	Button continueButton;
	Text dialougeText, nameText;
	int dialougeIndex;

	public List<string> dialogueLines = new List<string>();
	public string npcName;


	void Awake()
	{
		dialougeText = dialougePanel.transform.Find ("Text").GetComponent<Text> ();
		nameText = dialougePanel.transform.Find ("Name").GetChild (0).GetComponent<Text> ();

		continueButton = dialougePanel.transform.Find ("Continue").GetComponent<Button> ();
		continueButton.onClick.AddListener (delegate {ContinueDialouge();});
		dialougePanel.SetActive (false);


		if (Instance != null && Instance != this) 
		{
			Destroy (gameObject);
		}
		else
		{
			Instance = this;
		}
	}
	public void AddNewDialouge(string name,string[] lines)
	{
		dialougeIndex = 0;
		dialogueLines = new List<string> (lines.Length);
		dialogueLines.AddRange (lines);
		this.npcName = name;
		Debug.Log (dialogueLines.Count);
		CreateDialouge ();
	}

	public void CreateDialouge()
	{
		dialougePanel.SetActive (true);
		//Debug.Log ("tried to set active");
		dialougeText.text = dialogueLines [dialougeIndex];
		nameText.text = npcName;

	}
	public void ContinueDialouge()
	{
		if (dialougeIndex < dialogueLines.Count - 1) {
			dialougeIndex++;
			dialougeText.text = dialogueLines [dialougeIndex];
		} else 
		{
			dialougePanel.SetActive (false);
		}
	}
}
