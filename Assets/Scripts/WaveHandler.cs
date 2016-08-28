using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveHandler : MonoBehaviour
{
    public GameObject firstEnemyPool;
    public GameObject secondEnemyPool;
    public GameObject thirdEnemyPool;
    public GameObject fourthEnemyPool;

    public float spawnRate;
    public int difficultyIncreaseScore;

    public int secondEnemySpawnScore;
    public int thirdEnemySpawnScore;
    public int fourthEnemySpawnScore;

    public int firstEnemySpawnCap;
    public int secondEnemySpawnCap;
    public int thirdEnemySpawnCap;
    public int fourthEnemySpawnCap;

    public int firstEnemyCount;
    public int secondEnemyCount;
    public int thirdEnemyCount;
    public int fourthEnemyCount;

    private GameObject player;
    private GameObject currentObject;
    private string poolObject;

    private float lastSpawn;
    private int score;
    private int tempScore;
    private bool increaseDifficulty;

    ObjectPooling firstEnemy;
    ObjectPooling secondEnemy;
    ObjectPooling thirdEnemy;
    ObjectPooling fourthEnemy;

    void Start()
    {
        player = GameObject.Find("Player");
        firstEnemy = firstEnemyPool.GetComponent<ObjectPooling>();
        secondEnemy = secondEnemyPool.GetComponent<ObjectPooling>();
        thirdEnemy = thirdEnemyPool.GetComponent<ObjectPooling>();
        fourthEnemy = fourthEnemyPool.GetComponent<ObjectPooling>();
        increaseDifficulty = true;
    }

    void Update()
    {
        score = player.GetComponent<PlayerScore>().score;

        if (score >= 0 && firstEnemyCount <= firstEnemySpawnCap && Time.time > lastSpawn + spawnRate)
        {
            poolObject = "Enemy1";
            Spawn(poolObject);
        }
        if (score >= secondEnemySpawnScore && secondEnemyCount <= secondEnemySpawnCap && Time.time > lastSpawn + spawnRate)
        {
            poolObject = "Enemy2";
            Spawn(poolObject);
        }
        if (score >= thirdEnemySpawnScore && thirdEnemyCount <= thirdEnemySpawnCap && Time.time > lastSpawn + spawnRate)
        {
            poolObject = "Enemy3";
            Spawn(poolObject);
        }
        if (score >= fourthEnemySpawnScore && fourthEnemyCount <= fourthEnemySpawnCap && Time.time > lastSpawn + spawnRate)
        {
            poolObject = "Enemy4";
            Spawn(poolObject);
        }

        if (score % difficultyIncreaseScore == 0 && score > 0)
        {

            if (increaseDifficulty)
            {
                tempScore = score;

                if (spawnRate >= 0)
                    spawnRate = spawnRate - .1f;
                if (firstEnemySpawnCap <= 10 && secondEnemySpawnCap <= 10 && thirdEnemySpawnCap <= 10 && fourthEnemySpawnCap <= 10)
                {
                    firstEnemySpawnCap++;
                    secondEnemySpawnCap++;
                    thirdEnemySpawnCap++;
                    fourthEnemySpawnCap++;
                }
                increaseDifficulty = false;
            }
            if (tempScore != score)
            {
                increaseDifficulty = true;
            }
        }
    }

    void Spawn(string objectPool)
    {
        switch (objectPool)
        {
            case "Enemy1":
                firstEnemyCount++;
                currentObject = firstEnemy.GetPooledObject();
                currentObject.name = objectPool;
                break;
            case "Enemy2":
                secondEnemyCount++;
                currentObject = secondEnemy.GetPooledObject();
                currentObject.name = objectPool;
                break;
            case "Enemy3":
                thirdEnemyCount++;
                currentObject = thirdEnemy.GetPooledObject();
                currentObject.name = objectPool;
                break;
            case "Enemy4":
                fourthEnemyCount++;
                currentObject = fourthEnemy.GetPooledObject();
                currentObject.name = objectPool;
                break;
        }

        lastSpawn = Time.time;
        if (currentObject == null)
        {
            return;
        }

        currentObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 5000);
        currentObject.transform.rotation = transform.rotation;
        currentObject.SetActive(true);
    }
}