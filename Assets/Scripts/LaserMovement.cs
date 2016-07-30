using UnityEngine;
using System.Collections;

public class LaserMovement : MonoBehaviour {

    public float laserSpeed;

    GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(0, 0, laserSpeed * Time.deltaTime);

        if (transform.position.z > _player.transform.position.z + 20 || transform.position.z < _player.transform.position.z - 2)
        {
            gameObject.SetActive(false);
        }
    }
}
