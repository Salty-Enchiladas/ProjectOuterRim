using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

    public GameObject laser;
    int heatLevel;
    public int heatCap;
    public int heatIncreaseAmount;
    float fireFreq;

    float lastShot;
    float laserTimer;
    public float heatResetTimer;
    float lastReset;

    bool overHeated;
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
        heatCap = gameManager.GetComponent<PublicVariableHandler>().playerLaserHeatCap;
        heatIncreaseAmount = gameManager.GetComponent<PublicVariableHandler>().playerLaserHeatIncreaseAmount;
        heatResetTimer = gameManager.GetComponent<PublicVariableHandler>().laserHeatLossAfterSeconds;
    }
    
    void Update()
    {
        if ((Input.GetButton("Fire1") || (Input.GetAxis("Laser")) != 0) && Time.time > lastShot + fireFreq && !overHeated)
        {
            Fire();
        }
        else if(Time.time > lastReset + heatResetTimer && heatLevel > 0)
        {
            lastReset = Time.time;
            heatLevel = heatLevel - heatIncreaseAmount;
        }
        print("Laser heatlevel is at "+ heatLevel);
    }

    void Fire()
    {
        if (heatLevel < heatCap)
        {
            heatLevel = heatLevel + heatIncreaseAmount;
        }
        else if (heatLevel >= heatCap)
        {
            overHeated = true;
            print("Laser is overheating");
            StartCoroutine(OverHeating());
        }
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

    IEnumerator OverHeating()
    {
        print("laser cooling down");
        heatLevel = heatLevel - 10;
        yield return new WaitForSeconds(.3f);
        heatLevel = heatLevel - 10;
        yield return new WaitForSeconds(.3f);
        heatLevel = heatLevel - 10;
        yield return new WaitForSeconds(.3f);
        heatLevel = heatLevel - 10;
        yield return new WaitForSeconds(.3f);
        heatLevel = heatLevel - 10;
        yield return new WaitForSeconds(.3f);
        heatLevel = heatLevel - 10;
        yield return new WaitForSeconds(.3f);
        heatLevel = heatLevel - 10;
        yield return new WaitForSeconds(.3f);
        heatLevel = heatLevel - 10;
        yield return new WaitForSeconds(.3f);
        heatLevel = heatLevel - 10;
        yield return new WaitForSeconds(.3f);
        heatLevel = heatLevel - 10;
        yield return new WaitForSeconds(.3f);
        print("Laser is cooled and ready for action!");
        overHeated = false;
    }
    public void LaserLevel1(bool levelUp)
    {
        if (levelUp)
        {
            fireFreq = fireFreq / 2;
        }
        else if (!levelUp)
        {
            fireFreq = fireFreq * 2;
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
