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
    public int enemyCount;

    //DifficultyIncrease
    public int spawnCap;
    public int finalSpawnCap;
    public int capIncreaseAmount;
    public float spawnRate;
    public float difficultyTimer;

    GameObject obj;
    GameObject player;
    bool increasingDifficulty;
    bool spawning;
    Vector3 objectSpawn;

    float deltaTime = 0.0f;

    public ObjectPooling[] enemyObject;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        HandleDifficulty();
    }

    void OnGUI()
    {
        float fps = 1.0f / deltaTime;
        GUILayout.Label("FPS: " + (int)fps);
    }

    IEnumerator Spawn()
    {
        if (!spawning)
        {
            spawning = true;

            yield return new WaitForSeconds(spawnRate);
            ChoosePool();

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
            if (spawnCap < finalSpawnCap)
            {
                spawnCap = spawnCap + capIncreaseAmount;
            }
            increasingDifficulty = false;
        }
    }

    void ChoosePool()
    {
        if (player.GetComponent<PlayerScore>().score < 10000)
        {
            obj = enemyObject[0].GetPooledObject();
        }
        else if (player.GetComponent<PlayerScore>().score >= 10000)
        {
            obj = enemyObject[1].GetPooledObject();
        }
    }
}