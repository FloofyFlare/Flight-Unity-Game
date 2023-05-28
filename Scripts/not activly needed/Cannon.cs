using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
	public float xdustadjustment;
	public float ydustadjustment;
	public GameObject fire;
	private bool alive = true;
	public short damage;
	public float health = 5;
	// Use this for initialization
	void Start()
	{
		StartCoroutine(Fire());
	}

	// Update is called once per frame
	void Update()
	{

	}
	public float GetDamage()
	{
		return damage;
	}
	//creates dust every 0.5 second
	IEnumerator Fire()
	{

		while (alive == true)
		{


			Debug.Log("fire creation");

			Instantiate(fire, (transform.position - new Vector3(xdustadjustment, ydustadjustment)), Quaternion.identity);

			yield return new WaitForSeconds(1.5f);
		}
	}
	void OnTriggerEnter2D(Collider2D collider)
	{

		Projectile projectile = collider.gameObject.GetComponent<Projectile>();
		if (projectile)
		{

			health -= projectile.GetDamage();
			Debug.Log(health);
			if (health < 0)
			{

				Debug.Log("here");
				projectile.Death();
				Destroy(gameObject);
			}
		}
	}
}
