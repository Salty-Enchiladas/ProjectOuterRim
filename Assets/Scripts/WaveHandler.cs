using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveHandler : MonoBehaviour
{
    public float spawnRate;
    public float difficultyTimer;
    public int spawnCap;
    public int enemyCount;
    public string enemyPoolName;
    public Transform[] spawnPoints;    

    GameObject player;
    string[] enemyTypes = { "defender", "interceptor", "fighter" };
    bool increasingDifficulty;
    bool spawning;

    ObjectPooling enemyObject;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        enemyObject = GameObject.Find(enemyPoolName).GetComponent<ObjectPooling>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleDifficulty();
    }

    bool CheckWave(GameObject[] wave)
    {
        bool result = false;

        int counter = 0;
        foreach (GameObject enemy in wave)
        {
            if (!enemy.activeInHierarchy)
            {
                counter++;
                if (counter == wave.Length)
                {
                    result = true;
                }
            }
        }
        return result;
    }

    IEnumerator Spawn()
    {
        if (!spawning)
        {
            spawning = true;

            yield return new WaitForSeconds(spawnRate);

            GameObject obj = enemyObject.GetPooledObject();     //ChooseEnemy("interceptor")    enemyObject.GetPooledObject()       enemyTypes[(int)Random.Range(0, 3)]
            Transform spawn = ChooseSpawn();

            if (obj == null)
            {
                yield break;
            }

            obj.transform.position = spawn.position;
            obj.transform.rotation = spawn.rotation;
            obj.SetActive(true);

            spawning = false;
        }
    }

    //GameObject ChooseEnemy(string enemyType)
    //{
    //    GameObject enemy;

    //    switch (enemyType)
    //    {
    //        case "defender":
    //            enemy = EnemyDefenderPooling.current.GetPooledObject();
    //            break;
    //        case "interceptor":
    //            enemy = EnemyInterceptorPooling.current.GetPooledObject();
    //            break;
    //        case "fighter":
    //            enemy = EnemyFighterPooling.current.GetPooledObject();
    //            break;
    //        default:
    //            enemy = null;
    //            break;
    //    }

    //    return enemy;
    //}

    Transform ChooseSpawn()
    {
        int i = spawnPoints.Length;
        int spawnPoint = (int)Random.Range(0f, i - 1);

        return spawnPoints[spawnPoint];
    }

    void HandleDifficulty()
    {
        if (enemyCount != spawnCap)
        {
            StartCoroutine(Spawn());
            StartCoroutine(IncreaseSpawning());
        }
    }

    IEnumerator IncreaseSpawning()
    {
        if (!increasingDifficulty && spawnRate > 0.1f)
        {
            increasingDifficulty = true;
            yield return new WaitForSeconds(difficultyTimer);
            spawnRate = spawnRate - 0.1f;
            increasingDifficulty = false;
        }
    }
}