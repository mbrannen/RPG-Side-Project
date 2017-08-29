using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityManager : MonoBehaviour {

	public AnimationCurve hungerUtilC;
	public AnimationCurve thirstUtilC;

	public Utility _hunger;
	public Utility _thirst;
	public Utility _exploration;
	public Utility highestUtil;

	public List<Utility> utilities = new List<Utility> ();

	[Range(0,100)]public float hunger;
	[Range(0,100)]public float thirst;
	[Range(0,100)]public float exploration;
	public float hungerUtil;
	public float thirstUtil;
	public float explorationUtil;

	public string highestUtilName;
	public float highestUtilValue;

	public float utilitiesCount;
	// Use this for initialization
	void Start () {

	
		explorationUtil = exploration;

		highestUtil = new Utility ("Highest Utility", 0, 100, 0);
		_hunger = new Utility ("Hunger", 0, 100,hunger);
		_thirst = new Utility ("Thirst", 0, 100,thirst);
		_exploration = new Utility ("Exploration", 0, 100,exploration);


		utilities.Add (highestUtil);
		utilities.Add (_hunger);
		utilities.Add (_thirst);
		utilities.Add (_exploration);
		utilities [3].utilityScore = explorationUtil;





	}
	
	// Update is called once per frame
	void Update () {

		hunger -= Time.deltaTime;
		thirst -= Time.deltaTime * 2;

		utilities[1].currentValue = hunger;
		utilities[2].currentValue = thirst;

		hungerUtil = hungerUtilC.Evaluate (utilities[1].GetPercentageValue()/100)*100;
		thirstUtil = thirstUtilC.Evaluate (utilities[2].GetPercentageValue()/100)*100;

		utilities [1].utilityScore = hungerUtil;
		utilities [2].utilityScore = thirstUtil;


		foreach(Utility u in utilities)
		{
			
			if (u.utilityScore > utilities[0].utilityScore)
				utilities[0] = u;


		}

		highestUtilValue = utilities[0].utilityScore;
		highestUtilName = utilities[0].name;


	}
}
