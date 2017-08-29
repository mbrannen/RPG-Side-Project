using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Slime : MonoBehaviour, IEnemy {

	public LayerMask aggroLayerMask;
	private NavMeshAgent navAgent;
	public float currentHealth, power, toughness;
	public float maxHealth;

	private Player player;
	private CharacterStats characterStats;
	private Collider[] withinAggroColliders;


	void Start()
	{
		navAgent = GetComponent<NavMeshAgent> ();
		characterStats = new CharacterStats (6, 10, 2);
		currentHealth = maxHealth;
	}

	void FixedUpdate()
	{
		withinAggroColliders = Physics.OverlapSphere (transform.position, 10, aggroLayerMask);
		if(withinAggroColliders.Length > 0)
		{
			ChasePlayer (withinAggroColliders [0].GetComponent<Player> ());
			Debug.Log ("Found Player i think!");
		}
	}

	public void PerformAttack()
	{
		player.TakeDamage (5);
		//throw new NotImplementedException ();
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
			Die ();
	}

	void ChasePlayer(Player player)
	{
		this.player = player;
		navAgent.SetDestination (player.transform.position);
		if(navAgent.remainingDistance <= navAgent.stoppingDistance)
		{
			if(!IsInvoking("PerformAttack"))
				InvokeRepeating ("PerformAttack", .5f, 2f);
		}
		else{
			//Debug.Log ("Not within distance");
			CancelInvoke ("PerformAttack");
		}



	}

	void Die()
	{
		Destroy (gameObject);
	}
}
