using UnityEngine;
using System.Collections;

public class ShipWrangler : MonoBehaviour {

    public GameObject[] ships;
    public int currentShip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        DisplayShip();
	}    

    public GameObject CurrentShip
    {
        get { return ships[currentShip]; }
        set { ships[currentShip] = value; }
    }    

    public void NextSelection()
    {
        if (currentShip == ships.Length - 1)
        {
            currentShip = 0;
        }
        else
        {
            currentShip++;
        }
    }

    public void PreviousSelection()
    {
        if (currentShip == 0)
        {
            currentShip = ships.Length - 1;
        }
        else
        {
            currentShip--;
        }
    }

    void DisplayShip()
    {
        for (int i = 0; i < ships.Length; i++)
        {
            if (i == currentShip)
            {
                ships[i].SetActive(true);
            }
            else
            {
                ships[i].SetActive(false);
            }
        }
    }
}
