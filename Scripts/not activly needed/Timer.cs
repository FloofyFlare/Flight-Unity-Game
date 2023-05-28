using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	[SerializeField] private GameObject time;
	public Text text_box;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
		Player player = time.GetComponent<Player>();

		text_box.text = (("Score ") + player.counter.ToString("0"));
	}
}
