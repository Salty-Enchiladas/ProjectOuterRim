using UnityEngine;
using System.Collections;

public class LaserMovement : MonoBehaviour {

    public float laserSpeed;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, laserSpeed * Time.deltaTime);

        if (transform.position.z > 60 || transform.position.z < -50)
        {
            gameObject.SetActive(false);
        }
    }
}
