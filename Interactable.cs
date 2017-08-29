using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {

	[HideInInspector]
	public NavMeshAgent playerAgent;

	private bool hasInteracted;
	bool isEnemy;


	public virtual void MoveToInteraction(NavMeshAgent playerAgent)
	{
		isEnemy = gameObject.tag == "enemy";
		hasInteracted = false;
		this.playerAgent = playerAgent;
		playerAgent.stoppingDistance = 2f;
		playerAgent.destination = this.transform.position;
	}
	void Update()
	{
		if(!hasInteracted && playerAgent != null && !playerAgent.pathPending && playerAgent.stoppingDistance != 0)
		{
			if(playerAgent.remainingDistance <= playerAgent.stoppingDistance)
			{
				
				Debug.Log ("At the point");
				if(!isEnemy)
					Interact ();
				EnsureLookDirection ();
				hasInteracted = true;
			}
		}
	} 
	public virtual void Interact()
	{
		Debug.Log ("Interacting with base class");
	}

	void EnsureLookDirection()
	{
		playerAgent.updateRotation = false;
		Vector3 lookDirection = new Vector3 (transform.position.x, playerAgent.transform.position.y, transform.position.z);
		playerAgent.transform.LookAt (lookDirection);
		playerAgent.updateRotation = true;
	}
}
