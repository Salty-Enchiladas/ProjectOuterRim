using UnityEngine;
using System.Collections;

public class ChooseShipButton : MonoBehaviour {

    public GameObject shipContainer;

    ShipWrangler _shipWrangler;
    bool hasMoved;
	// Use this for initialization
	void Start () {
        _shipWrangler = shipContainer.GetComponent<ShipWrangler>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") < -.99f && !hasMoved)
        {
            hasMoved = true;
            PreviousShip();
        }
        else if (Input.GetAxis("Horizontal") > .99f && !hasMoved)
        {
            hasMoved = true;
            NextShip();
        }
        else if (Input.GetAxis("Horizontal") > -.05f && Input.GetAxis("Horizontal") < .05f)
        {
            hasMoved = false;
        }


    }

    public void NextShip()
    {
        _shipWrangler.NextSelection();
    }

    public void PreviousShip()
    {
        _shipWrangler.PreviousSelection();
    }

    public void Play()
    {
    //    if (_shipWrangler.CurrentShip.GetComponent<ShipUnlocking>().unlocked == true)
    //    {
            PlayerPrefs.SetString("Ship", _shipWrangler.CurrentShip.name);
            GetComponent<LoadLevel>().LevelLoad();
       // }
    }
}
