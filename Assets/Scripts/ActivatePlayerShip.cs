using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivatePlayerShip : MonoBehaviour {

    public bool debugMode;
    public GameObject[] shipPrefabs;
    public GameObject player;

	// Use this for initialization
	void Start () {
        if (!debugMode)
        {
            for (int i = 0; i < shipPrefabs.Length; i++)
            {
                if (PlayerPrefs.GetString("Ship") == "")
                {
                    player = Instantiate(shipPrefabs[0], Vector3.zero, Quaternion.identity) as GameObject;
                    player.name = "Player";
                }
                else if (shipPrefabs[i].name == PlayerPrefs.GetString("Ship"))
                {
                    player = Instantiate(shipPrefabs[i], Vector3.zero, Quaternion.identity) as GameObject;
                    player.name = "Player";
                }
            }
        }
        else
        {
            //do nothing
        }
	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
