using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class ItemDatabase : MonoBehaviour {

	public static ItemDatabase Instance { get; set;}

	private List<Item> Items {get;set;}


	// Use this for initialization
	void Start () {

		if(Instance != null && Instance != this)
		{
			Destroy (gameObject);
		}
		else 
		{
			Instance = this;
		}
		BuildDatabase ();
	}
	
	private void BuildDatabase()
	{
		Items = JsonConvert.DeserializeObject<List<Item>> (Resources.Load<TextAsset>("JSON/Items.json").ToString());
		Debug.Log (Items [0].Stats [0].StatName + "level is " + Items[0].Stats[0].GetCalculatedStatValue());
		Debug.Log (Items [0].ItemName);
		Debug.Log (Items [1].ItemName);
		Debug.Log (Items [2].ItemName);
	}

	public Item GetItem(string itemSlug)
	{
		foreach (Item item in Items) {
			if(item.ObjectSlug == itemSlug)
			{
				return item;
			}

		}
		Debug.Log ("Couldn't find item: " + itemSlug);
		return null;
	}
}
