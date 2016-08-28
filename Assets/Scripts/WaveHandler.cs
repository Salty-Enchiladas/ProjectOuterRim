using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveHandler : MonoBehaviour
{
    //GameSpawner
    public float objSpawnMinX;
    public float objSpawnMaxX;
    public float objSpawnMinY;
    public float objSpawnMaxY;
    public float objSpawnZ;

    //Enemy variables
    public int enemy1Count;
    public int enemy2Count;
    public int enemy3Count;
    public int enemy4Count;

    public int e1SpawnCap;
    public int e2SpawnCap;
    public int e3SpawnCap;
    public int e4SpawnCap;

    public int e1IncSpawnAtScore;
    public int e2IncSpawnAtScore;
    public int e3IncSpawnAtScore;
    public int e4IncSpawnAtScore;

    public List<GameObject> obj;
    GameObject player;
    bool increasingDifficulty;
    bool spawning;
    Vector3 objectSpawn;
    PlayerScore playerScore;
    public ObjectPooling[] enemyObject;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        playerScore = player.GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy1Count < e1SpawnCap)
        {
            print("Spawning E1");
            obj.Add (enemyObject[0].GetPooledObject());
            obj[0].name = "Enemy1";
            Spawn();
        }
        if (playerScore.score >= e2IncSpawnAtScore && enemy2Count < e2SpawnCap)
        {
            print("Spawning E2");
            obj.Add(enemyObject[1].GetPooledObject());
            obj[1].name = "Enemy2";
            Spawn();
        }
        if (playerScore.score >= e3IncSpawnAtScore && enemy3Count < e3SpawnCap)
        {
            print("Spawning E3");
            obj.Add(enemyObject[2].GetPooledObject());
            obj[2].name = "Enemy3";
            Spawn();
        }
        if (playerScore.score >= e4IncSpawnAtScore && enemy4Count < e4SpawnCap)
        {
            print("Spawning E4");
            obj.Add(enemyObject[3].GetPooledObject());
            obj[3].name = "Enemy4";
            Spawn();
        }

    }
    void Spawn()
    {
        print("Your coroutine has started");
        if (!spawning)
        {
            print("Your bool for spawning is set to " + spawning + " this means you are not spawning already so you will spawn " + obj);
            spawning = true;

            GameObject newObj;
            newObj = obj[Random.Range(0, obj.Count)];
            if (newObj == null)
            {
                return;
            }

            objectSpawn = new Vector3(Random.Range(objSpawnMinX, objSpawnMaxX), Random.Range(objSpawnMinY, objSpawnMaxY), player.transform.position.z + objSpawnZ);

            newObj.transform.position = objectSpawn;
            newObj.transform.rotation = Quaternion.identity;
            newObj.SetActive(true);
            switch (newObj.name)
            {
                case "Enemy1":
                    print("hi");
                    enemy1Count++;
                    break;
                case "Enemy2":
                    enemy2Count++;
                    break;
                case "Enemy3":
                    enemy3Count++;
                    break;
                case "Enemy4":
                    enemy4Count++;
                    break;

              spawning = false;
            }
        }
    }
}