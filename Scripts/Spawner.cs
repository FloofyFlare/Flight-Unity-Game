using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject Enemy;
	public float xPos;
	public float xPosMin;
	public float xPosMax;
	public float yPos;
	public float waitTime;
	public bool spawnerSwitch = true;
	// Use this for initialization
	void Start () {
		StartCoroutine(EnemySpawner());
	}
	
	IEnumerator EnemySpawner()
    {
		while (spawnerSwitch == true)
        {
			xPos = Random.Range(xPosMin, xPosMax);
			Instantiate(Enemy, new Vector2(xPos, yPos), Quaternion.identity);
			yield return new WaitForSeconds(waitTime);
		}
    }
}
