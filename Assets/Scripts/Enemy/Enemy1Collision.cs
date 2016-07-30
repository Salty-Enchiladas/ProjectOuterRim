using UnityEngine;
using System.Collections;

public class Enemy1Collision : MonoBehaviour {

    public GameObject ship;
    public GameObject explosion;
    public GameObject explosionSound;

    public GameObject player;

    PlayerScore _playerScore;
    WaveHandler _waveHandler;

    void Start()
    {
        player = GameObject.Find("Player");
        _playerScore = player.GetComponent<PlayerScore>();
        _waveHandler = GameObject.Find("GameManager").GetComponent<WaveHandler>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Laser")
        {
            col.gameObject.SetActive(false);
            gameObject.SetActive(false);

            _waveHandler.enemyCount--;

            _playerScore.score += 1000;
            _playerScore.UpdateScore();

            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(explosionSound, transform.position, transform.rotation);
        }
    }
}