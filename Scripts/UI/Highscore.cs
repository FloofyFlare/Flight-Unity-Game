using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
	
	public Text text_box;
	private int highscore;
	// Start is called before the first frame update
	void Start()
    {
		TimerScore data = SaveSystem.LoadScore();
		highscore = data.highScore;
	}

	
	// Use this for initialization


	// Update is called once per frame
	void Update()
	{
		text_box.text = (("High Score: ") + highscore.ToString("0"));
	}
}
