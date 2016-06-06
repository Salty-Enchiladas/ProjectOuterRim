using UnityEngine;
using System.Collections;

public class TriggerTurretFire : MonoBehaviour 
{
	private GameObject turretLaser;

	void OnTriggerEnter(Collider other)
	{
		GetComponent<TurretFire> ().FireFreq ();
	}
}
