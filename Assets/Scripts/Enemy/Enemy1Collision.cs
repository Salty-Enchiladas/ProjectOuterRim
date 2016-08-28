﻿using UnityEngine;
using System.Collections;

public class Enemy1Collision : MonoBehaviour {

    public GameObject ship;
    public GameObject explosion;
    public GameObject explosionSound;
    public GameObject meteorExplosionPrefab;
    public GameObject player;

    public int laserScore;
    public int missileScore;
    public int baseHealth;
    public int currentHealth;

    PlayerScore _playerScore;
    AchievementManager achievementManager;
    PublicVariableHandler publicVariableHandler;
    GameObject gameManager;

    void Start()
    {
        currentHealth = baseHealth;
        player = GameObject.Find("Player");
        _playerScore = player.GetComponent<PlayerScore>();
        gameManager = GameObject.Find("GameManager");
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        achievementManager = gameManager.GetComponent<AchievementManager>();

        switch (transform.name)
        {
            case "Enemy1":
                laserScore = publicVariableHandler.enemy1LaserScore;
                missileScore = publicVariableHandler.enemy1MissileScore;
                baseHealth = publicVariableHandler.enemy1BaseHealth;
                break;
            case "Enemy2":
                laserScore = publicVariableHandler.enemy2LaserScore;
                missileScore = publicVariableHandler.enemy2MissileScore;
                baseHealth = publicVariableHandler.enemy2BaseHealth;
                break;
            case "Enemy3":
                laserScore = publicVariableHandler.enemy3LaserScore;
                missileScore = publicVariableHandler.enemy3MissileScore;
                baseHealth = publicVariableHandler.enemy3BaseHealth;
                break;
            case "Enemy4":
                laserScore = publicVariableHandler.enemy4LaserScore;
                missileScore = publicVariableHandler.enemy4MissileScore;
                baseHealth = publicVariableHandler.enemy4BaseHealth;
                break;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Laser")
        {
            col.gameObject.SetActive(false);
            WasDestroyed();
        }
        else if (col.gameObject.tag == "Missile")
        {
            col.gameObject.SetActive(false);
            WasDestroyed();
        }
        else if (col.gameObject.tag == "Meteor")
        {
            Instantiate(meteorExplosionPrefab, transform.position, transform.rotation);
            col.gameObject.SetActive(false);
            //switch (transform.name)
            //{
            //    case "Enemy1":
            //        gameManager.GetComponent<WaveHandler>().enemy1Count--;
            //        break;
            //    case "Enemy2":
            //        gameManager.GetComponent<WaveHandler>().enemy2Count--;
            //        break;
            //    case "Enemy3":
            //        gameManager.GetComponent<WaveHandler>().enemy3Count--;
            //        break;
            //    case "Enemy4":
            //        gameManager.GetComponent<WaveHandler>().enemy4Count--;
            //        break;
            //}
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(explosionSound, transform.position, transform.rotation);
            gameObject.SetActive(false);
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
        _playerScore.score += laserScore;
        switch (transform.name)
        {
            case "Enemy1":
                gameManager.GetComponent<WaveHandler>().firstEnemyCount--;
                break;
            case "Enemy2":
                gameManager.GetComponent<WaveHandler>().secondEnemyCount--;
                break;
            case "Enemy3":
                gameManager.GetComponent<WaveHandler>().thirdEnemyCount--;
                break;
            case "Enemy4":
                gameManager.GetComponent<WaveHandler>().fourthEnemyCount--;
                break;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Instantiate(explosionSound, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}