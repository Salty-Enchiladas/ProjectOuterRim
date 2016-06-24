using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour 
{
	public float speed;

	void Start()
	{
		StartCoroutine (CancelAnim ());
	}
	void Update ()
	{
		transform.position += Vector3.back * Time.deltaTime * speed;
	}
	IEnumerator CancelAnim()
	{
		yield return new WaitForSeconds (1);
		GetComponent<Animator> ().enabled = false;
	}
}
