using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

    public GameObject laser;
    public float fireFreq;
    public int overheatCap;
    public int heatLevel;

    float lastShot;
    float laserTimer;

    bool overheated;
    ObjectPooling laserPool;
    GameObject gameManager;
    AchievementManager achievementManager;

    void Start()
    {
        laserPool = GameObject.Find("PlayerLasers").GetComponent<ObjectPooling>();
        gameManager = GameObject.Find("GameManager");
        achievementManager = gameManager.GetComponent<AchievementManager>();
        fireFreq = 0.25f;
        overheatCap = 50;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if ((Input.GetButton("Fire1") || (Input.GetAxis("Laser")) != 0) && Time.time > lastShot + fireFreq && overheated == false)
        {
            Fire();
        }
        if (heatLevel >= overheatCap)
        {
            Cooldown();
        }

    }

    void Fire()
    {
        heatLevel++;
        print(heatLevel);
        achievementManager.LaserShot();
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

    void Cooldown()
    {
        overheated = true;
        //Do the ui stuff here, then set it to false
    }
}
