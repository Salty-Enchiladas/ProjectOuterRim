using UnityEngine;
using System.Collections;

public class EnemyShield : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public GameObject meteorExplosionPrefab;
    GameObject gameManager;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager"); 
        meteorExplosionPrefab = player.GetComponent<StoreVariables>().meteorExplosion;
        currentHealth = startingHealth;
        switch (transform.name)
        {
            case "Enemy3":
                startingHealth = gameManager.GetComponent<PublicVariableHandler>().enemy3ShieldHealth;
                break;
            case "Enemy4":
                startingHealth = gameManager.GetComponent<PublicVariableHandler>().enemy4ShieldHealth;
                break;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            other.gameObject.SetActive(false);
            currentHealth--;
            if (currentHealth == 0)
            {
                gameObject.SetActive(false);
            }
        }

        else if (other.tag == "Meteor")
        {
            gameObject.SetActive(false);
            Instantiate(meteorExplosionPrefab, transform.position, transform.rotation);
            other.gameObject.SetActive(false);
        }
    }
}