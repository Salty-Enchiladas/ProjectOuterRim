using UnityEngine;
using System.Collections;

public class WaveHandler : MonoBehaviour
{
    public GameObject imperialFleet;
    public float spawnRate;
    public Transform[] spawnPoints;
    public float difficultyTimer;

    GameObject player;
    string[] enemyTypes = { "defender", "interceptor", "fighter" };   

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", 1f, spawnRate);
        InvokeRepeating("IncreaseDifficulty", 15f, difficultyTimer);       
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

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

    void Spawn()
    {
        GameObject obj = ChooseEnemy("interceptor");     //enemyTypes[(int)Random.Range(0, 3)]
        Transform spawn = ChooseSpawn();        

        if (obj == null)
        {
            return;
        }

        obj.transform.position = spawn.position;
        obj.transform.rotation = spawn.rotation;
        obj.SetActive(true);
    }

    GameObject ChooseEnemy(string enemyType)
    {
        GameObject enemy;

        switch(enemyType)
        {
            case "defender":
                enemy = EnemyDefenderPooling.current.GetPooledObject();
                break;
            case "interceptor":
                enemy = EnemyInterceptorPooling.current.GetPooledObject();
                break;
            case "fighter":
                enemy = EnemyFighterPooling.current.GetPooledObject();
                break;
            default:
                enemy = null;
                break;
        }

        return enemy;
    }

    Transform ChooseSpawn()
    {
        int i = spawnPoints.Length;
        int spawnPoint = (int)Random.Range(0f, i - 1);

        return spawnPoints[spawnPoint];
    }

    void IncreaseDifficulty()
    {
        spawnRate = spawnRate - 0.1f;
    }
}