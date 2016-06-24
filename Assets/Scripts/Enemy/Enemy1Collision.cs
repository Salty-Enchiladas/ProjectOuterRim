using UnityEngine;
using System.Collections;

public class Enemy1Collision : MonoBehaviour {

    public GameObject ship;
    public GameObject explosion;
    public GameObject explosionSound;

    public GameObject player;

    PlayerScore _playerScore;

    void Start()
    {
        player = GameObject.Find("Player");
        _playerScore = player.GetComponent<PlayerScore>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Laser")
        {
            col.gameObject.SetActive(false);
            gameObject.SetActive(false);

            _playerScore.score += 1000;

            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(explosionSound, transform.position, transform.rotation);
        }
    }
}