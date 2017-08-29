using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

	public RectTransform inventoryPanel;
	public RectTransform scrollViewContent;
	InventoryUIItem itemConstainer{ get; set;}
	bool menuIsActive { get; set;}
	Item currentSelectedItem {get;set;}

	void Start()
	{
		itemConstainer = Resources.Load<InventoryUIItem> ("UI/Item_Container");
		UIEventHandler.OnItemAddedToInventory += ItemAdded;
		inventoryPanel.gameObject.SetActive (false);

	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			menuIsActive = !menuIsActive;
			inventoryPanel.gameObject.SetActive (menuIsActive);
		}
	}

	void ItemAdded (Item item)
	{
		InventoryUIItem emptyItem = Instantiate (itemConstainer);
		emptyItem.SetItem (item);
		emptyItem.transform.SetParent (scrollViewContent);

	}
}
