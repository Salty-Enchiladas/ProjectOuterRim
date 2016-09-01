using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destructable : MonoBehaviour
{
    GameObject explosion;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        explosion = player.GetComponent<StoreVariables>().meteorExplosion;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy" || other.tag == "Enemy Laser" || other.tag == "Laser")
        {
            gameObject.SetActive(false);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
