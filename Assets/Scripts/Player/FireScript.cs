using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

    public GameObject laser;
    public float fireFreq;    
    float lastShot;
    float laserTimer;

    ObjectPooling laserPool;

    void Start()
    {
        laserPool = GameObject.Find("PlayerLasers").GetComponent<ObjectPooling>();
    }
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetButtonDown("Fire1") || (Input.GetAxis("Laser")) != 0) && Time.time > lastShot + fireFreq)      // || (Input.GetAxis("Laser")) != 0)
        {
            Fire();
        }       
    }

    void Fire()
    {
        lastShot = Time.time;

        GameObject obj = laserPool.GetPooledObject();

        if (obj == null)
        {
            return;
        }

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }    
}
