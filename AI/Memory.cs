using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour {


	public List<GameObject> knownObjects {
		get;
		set;
	}



	public string[] nameList;
	public int objectCount;

	void Start()
	{
		
		nameList = new string[200];
		objectCount = 0;
		knownObjects = new List<GameObject> ();
	}
		
	public void AddToMemory(GameObject item)
	{
		knownObjects.Add (item);
		nameList [objectCount] = item.transform.name;
		objectCount++;

	}

}
