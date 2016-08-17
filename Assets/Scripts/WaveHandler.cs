using UnityEngine;
using System.Collections;

public class WaveHandler : MonoBehaviour
{
    //GameSpawner
    public float objSpawnMinX;
    public float objSpawnMaxX;
    public float objSpawnMinY;
    public float objSpawnMaxY;
    public float objSpawnZ;
    public string enemyPoolName;
    public int enemyCount;

    //DifficultyIncrease
    public int spawnCap;
    public int finalSpawnCap;
    public int capIncreaseAmount;
    public float spawnRate;
    public float difficultyTimer;

    GameObject player;
    string[] enemyTypes = { "defender", "interceptor", "fighter" };
    bool increasingDifficulty;
    bool spawning;
    Vector3 objectSpawn;

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
            //Transform spawn = ChooseSpawn();

            if (obj == null)
            {
                yield break;
            }

            objectSpawn = new Vector3(Random.Range(objSpawnMinX, objSpawnMaxX), Random.Range(objSpawnMinY, objSpawnMaxY), player.transform.position.z + objSpawnZ);

            obj.transform.position = objectSpawn;
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true);

            enemyCount++;

            spawning = false;
        }
    }

    GameObject ChooseEnemy(string enemyType)
    {
        GameObject enemy;

        switch (enemyType)
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
            print("Increasing Difficulty!");
            increasingDifficulty = true;
            yield return new WaitForSeconds(difficultyTimer);
            spawnRate = spawnRate - 0.1f;
            if (spawnCap < finalSpawnCap)
            {
                print("THIS IS HAPPENING");
                spawnCap = spawnCap + capIncreaseAmount;
            }
            increasingDifficulty = false;
        }
    }
}