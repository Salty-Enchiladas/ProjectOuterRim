using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

    public GameObject laser;
    public float fireFreq;    
    float lastShot;
    float laserTimer;    
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetButton("Fire1") || (Input.GetAxis("Laser")) != 0) && Time.time > lastShot + fireFreq)
        {
            Fire();
        }       
    }

    void Fire()
    {
        lastShot = Time.time;

        GameObject obj = PlayerObjectPooling.current.GetPooledObject();

        if (obj == null)
        {
            return;
        }

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }    
}
