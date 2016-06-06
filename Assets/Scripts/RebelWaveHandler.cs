using UnityEngine;
using System.Collections;

public class RebelWaveHandler : MonoBehaviour
{
    public GameObject boss;
    bool phase1Started;
    bool phase2Started;
    public float spawnRate;
    public Transform[] spawnPoints;
    public float phase1WaitTime;
    public float phase2WaitTime;
    public float phase3WaitTime;

    public GameObject thrusters;

	// Use this for initialization
	void Start () 
	{
        InvokeRepeating("Spawn", 1f, spawnRate);
        boss.GetComponent<Animator>().SetBool("1st Phase", false);
        boss.GetComponent<Animator>().SetBool("2nd Phase", false);
        boss.GetComponent<Animator>().SetBool("3rd Phase", false);
    }
	
	// Update is called once per frame

	void Update () 
    {
        if(!phase1Started)
        {            
            StartCoroutine(PhaseOne(phase1WaitTime));
        }  
	}

	IEnumerator Thrusters()
    {
        yield return new WaitForSeconds(20);

        thrusters.GetComponent<BossThrusters>().thrustersOn  = true;
            
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
        GameObject obj = EnemyObjectPooling.current.GetPooledObject();
        Transform spawn = ChooseSpawn();

        if (obj == null)
        {
            return;
        }

        obj.transform.position = spawn.position;
        obj.transform.rotation = spawn.rotation;
        obj.SetActive(true);
    }

    Transform ChooseSpawn()
    {
        int i = spawnPoints.Length;
        int spawnPoint = (int)Random.Range(0f, i - 1);

        return spawnPoints[spawnPoint];
    }

    IEnumerator PhaseWait()
    {
        yield return new WaitForSeconds(0f);
    }

    IEnumerator PhaseOne(float waitTime)
    {        
        yield return new WaitForSeconds(waitTime);        
        phase1Started = true;
        boss.GetComponent<Animator>().SetBool("1st Phase", true);
        boss.GetComponent<Animator>().SetBool("2nd Phase", false);
        boss.GetComponent<Animator>().SetBool("3rd Phase", false);
        StartCoroutine(PhaseTwo(phase2WaitTime));
    }

    IEnumerator PhaseTwo(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        phase2Started = true;
        boss.GetComponent<Animator>().SetBool("1st Phase", false);
        boss.GetComponent<Animator>().SetBool("2nd Phase", true);
        boss.GetComponent<Animator>().SetBool("3rd Phase", false);
    }
}
