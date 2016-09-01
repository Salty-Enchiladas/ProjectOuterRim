using UnityEngine;
using System.Collections;

public class Enemy1Fire : MonoBehaviour
{
    public float fireFreq;        
    public float minFreq;
    public float maxFreq;
    public string laserPoolName;
    public bool canFire;

    float lastDifficultyIncrease;
    float lastShot;

    ObjectPooling laserObject;
    GameObject gameManager;

    void Start()
    {
        laserObject = GameObject.Find(laserPoolName).GetComponent<ObjectPooling>();
        gameManager = GameObject.Find("GameManager");
        switch (transform.name)
        {
            case "Enemy1":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy1FireFreq;
                break;
            case "Enemy2":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy2FireFreq;
                break;
            case "Enemy3":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy3FireFreq;
                break;
            case "Enemy4":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy4FireFreq;
                break;
        }
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

    public void IncreaseDificulty()
    {
        minFreq--;
        maxFreq--;
    }
}
