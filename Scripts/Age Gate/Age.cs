using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Age 
{
	public int age;
	public Age (AgeOverlay admob)
	{

		age = admob.age;
	}
}
