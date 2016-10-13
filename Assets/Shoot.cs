using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    GameObject player;
    FireMissile fireMissile;
    FireScript gun1;
    FireScript gun2;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        fireMissile = player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>();
        gun1 = player.GetComponent<StoreVariables>().lasers[0].GetComponent<FireScript>();
        gun2 = player.GetComponent<StoreVariables>().lasers[1].GetComponent<FireScript>();
    }
	
	public void FireLaser ()
    {
        gun1.StartFire();
        gun2.StartFire();
        
	}

    public void FireMissile()
    {
        fireMissile.ShootMissile();
    }
}
