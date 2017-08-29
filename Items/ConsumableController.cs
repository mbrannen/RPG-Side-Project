using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour {

	CharacterStats stats;
	// Use this for initialization
	void Start () {
		stats = GetComponent<Player> ().characterStats;
	}
	
	public void ConsumeItem(Item item)
	{
		GameObject itemtoSpawn = Instantiate (Resources.Load<GameObject> ("Consumables/" + item.ObjectSlug));
		if(item.ItemModifier)
		{
			itemtoSpawn.GetComponent<IConsumable> ().Consume (stats);

		}
		else
			itemtoSpawn.GetComponent<IConsumable> ().Consume ();
		
			
	}
}
