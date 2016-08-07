using UnityEngine;
using System.Collections;

public class Enemy1Collision : MonoBehaviour {

    public GameObject ship;
    public GameObject explosion;
    public GameObject explosionSound;
    public GameObject meteorExplosionPrefab;
    public GameObject player;

    public int baseHealth;
    public int currentHealth;

    PlayerScore _playerScore;

    void Start()
    {
        currentHealth = baseHealth;
        player = GameObject.Find("Player");
        _playerScore = player.GetComponent<PlayerScore>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Laser")
        {
            col.gameObject.SetActive(false);
            gameObject.SetActive(false);

            GameObject.Find("GameManager").GetComponent<WaveHandler>().enemyCount--;

            _playerScore.score += 1000;

            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(explosionSound, transform.position, transform.rotation);
        }
        else if (col.gameObject.tag == "Missile")
        {
            col.gameObject.SetActive(false);
            WasDestroyed();
            _playerScore.score += 1000;
        }

        else if (col.gameObject.tag == "Meteor")
        {
            WasDestroyed();
            Instantiate(meteorExplosionPrefab, transform.position, transform.rotation);
            col.gameObject.SetActive(false);
        }
    }

    public void TookDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            WasDestroyed();
        }
    }
    public void WasDestroyed()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Instantiate(explosionSound, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}