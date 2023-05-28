using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	[SerializeField]
	private float xMax;
	[SerializeField]
	private float yMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMin;
	[SerializeField]
	private bool cameraclamp;

	//The camera's transform
	private Transform cameraTransform;
	public Transform player;
	public float cameraAdjustment;
	// Use this for initialization
	void Start () {
		// The Cameras transform is the same as the players
		cameraTransform = player;

	}
	void Update()
    {
		
    }
	// Update is called once per frame
	void LateUpdate () {
		// +6  is added as to center to player better on the screen
		if (cameraclamp)
        {
			transform.position = new Vector3(Mathf.Clamp(cameraTransform.position.x, xMin, xMax) + cameraAdjustment, Mathf.Clamp(cameraTransform.position.y, yMin, yMax), -10);
		}
		if (!cameraclamp)
		{
			transform.position = new Vector3(cameraTransform.position.x + cameraAdjustment, Mathf.Clamp(cameraTransform.position.y, yMin, yMax), -10);
		}
	}
}
