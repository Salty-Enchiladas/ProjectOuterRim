using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
    //public int startingHealth;
    //public int currentHealth;
    public GameObject explosion;
    GameObject gameManager;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
		explosion = gameManager.GetComponent<PublicVariableHandler> ().meteorExplosion;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy Laser")
        {
            other.gameObject.SetActive(false);
        }

        else if (other.tag == "Meteor")
        {
			Instantiate (explosion, transform.position, transform.rotation);
            other.gameObject.SetActive(false);
        }
    }
}
