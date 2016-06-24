using UnityEngine;
using System.Collections;

public class TurnOnLaser : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			StartCoroutine(ShutOffLaser());
		}
	}

	IEnumerator ShutOffLaser()
	{
		yield return new WaitForSeconds (0);
		GetComponent<ArcReactorDemoGunController> ().enabled = true;
		transform.parent.GetComponent<LaserLookAt> ().enabled = true;
		yield return new WaitForSeconds (3);
		GetComponent<ArcReactorDemoGunController> ().enabled = false;
		transform.parent.GetComponent<LaserLookAt> ().enabled = false;
	}
}
