using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivatePlayerShip : MonoBehaviour {

    public GameObject[] shipPrefabs;
    public GameObject player;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < shipPrefabs.Length; i++)
        {
            if (shipPrefabs[i].name == PlayerPrefs.GetString("Ship"))
            {
                player = Instantiate(shipPrefabs[i], Vector3.zero, Quaternion.identity) as GameObject;
                player.name = "Player";
            }
        }
	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
