using UnityEngine;
using System.Collections;

public class WaveHandler : MonoBehaviour
{
    public float spawnRate;
    public float difficultyTimer;
    public float objSpawnMinX;
    public float objSpawnMaxX;
    public float objSpawnMinY;
    public float objSpawnMaxY;
    public float objSpawnZ;
    public string enemyPoolName;
    public int spawnCap;
    public int enemyCount;
    //public Transform[] spawnPoints;    

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

    //Transform ChooseSpawn()
    //{
    //    Transform spawnPoint;
    //    objectSpawn = new Vector3(Random.Range(player.transform.position.x + objSpawnMinX, player.transform.position.x + objSpawnMaxX), Random.Range(player.transform.position.y + objSpawnMinY, player.transform.position.y + objSpawnMaxY), player.transform.position.z + objSpawnZ);
    //    spawnPoint.position = objectSpawn;

    //    return spawnPoint;
    //}

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