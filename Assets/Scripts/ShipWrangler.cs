using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShipWrangler : MonoBehaviour {

    public List<GameObject> ships;
    public int currentShip;
    bool hasMoved;
    bool cycling;

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

        if (Input.GetAxis("Horizontal") < -.99f && !hasMoved || Input.GetKeyDown(KeyCode.A))
        {
            CallCycle("left");
        }
        else if (Input.GetAxis("Horizontal") > .99f && !hasMoved || Input.GetKeyDown(KeyCode.D))
        {
            CallCycle("right");
        }
        else if (Input.GetAxis("Horizontal") > -.09f && Input.GetAxis("Horizontal") < .09f)
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

    void CallCycle(string direction)
    {
        StartCoroutine(Cycle(direction));
    }

    IEnumerator Cycle(string direction)
    {
        if(!cycling)
        {
            cycling = true;
            if(direction == "left")
            {
                hasMoved = true;
                PreviousSelection();
            }
            else if(direction == "right")
            {
                hasMoved = true;
                NextSelection();
            }
            yield return new WaitForSeconds(0.25f);
            cycling = false;
        }
    }
}
