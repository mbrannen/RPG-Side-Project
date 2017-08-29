using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem {
	public string[] signMessage;
	public string signName;

	public override void Interact()
	{
		DialogueHandler.Instance.AddNewDialouge (signName,signMessage);
		Debug.Log ("Sign post");
	}
}

	

