using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{

	public GameObject[] LevelPiece;
	private int randInt;
	public int IntMin;
	public int IntMax;
	public float waitTime;
	public GameObject startGameBool;
	private bool startGameLevel;
	public GameObject overlayController;
	public float waitTimeDecrease;
	

	// Use this for initialization
	void Start()
	{
		StartCoroutine(LevelBuilder());
		
	}

	void Update()
    {
		Player player = startGameBool.GetComponent<Player>();

		startGameLevel = player.startGame;

		Overlay overlay = overlayController.GetComponent<Overlay>();
	}

	IEnumerator LevelBuilder()
	{
		

		while (true)
		{
			Overlay overlay = overlayController.GetComponent<Overlay>();

			if (startGameLevel)
            {
				randInt = Random.Range(IntMin, IntMax);
				Instantiate(LevelPiece[randInt], new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
				Debug.Log(waitTime);
			}
			if (waitTime > 0.2f && startGameLevel)
            {
				waitTime = waitTime - waitTimeDecrease;
            }
			
			yield return new WaitForSeconds(waitTime);
		}
	}
}