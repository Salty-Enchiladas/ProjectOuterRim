using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour 
{
	public float minSpeed;
    public float maxSpeed;
    float speed;
    
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }
	void Update ()
	{
		transform.position += Vector3.back * Time.deltaTime * speed;
	}

}
