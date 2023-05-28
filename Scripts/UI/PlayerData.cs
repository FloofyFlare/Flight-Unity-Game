using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

	public int lvlprogress;
	public int highScore;
	public PlayerData (Player player)
    {
		
		lvlprogress = player.lvlprogress;
    }

}
