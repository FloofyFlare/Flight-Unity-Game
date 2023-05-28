using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating_Enemy : MonoBehaviour {
	[SerializeField] private float spinSpeed;
	[SerializeField] private int rotationSelect;
	public Transform objectInQuestion;
	private bool directionSwitch = true;
	[SerializeField] private float timeToSwitch;
	public bool start = false;
	// Use this for initialization

	bool coroutine = true;
	// Update is called once per frame
	void Update() {
		if (Input.GetMouseButtonDown(0))
		{
			start = true;
			
			if (coroutine)
            {
				StartCoroutine(SpinDirectionController());
				coroutine = false;
			}
			
			
		}
		if (start == true)
			{
				if (rotationSelect == 0)
				{
					transform.Rotate(new Vector3(0, 0, spinSpeed) * Time.deltaTime);
				}
				else if (rotationSelect == 1)
				{

					if (directionSwitch)
					{
						transform.Rotate(new Vector3(0, 0, spinSpeed) * Time.deltaTime);
					}
					else
					{
						transform.Rotate(new Vector3(0, 0, -spinSpeed) * Time.deltaTime);
					}


				}
		}
	}
	IEnumerator SpinDirectionController()
	{

		while (true)
		{
			directionSwitch = !directionSwitch;

			yield return new WaitForSeconds(timeToSwitch);
		}
	}
}
