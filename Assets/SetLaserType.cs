using UnityEngine;
using System.Collections;

public class SetLaserType : MonoBehaviour
{
    GameObject player;

	void Start ()
    {
        player = GameObject.Find("Player");
        GetComponent<ObjectPooling>().pooledObject = player.GetComponent<StoreVariables>().laserColor;
	}
}
