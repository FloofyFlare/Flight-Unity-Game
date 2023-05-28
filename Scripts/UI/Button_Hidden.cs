using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Button_Hidden : MonoBehaviour {
	public int sizeOfArray;
	public Button[] button;
	public GameObject overlayController;

	// Update is called once per frame
	void Start()
	{
		
		for (int i = 0; i < sizeOfArray; i++)
		{
			if (button[i])
            {
				button[i].interactable = false;
			}

			
		}

		
		Button();
	}
	void Update () {
		Overlay overlay = overlayController.GetComponent<Overlay>();
		
		
	}
	void Button()
    {
		Overlay overlay = overlayController.GetComponent<Overlay>();
		overlay.LoadPlayer();
		for (int i = 0; i < overlay.currentLevel; i++)
		{
			Debug.Log(overlay.currentLevel);
			if (button[i])
			{
				button[i].interactable = true;
			}
		}
	}
    public void LoadGame()
    {
		Debug.Log("GameLoad");
		Overlay overlay = overlayController.GetComponent<Overlay>();
		overlay.LoadPlayer();
	}
}
