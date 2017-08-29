using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility {

	public string name {
		get;
		set;
	}
	public float min {
		get;
		set;
	}
	public float max {
		get;
		set;
	}

	public float currentValue {
		get;
		set;
	}

	public float percentageValue {
		get;
		set;
	}

	public float utilityScore {
		get;
		set;
	}


	public Utility(string _name, float _min, float _max, float _currentValue)
	{
		name = _name;
		min = _min;
		max = _max;
		currentValue = _currentValue;
		percentageValue = currentValue / max;
		utilityScore = 0;
	}
	public Utility(string _name, float _min, float _max)
	{
		name = _name;
		min = _min;
		max = _max;
		currentValue = 0;
		percentageValue = currentValue / max;
		utilityScore = 0;
	}

	public float GetPercentageValue()
	{
		percentageValue = (currentValue / max)*100;
		return percentageValue;
	}





}
