using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float warpSpeed;
    public float speed;

    private GameObject gameManager;
    private GameObject player;
	Vector3 playerPosition;
    private bool warped;
    private bool inRange;
    WaveHandler waveHandler;
    bool newSpawn;
    EnemyStoreVariables storeVariables;
    Enemy1Fire gun1;
    Enemy1Fire gun2;
    Enemy1Fire gun3;

	void Start ()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        waveHandler = gameManager.GetComponent<WaveHandler>();
		speed = gameManager.GetComponent<PublicVariableHandler> ().enemyAISpeed;
		playerPosition = new Vector3(Random.Range(player.transform.position.x - 300, player.transform.position.x + 300), Random.Range(player.transform.position.y - 300, player.transform.position.y + 300), player.transform.position.z);
        newSpawn = true;
        storeVariables = GetComponent<EnemyStoreVariables>();
        gun1 = storeVariables.gun1.GetComponent<Enemy1Fire>();
        gun2 = storeVariables.gun2.GetComponent<Enemy1Fire>();
        gun3 = storeVariables.gun3.GetComponent<Enemy1Fire>();
    }
	
	void Update ()
    {
        if (transform.tag == "Carrier")
        {
            speed = 500;
        }
        if (Vector3.Distance(transform.position, player.transform.position) > 5000)  //If the AI is furthure than 500 meters from the player.
        {
            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, warpSpeed);     //Warp In
            warped = true;
        }

        if (warped) //If you are warped in.
        {
            print("has warped");
            transform.LookAt(transform);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);    //Move forward
        }

        if (transform.position.z <= -250)   //If you go to far, shut off.
        {
            waveHandler.firstEnemyCount--;
            gameObject.SetActive(false);
        }
    }

    void CheckAIPosition()
    {
    }
}
