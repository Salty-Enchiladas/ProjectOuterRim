using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
    //public int startingHealth;
    //public int currentHealth;
    //public GameObject meteorExplosionPrefab;
    GameObject gameManager;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy Laser")
        {
            other.gameObject.SetActive(false);
        }

        else if (other.tag == "Meteor")
        {
            other.gameObject.SetActive(false);
        }
    }
}
