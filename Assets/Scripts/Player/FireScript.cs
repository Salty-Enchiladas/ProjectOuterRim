using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

    public GameObject laser;
    float fireFreq;
    public int overheatCap;
    public int heatLevel;

    float lastShot;
    float laserTimer;

    bool overheated;
    ObjectPooling laserPool;
    GameObject gameManager;
    AchievementManager achievementManager;
    GameObject player;

    void Start()
    {
        laserPool = GameObject.Find("PlayerLasers").GetComponent<ObjectPooling>();
        gameManager = GameObject.Find("GameManager");
        achievementManager = gameManager.GetComponent<AchievementManager>();
        player = GameObject.Find("Player");
        fireFreq = gameManager.GetComponent<PublicVariableHandler>().playerShootingFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButton("Fire1") || (Input.GetAxis("Laser")) != 0) && Time.time > lastShot + fireFreq) // && overheated == false
        {
            Fire();
        }
        //if (heatLevel >= overheatCap)
        //{
        //    Cooldown();
        //}

    }

    void Fire()
    {
        //heatLevel++;
        //print(heatLevel);
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

    //void Cooldown()
    //{
    //    overheated = true;
    //    //Do the ui stuff here, then set it to false
    //}

    public void LaserLevel1(bool levelUp)
    {
        if (levelUp)
        {
            fireFreq = fireFreq / 2;
            // overheatCap = overheatCap * 2;
        }
        else if (!levelUp)
        {
            fireFreq = fireFreq * 2;
            // overheatCap = overheatCap / 2;
        }
    }

    public void LaserLevel2(bool levelUp)
    {
        if (levelUp)
            fireFreq = fireFreq / 2;
        else if (!levelUp)
            fireFreq = fireFreq * 2;
    }

    public void LaserLevel3(bool levelUp)
    {
        foreach (GameObject go in player.GetComponent<StoreVariables>().upgradeWeapons)
        {
            go.SetActive(levelUp);
        }
    }
}
