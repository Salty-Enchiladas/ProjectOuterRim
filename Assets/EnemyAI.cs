using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float warpSpeed;
    public float speed;

    private GameObject gameManager;
    private GameObject player;
    private bool warped;

    WaveHandler waveHandler;

	void Start ()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        waveHandler = gameManager.GetComponent<WaveHandler>();
	}
	
	void Update ()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 5000)  //If the AI is furthure than 500 meters from the player.
        {
            transform.LookAt(player.transform);                                                                 
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, warpSpeed);     //Warp In
            warped = true;
        }

        if (warped) //If you are warped in.
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);    //Move forward
        }

        if (transform.position.z <= -300)   //If you go to far, shut off.
        {
            waveHandler.firstEnemyCount--;
            gameObject.SetActive(false);
        }
	}

    void CheckAIPosition()
    {
    }
}
