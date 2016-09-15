using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
    public int startingHealth;
    public int currentHealth;
    public GameObject explosion;
    GameObject gameManager;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
		explosion = gameManager.GetComponent<PublicVariableHandler> ().meteorExplosion;
        startingHealth = gameManager.GetComponent<PublicVariableHandler>().playerShieldHealth;
        currentHealth = startingHealth;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy Laser")
        {
            other.gameObject.SetActive(false);
            TookDamage();
        }

        else if (other.tag == "Meteor")
        {
			Instantiate (explosion, transform.position, transform.rotation);
            other.gameObject.SetActive(false);
            ShieldDestroyed();
        }
    }

    void TookDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            player.GetComponent<ActivateShield>().StartMyCoroutine();
            gameObject.SetActive(false);
        }
    }

    void ShieldDestroyed()
    {
        player.GetComponent<ActivateShield>().StartMyCoroutine();
        gameObject.SetActive(false);
    }
}
