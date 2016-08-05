using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour 
{
	
	public float orbitSpeed;
	public float rotationX;	
	public float rotationY;	//must be 1(left) or -1(right)
	public float rotationZ;

	void Update () 
	{
		transform.RotateAround(transform.parent.transform.position, new Vector3(rotationX, rotationY, rotationZ), orbitSpeed * Time.deltaTime);
		transform.LookAt( transform.parent.transform.position );
	}
}
