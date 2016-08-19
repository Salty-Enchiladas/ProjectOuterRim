using UnityEngine;
using System.Collections;

public class PickUpManager : MonoBehaviour
{
    PlayerScore playerScore;

    public GameObject player;
    public GameObject laserPickUp;
    public GameObject missilePickUp;
    public GameObject shieldPickUp;

    public int laserLevel;
    public int missileLevel;
    public int shieldLevel;

    public int spawnAtScore;
    public int spawnAfter;

    public float xMinSpawn;
    public float xMaxSpawn;

    public float yMinSpawn;
    public float yMaxSpawn;

    public float zMinSpawn;
    public float zMaxSpawn;

    public bool leveled;

    Vector3 spawnPoint;
    bool spawning;
    int oldScore;
    float x;
    float y;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScore = player.GetComponent<PlayerScore>();
    }
    void Update()
    {
        if (playerScore.score % spawnAtScore == 0 && playerScore.score != 0 && !spawning && playerScore.score > oldScore)
        {
            spawning = true;
            oldScore = playerScore.score;
            SpawnPickUp();
            spawning = false;
        }
    
    }
    void SpawnPickUp()
    {
        x = Random.Range(0.05f, 0.95f);
        y = Random.Range(0.05f, 0.95f);
        spawnPoint = new Vector3(x, y, 500.0f);
        spawnPoint = Camera.main.ViewportToWorldPoint(spawnPoint);
        Instantiate(laserPickUp, spawnPoint, Quaternion.identity);

        x = Random.Range(0.05f, 0.95f);
        y = Random.Range(0.05f, 0.95f);
        spawnPoint = new Vector3(x, y, 500.0f);
        spawnPoint = Camera.main.ViewportToWorldPoint(spawnPoint);
        Instantiate(missilePickUp, spawnPoint, Quaternion.identity);

        x = Random.Range(0.05f, 0.95f);
        y = Random.Range(0.05f, 0.95f);
        spawnPoint = new Vector3(x, y, 500.0f);
        spawnPoint = Camera.main.ViewportToWorldPoint(spawnPoint);
        Instantiate(shieldPickUp, spawnPoint, Quaternion.identity);
    }

    public void LevelUp(string powerUpType)
    {

        print("YOU LEVELED UP!!!!!!!");
        leveled = true;
        switch (powerUpType)
        {
            case "shield":
                if(shieldLevel < 3)
                    shieldLevel++;
                break;
            case "laser":
                if (laserLevel < 3)
                    laserLevel++;
                break;
            case "missile":
                if (missileLevel < 3)
                    missileLevel++;
                break;
        }
    }

    public void LoseLevel()
    {

        print("YOU LOST A LEVEL!!!!!!!");
        leveled = false;

        if (shieldLevel > 0)
        {
            shieldLevel--;
            switch (shieldLevel)
            {
                case 1:
                    print("Call shield lvl 1 method");
                    break;
                case 2:
                    print("Call shield lvl 2 method");
                    break;
                case 3:
                    print("Call shield lvl 3 method");
                    break;
            }
        }

        if (laserLevel > 0)
        {
            laserLevel--;
            switch (laserLevel)
            {
                case 1:
                    foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                    {
                        go.GetComponent<FireScript>().LaserLevel1(leveled);
                    }
                    print("Call laser lvl 1 method");
                    break;
                case 2:
                    foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                    {
                        go.GetComponent<FireScript>().LaserLevel2(leveled);
                    }
                    print("Call laser lvl 2 method");
                    break;
                case 3:
                    foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                    {
                        go.GetComponent<FireScript>().LaserLevel3(leveled);
                    }
                    print("Call laser lvl 3 method");
                    break;
            }
        }

        if (missileLevel > 0)
        {
            missileLevel--;
            switch (missileLevel)
            {
                case 1:
                    player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissileLevel1(leveled);
                    print("Call shield lvl 1 method");
                    break;
                case 2:
                    player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissileLevel2(leveled);
                    print("Call shield lvl 2 method");
                    break;
                case 3:
                    player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissileLevel3(leveled);
                    print("Call shield lvl 3 method");
                    break;
            }
        }
    }
}
