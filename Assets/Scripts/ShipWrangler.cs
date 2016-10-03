using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShipWrangler : MonoBehaviour {

    public List<GameObject> ships;
    public int currentShip;
    bool hasMoved;

	// Use this for initialization
	void Start ()
    {
        Transform[] children;
        children = transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in children)
        {
            if (t.tag == "ShipWrangler")
            {
                ships.Add(t.gameObject);
                t.gameObject.SetActive(false);
            }
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        DisplayShip();

        if (Input.GetAxis("Horizontal") < -.99f && !hasMoved)
        {
            hasMoved = true;
            PreviousSelection();
        }
        else if (Input.GetAxis("Horizontal") > .99f && !hasMoved)
        {
            hasMoved = true;
            NextSelection();
        }
        else if (Input.GetAxis("Horizontal") > -.05f && Input.GetAxis("Horizontal") < .05f)
        {
            hasMoved = false;
        }
    }    

    public GameObject CurrentShip
    {
        get { return ships[currentShip]; }
        set { ships[currentShip] = value; }
    }    

    public void NextSelection()
    {
        if (currentShip == ships.Count - 1)
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
            currentShip = ships.Count - 1;
        }
        else
        {
            currentShip--;
        }
    }

    void DisplayShip()
    {
        for (int i = 0; i < ships.Count; i++)
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
