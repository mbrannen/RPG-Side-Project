using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpOnFinish : MonoBehaviour {

	void Start()
	{
		
	}
	void Update () 
	{
		if(!gameObject.GetComponent<ParticleSystem> ().isPlaying)
		{
			Destroy (gameObject);
		}
	}
}
