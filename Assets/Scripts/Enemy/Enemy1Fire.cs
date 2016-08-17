using UnityEngine;
using System.Collections;

public class Enemy1Fire : MonoBehaviour {

    public float fireFreq;        
    public float minFreq;
    public float maxFreq;
    public float difficultyTimer;
    public string laserPoolName;
    public bool canFire;

    float lastDifficultyIncrease;
    float lastShot;

    ObjectPooling laserObject;

    void Start()
    {
        laserObject = GameObject.Find(laserPoolName).GetComponent<ObjectPooling>();
    }

	// Update is called once per frame
	void Update () {
        if (canFire)
        {
            //fireFreq = Random.Range(minFreq, maxFreq);

            if (Time.time > lastShot + fireFreq)
            {
                Fire();
            }

            //if (Time.time > lastDifficultyIncrease + difficultyTimer && minFreq > 1)
            //{
            //    StartCoroutine(IncreaseDificulty(difficultyTimer));
            //}
        }
    }

    void Fire()
    {
        lastShot = Time.time;
        GameObject obj = laserObject.GetPooledObject();

        if (obj == null)
        {
            return;
        }

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }

    IEnumerator IncreaseDificulty(float waitTime)
    {
        lastDifficultyIncrease = Time.time;
        yield return new WaitForSeconds(waitTime);
        minFreq--;
        maxFreq--;
    }
}
