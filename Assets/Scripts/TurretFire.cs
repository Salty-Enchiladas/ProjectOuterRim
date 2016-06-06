using UnityEngine;
using System.Collections;

public class TurretFire : MonoBehaviour 
{
	
	public float fireFreq;
	public GameObject enemyLaser;
	float lastShot;
	public Transform player;

	void Update()
	{
		transform.LookAt (player);
	}
	
	public void FireFreq()
	{
		fireFreq = Random.Range (4f, 8f);
		if (Time.time > lastShot + fireFreq)
		{
			Fire();
		}
	}

	
	void Fire()
	{
		lastShot = Time.time;
		Instantiate(enemyLaser, transform.position, transform.rotation);
	}
}
