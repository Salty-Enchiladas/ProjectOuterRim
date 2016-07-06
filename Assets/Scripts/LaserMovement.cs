using UnityEngine;
using System.Collections;

public class LaserMovement : MonoBehaviour {

    public float laserSpeed;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, laserSpeed * Time.deltaTime);

        if (Time.time >= 5f) //transform.position.z > 1000|| transform.position.z < -1000
        {
            gameObject.SetActive(false);
        }
    }
}
