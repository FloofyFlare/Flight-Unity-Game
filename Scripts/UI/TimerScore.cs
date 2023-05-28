using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimerScore
{
	public int highScore;
	public TimerScore(Player player)
	{
		highScore = player.counter;
	}

}