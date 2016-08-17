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
        if(shieldLevel > 0)
            shieldLevel--;
        if(laserLevel > 0)
            laserLevel--;
        if (missileLevel > 0)
            missileLevel--;
    }
}
