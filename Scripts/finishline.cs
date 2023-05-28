using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishline : MonoBehaviour {

    [SerializeField] private GameObject Level_manager;
	[SerializeField] private GameObject overlay_manager;
	public int thislvl;
	// Use this for initialization
	
	void OnTriggerEnter2D () {


		Overlay overlayManager = overlay_manager.GetComponent<Overlay>();

		overlayManager.WinOverlay();
		overlayManager.win = true; 

	}

	public float Getlvl()
    {
		return thislvl;
    }
}
