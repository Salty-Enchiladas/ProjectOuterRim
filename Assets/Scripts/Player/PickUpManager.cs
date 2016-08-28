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

    public float zSpawnMin;
    public float zSpawnMax;

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
        //x = Random.Range(0.05f, 0.95f);
        //y = Random.Range(0.05f, 0.95f);
        //spawnPoint = new Vector3(x, y, zSpawn);
        //spawnPoint = Camera.main.ViewportToWorldPoint(spawnPoint);
        spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
            Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
            Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
        Instantiate(laserPickUp, spawnPoint, Quaternion.identity);

        //x = Random.Range(0.05f, 0.95f);
        //y = Random.Range(0.05f, 0.95f);
        //spawnPoint = new Vector3(x, y, zSpawn);
        //spawnPoint = Camera.main.ViewportToWorldPoint(spawnPoint);
        spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
            Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
            Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
        Instantiate(missilePickUp, spawnPoint, Quaternion.identity);

        //x = Random.Range(0.05f, 0.95f);
        //y = Random.Range(0.05f, 0.95f);
        //spawnPoint = new Vector3(x, y, zSpawn);
        //spawnPoint = Camera.main.ViewportToWorldPoint(spawnPoint);
        spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
            Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
            Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
        Instantiate(shieldPickUp, spawnPoint, Quaternion.identity);
    }

    public void LevelUp(string powerUpType)
    {

        print("YOU LEVELED UP!!!!!!!");
        leveled = true;
        switch (powerUpType)
        {
            case "shield":
                if (shieldLevel < 3)
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

        //if (shieldLevel > 0)
        //{
        //    shieldLevel--;
        //    switch (shieldLevel)
        //    {
        //        case 0:
        //            print("All shield upgrades lost");
        //            break;
        //        case 1:
        //            print("You lost a shield level and are now level 1");
        //            break;
        //        case 2:
        //            print("You lost a shield level and are now level 2");
        //            break;
        //    }
        //}

        if (laserLevel > 0)
        {
            laserLevel--;
            switch (laserLevel)
            {
                case 0:
                    print("All laser upgrades lost");
                    break;
                case 1:
                    foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                    {
                        go.GetComponent<FireScript>().LaserLevel1(leveled);
                    }
                    print("You lost a laser level and are now level 1");
                    break;
                case 2:
                    foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                    {
                        go.GetComponent<FireScript>().LaserLevel2(leveled);
                    }
                    print("You lost a laser level and are now level 2");
                    break;
            }
        }

        if (missileLevel > 0)
        {
            print("You lost 1 missile level!!");
            missileLevel--;
            switch (missileLevel)
            {
                case 0:
                    print("All missile upgrades lost");
                    break;
                case 1:
                    player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissileLevel1(leveled);
                    print("You lost a missile level and are now level 1");
                    break;
                case 2:
                    player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissileLevel2(leveled);
                    print("You lost a missile level and are now level 2");
                    break;
            }
        }
    }
}