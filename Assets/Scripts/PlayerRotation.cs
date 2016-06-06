using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour 
{
	
	void Update () 
	{
        transform.Rotate(0f, 0f, Input.GetAxis("Horizontal"));
    }
}
