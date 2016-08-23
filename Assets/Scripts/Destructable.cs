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
        Instantiate(explosion, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
    }
}
