using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_objects : MonoBehaviour
{
		[SerializeField] private float Speed;
		private float Ypos;
		public float maxY, minY;
		private bool start = false; 
		public bool directionSwitch = true;
		

		// Use this for initialization
		void Start()
		{
			
		}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			start = true;
		}
			if (start == true)
			{
				Ypos = transform.position.y;
				if (Ypos > maxY)
				{
					directionSwitch = false;

				}
				if (Ypos < minY)
				{
					directionSwitch = true;
				}

				if (directionSwitch)
				{
					transform.Translate(Vector3.up * Time.deltaTime, Space.World);

				}
				else
				{
					transform.Translate(Vector3.down * Time.deltaTime, Space.World);
				}
			}
	}
}

