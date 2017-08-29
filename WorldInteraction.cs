using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

	NavMeshAgent playerAgent;


	// Use this for initialization
	void Start () {
		playerAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
			GetInteraction ();
		}
	}

	void GetInteraction(){
		Ray interactionRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit InteractionInfo;
		if(Physics.Raycast(interactionRay,out InteractionInfo, Mathf.Infinity))
		{
			GameObject interactedObject = InteractionInfo.collider.gameObject;

			if (interactedObject.tag == "Enemy") 
			{
				Debug.Log ("Moving to enemy");
				interactedObject.GetComponent<Interactable> ().MoveToInteraction (playerAgent);
			}
			else if (interactedObject.tag == "Interactable Object") {
				Debug.Log ("Moving to interactable");
				interactedObject.GetComponent<Interactable> ().MoveToInteraction (playerAgent);


			} else {
				playerAgent.stoppingDistance = 0f;
				playerAgent.destination = InteractionInfo.point;
			}
		}
	}
}
