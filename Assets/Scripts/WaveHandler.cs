﻿using UnityEngine;
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

    public float minXSpawn;
    public float maxXspawn;
    public float minYSpawn;
    public float maxYSpawn;
    public float zSpawn;

    public int secondEnemySpawnScore;
    public int thirdEnemySpawnScore;
    public int fourthEnemySpawnScore;

    public int firstEnemySpawnCap;
    public int secondEnemySpawnCap;
    public int thirdEnemySpawnCap;
    public int fourthEnemySpawnCap;

    public int firstEnemyFinalCap;
    public int secondEnemyFinalCap;
    public int thirdEnemyFinalCap;
    public int fourthEnemyFinalCap;

    public int firstEnemyCount;
    public int secondEnemyCount;
    public int thirdEnemyCount;
    public int fourthEnemyCount;

    private GameObject player;
    private GameObject currentObject;
    private GameObject debrisField;

    private string poolObject;

    private float lastSpawn;

    private int tempScore;

    private bool increaseDifficulty;

    ObjectPooling firstEnemy;
    ObjectPooling secondEnemy;
    ObjectPooling thirdEnemy;
    ObjectPooling fourthEnemy;

    DebrisField debrisSpawner;

    PublicVariableHandler publicVariableHandler;

    PlayerScore playerScore;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScore = player.GetComponent<PlayerScore>();
        debrisField = GameObject.Find("DebrisField");
        publicVariableHandler = GetComponent<PublicVariableHandler>();
        debrisSpawner = debrisField.GetComponent<DebrisField>();
        firstEnemy = firstEnemyPool.GetComponent<ObjectPooling>();
        secondEnemy = secondEnemyPool.GetComponent<ObjectPooling>();
        thirdEnemy = thirdEnemyPool.GetComponent<ObjectPooling>();
        fourthEnemy = fourthEnemyPool.GetComponent<ObjectPooling>();
        increaseDifficulty = true;
    }

    void Update()
    {
        if (playerScore.score >= 0 && firstEnemyCount <= firstEnemySpawnCap && Time.time > lastSpawn + spawnRate)
        {
            poolObject = "Enemy1";
            Spawn(poolObject);
        }

        if (playerScore.score >= secondEnemySpawnScore && secondEnemyCount <= secondEnemySpawnCap && Time.time > lastSpawn + spawnRate)
        {
            poolObject = "Enemy2";
            Spawn(poolObject);
        }

        if (playerScore.score >= thirdEnemySpawnScore && thirdEnemyCount <= thirdEnemySpawnCap && Time.time > lastSpawn + spawnRate)
        {
            poolObject = "Enemy3";
            Spawn(poolObject);
        }

        if (playerScore.score >= fourthEnemySpawnScore && fourthEnemyCount <= fourthEnemySpawnCap && Time.time > lastSpawn + spawnRate)
        {
            poolObject = "Enemy4";
            Spawn(poolObject);
        }

        if (playerScore.score % difficultyIncreaseScore == 0 && playerScore.score > 0)
        {
            if (increaseDifficulty)
            {
                tempScore = playerScore.score;

                if (spawnRate >= 0)
                    spawnRate = spawnRate - .1f;

                if (debrisSpawner.spawnFrequency >= 0)
                    debrisSpawner.spawnFrequency = debrisSpawner.spawnFrequency - .1f;

                if (firstEnemySpawnCap <= firstEnemyFinalCap && secondEnemySpawnCap <= secondEnemyFinalCap && thirdEnemySpawnCap <= thirdEnemyFinalCap && fourthEnemySpawnCap <= fourthEnemyFinalCap)
                {
                    firstEnemySpawnCap++;
                    secondEnemySpawnCap++;
                    thirdEnemySpawnCap++;
                    fourthEnemySpawnCap++;
                }

                if (publicVariableHandler.enemy4Speed <= 2000)
                {
                    publicVariableHandler.enemy1Speed = publicVariableHandler.enemy1Speed + 100;
                    publicVariableHandler.enemy2Speed = publicVariableHandler.enemy2Speed + 100;
                    publicVariableHandler.enemy3Speed = publicVariableHandler.enemy3Speed + 100;
                    publicVariableHandler.enemy4Speed = publicVariableHandler.enemy4Speed + 100;
                }

                if (publicVariableHandler.enemy1FireFreq >= .2)
                {
                    publicVariableHandler.enemy1FireFreq = publicVariableHandler.enemy1FireFreq - .1f;
                    publicVariableHandler.enemy2FireFreq = publicVariableHandler.enemy2FireFreq - .1f;
                    publicVariableHandler.enemy3FireFreq = publicVariableHandler.enemy3FireFreq - .1f;
                    publicVariableHandler.enemy4FireFreq = publicVariableHandler.enemy4FireFreq - .1f;
                }

                increaseDifficulty = false;
            }
            if (tempScore != playerScore.score)
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

        currentObject.transform.position = new Vector3(player.transform.position.x + Random.Range(minXSpawn, maxXspawn),
        player.transform.position.y + Random.Range(minYSpawn,maxYSpawn), player.transform.position.z + zSpawn);
        currentObject.transform.rotation = transform.rotation;
        currentObject.SetActive(true);
    }
}