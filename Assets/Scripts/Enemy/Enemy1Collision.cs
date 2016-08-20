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
    AchievementManager achievementManager;
    GameObject gameManager;

    void Start()
    {
        currentHealth = baseHealth;
        player = GameObject.Find("Player");
        _playerScore = player.GetComponent<PlayerScore>();
        gameManager = GameObject.Find("GameManager");
        achievementManager = gameManager.GetComponent<AchievementManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Laser")
        {
            col.gameObject.SetActive(false);            
            _playerScore.score += 1000;
            WasDestroyed();
        }
        else if (col.gameObject.tag == "Missile")
        {
            col.gameObject.SetActive(false);
            _playerScore.score += 1000;
            WasDestroyed();
        }
        else if (col.gameObject.tag == "Meteor")
        {
            Instantiate(meteorExplosionPrefab, transform.position, transform.rotation);
            col.gameObject.SetActive(false);
            WasDestroyed();            
        }
    }

    public void TookDamage()
    {
        currentHealth--;
        achievementManager.EnemyHit();
        if (currentHealth <= 0)
        {
            WasDestroyed();
        }
    }
    public void WasDestroyed()
    {
        achievementManager.EnemyDied();
        GameObject.Find("GameManager").GetComponent<WaveHandler>().enemyCount--;
        Instantiate(explosion, transform.position, transform.rotation);
        Instantiate(explosionSound, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}