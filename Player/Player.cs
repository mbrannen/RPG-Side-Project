using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public CharacterStats characterStats;
	public float currentHealth;
	public float maxHealth;

	// Use this for initialization
	void Start () {

		this.currentHealth = this.maxHealth;
		characterStats = new CharacterStats (10, 10, 10);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
			Die ();
	}

	private void Die()
	{
		Debug.Log("Player Dead. Reset Health");
		this.currentHealth = this.maxHealth;
	}
}
