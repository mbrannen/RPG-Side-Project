using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Looking : MonoBehaviour {


	UnityEvent newItem = new UnityEvent();
	Wandering moveControl;
	public float lookDistance;
	public float lookAngle;
	public int layer;
	private int layermask;
	public LayerMask lootMask;
	public LayerMask wallMask;
	[Range(1,60)]
	public int segments;
	public GameObject eyes;
	public GameObject eyesAngledHalf;
	public GameObject eyesAngledLow;
	public Quaternion dir;
	private Vector3 eyesLine;
	public Memory memory;

	// Use this for initialization
	void Start () {
		
		moveControl = GetComponent<Wandering> ();
		layermask = 1 << layer;
		memory = GetComponent<Memory> ();
		dir = Quaternion.AngleAxis (30f, eyes.transform.forward);
		eyesLine = eyes.transform.forward * lookDistance;
		eyesLine = dir * eyesLine;
	}
	
	// Update is called once per frame
	void Update () {
		//dir = Quaternion.AngleAxis (30f, eyes.transform.forward.normalized);
		//Debug.DrawRay (eyes.transform.position, eyes.transform.forward.normalized * lookDistance, Color.green  );
		//Debug.DrawRay (eyes.transform.position, (Quaternion.Euler(0,30,0)*eyes.transform.forward).normalized * lookDistance, Color.red  );
		Sweep ();
		DownSweep ();
		LowSweep ();
		//Debug.DrawRay ();
		
	}


	public void Sweep()
	{
		Vector3 startPos = eyes.transform.position;
		Vector3 targetPos = Vector3.zero;

		int startAngle = (int)(lookAngle * .5f)*(-1);
		int finishAngle = (int)(lookAngle * .5f);
		int inc = (int)(lookAngle / segments);



		RaycastHit hit;

		for (int i = startAngle; i < finishAngle; i+= inc) {

			targetPos = (Quaternion.Euler (0, i, 0) * eyes.transform.forward).normalized * lookDistance;
			Debug.DrawRay (startPos, targetPos, Color.cyan);

			if(Physics.Raycast(startPos,targetPos,out hit, lookDistance,lootMask))
			{
				
				if(memory.knownObjects.Find(x => x.transform.name == hit.collider.gameObject.name) == null)
				{
					memory.AddToMemory(hit.collider.gameObject);
					newItem.AddListener (delegate {
						moveControl.Wander();
					});
					Debug.Log ("Memorized " + hit.collider.gameObject.name);
	
				}

			}



		}



	}
	public void DownSweep()
	{
		Vector3 startPos = eyesAngledHalf.transform.position;
		Vector3 targetPos = Vector3.zero;

		int startAngle = (int)(lookAngle * .5f)*(-1);
		int finishAngle = (int)(lookAngle * .5f);
		int inc = (int)(lookAngle / segments);



		RaycastHit hit;

		for (int i = startAngle; i < finishAngle; i+= inc) {

			targetPos = (Quaternion.Euler (0, i, 0) * eyesAngledHalf.transform.forward).normalized * lookDistance;
			Debug.DrawRay (startPos, targetPos, Color.cyan);
			if(Physics.Raycast(startPos,targetPos,out hit, lookDistance,lootMask))
			{

				if(memory.knownObjects.Find(x => x.transform.name == hit.collider.gameObject.name) == null)
				{
					memory.AddToMemory(hit.collider.gameObject);
					Debug.Log ("Memorized " + hit.collider.gameObject.name);
				}

			}

		}
	}
	public void LowSweep()
	{
		Vector3 startPos = eyesAngledLow.transform.position;
		Vector3 targetPos = Vector3.zero;

		int startAngle = (int)(lookAngle * .5f)*(-1);
		int finishAngle = (int)(lookAngle * .5f);
		int inc = (int)(lookAngle / segments);



		RaycastHit hit;

		for (int i = startAngle; i < finishAngle; i+= inc) {

			targetPos = (Quaternion.Euler (0, i, 0) * eyesAngledLow.transform.forward).normalized * lookDistance;
			Debug.DrawRay (startPos, targetPos, Color.cyan);
			if(Physics.Raycast(startPos,targetPos,out hit, lookDistance,lootMask))
			{

				if(memory.knownObjects.Find(x => x.transform.name == hit.collider.gameObject.name) == null)
				{
					memory.AddToMemory(hit.collider.gameObject);
					Debug.Log ("Memorized " + hit.collider.gameObject.name);
				}

			}

		}
	}

}
