using UnityEngine;
using System.Collections;

public class PickUpManager : MonoBehaviour
{
    public GameObject pickUp;
    public int spawnAfter;

    public float xMinSpawn;
    public float xMaxSpawn;

    public float yMinSpawn;
    public float yMaxSpawn;

    public float zMinSpawn;
    public float zMaxSpawn;
    
    Vector3 spawnPoint;
    bool spawning;
    
    void Update()
    {
        StartMyCoroutine();
    }

    void StartMyCoroutine()
    {
        StartCoroutine(SpawnPickUp());
    }

    IEnumerator SpawnPickUp ()
    {
        if (!spawning)
        {
            spawning = true;
            yield return new WaitForSeconds(spawnAfter);
            float x = Random.Range(0.05f, 0.95f);
            float y = Random.Range(0.05f, 0.95f);
            spawnPoint = new Vector3(x, y, 500.0f);
            spawnPoint = Camera.main.ViewportToWorldPoint(spawnPoint);
            Instantiate(pickUp, spawnPoint, Quaternion.identity);
            spawning = false;
        }
    }
}
