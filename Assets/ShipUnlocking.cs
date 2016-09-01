using UnityEngine;
using System.Collections;

public class ShipUnlocking : MonoBehaviour
{

    public string shipName;
    public bool unlocked;
	void Start ()
    {
        if (PlayerPrefs.GetInt(shipName) == 1)
        {
            unlocked = true;
        }
	}
}
