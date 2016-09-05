using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

    public GameObject laser;
    [HideInInspector]
    public float heatLevel;
    public float heatCap;
    public float heatIncreaseAmount;
    float fireFreq;

    float lastShot;
    float laserTimer;
    public float heatResetTimer;
    float lastReset;

    bool overHeated;
    ObjectPooling laserPool;
    GameObject gameManager;
    AchievementManager achievementManager;
    PublicVariableHandler publicVariableHandler;
    GameObject player;
    GameObject laserLevel1Bar;
    GameObject laserLevel2Bar;
    GameObject laserLevel3Bar;

    void Start()
    {
        laserPool = GameObject.Find("PlayerLasers").GetComponent<ObjectPooling>();
        gameManager = GameObject.Find("GameManager");
        publicVariableHandler = gameManager. GetComponent<PublicVariableHandler>();
        achievementManager = gameManager.GetComponent<AchievementManager>();
        player = GameObject.Find("Player");
        fireFreq = publicVariableHandler.playerShootingFrequency;
        heatCap = publicVariableHandler.playerLaserHeatCap;
        heatIncreaseAmount = publicVariableHandler.playerLaserHeatIncreaseAmount;
        heatResetTimer = publicVariableHandler.laserHeatLossAfterSeconds;
        laserLevel1Bar = publicVariableHandler.laserLevel1Bar;
        laserLevel2Bar = publicVariableHandler.laserLevel2Bar;
        laserLevel3Bar = publicVariableHandler.laserLevel3Bar;
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
        //print("Laser heatlevel is at "+ heatLevel);
    }

    void Fire()
    {
        if (heatLevel < heatCap)
        {
            heatLevel = heatLevel + heatIncreaseAmount;
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
        else if (heatLevel >= heatCap)
        {
            overHeated = true;
            //print("Laser is overheating");
            StartCoroutine(OverHeating());
        }        
    }

    IEnumerator OverHeating()
    {
        //print("laser cooling down");
        for(int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(.3f);
            heatLevel = heatLevel - .05f;            
        }        
        
        //print("Laser is cooled and ready for action!");
        overHeated = false;
    }
    public void LaserLevel1(bool levelUp)
    {
        if (levelUp)
        {
            laserLevel1Bar.SetActive(levelUp);
            heatIncreaseAmount = heatIncreaseAmount / 2;
        }
        else if (!levelUp)
        {
            heatIncreaseAmount = heatIncreaseAmount * 2;
        }
    }

    public void LaserLevel2(bool levelUp)
    {
        if (levelUp)
        {
            laserLevel2Bar.SetActive(levelUp);
            fireFreq = fireFreq / 2;
        }
        else if (!levelUp)
        {
            fireFreq = fireFreq * 2;
        }
    }

    public void LaserLevel3(bool levelUp)
    {
        if (levelUp)
        {
            laserLevel3Bar.SetActive(levelUp);
            foreach (GameObject go in player.GetComponent<StoreVariables>().upgradeWeapons)
            {
                go.SetActive(levelUp);
            }
        }
        else if (!levelUp)
        {
              foreach (GameObject go in player.GetComponent<StoreVariables>().upgradeWeapons)
            {
                go.SetActive(levelUp);
            }
        }
    }
}
