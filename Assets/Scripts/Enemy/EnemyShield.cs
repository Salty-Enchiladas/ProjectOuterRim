using UnityEngine;
using System.Collections;

public class EnemyShield : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public GameObject colliders;
    public GameObject meteorExplosionPrefab;
    GameObject gameManager;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        switch (transform.parent.name)
        {
            case "Enemy3":
                startingHealth = gameManager.GetComponent<PublicVariableHandler>().enemy3ShieldHealth;
                break;
            case "Enemy4":
                startingHealth = gameManager.GetComponent<PublicVariableHandler>().enemy4ShieldHealth;
                break;
        }
        meteorExplosionPrefab = player.GetComponent<StoreVariables>().meteorExplosion;
        currentHealth = startingHealth;
        GetComponentInParent<Enemy1Collision>().enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            other.gameObject.SetActive(false);
            currentHealth--;
            print(currentHealth + "EnemyShieldHealth");
            if (currentHealth <= 0)
            {
                GetComponentInParent<Enemy1Collision>().enabled = true;
                gameObject.SetActive(false);
            }
        }
        else if (other.tag == "Meteor")
        {
            Instantiate(meteorExplosionPrefab, transform.position, transform.rotation);
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}