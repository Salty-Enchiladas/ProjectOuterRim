using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour {
	
	RaycastHit hit;
	bool leftClickFlag = true;
	
	public GameObject[] actor;
	public string floorTag;

    public List<GameObject[]> list;

	Actor[] actorScript;
	
	void Start()
	{
        //if (actor != null)
        //{
        //    actorScript = (Actor)actor.GetComponent(typeof(Actor));
        //}
        actorScript = new Actor[actor.Length];

        for (int i = 0; i < actor.Length; i++)
        {
            actorScript[i] = (Actor)actor[i].GetComponent(typeof(Actor));
        }
	}

    void Update() 
	{
		/***Left Click****/
		if (Input.GetKey(KeyCode.Mouse0) && leftClickFlag)
			leftClickFlag = false;
		
		if (!Input.GetKey(KeyCode.Mouse0) && !leftClickFlag)
		{
			leftClickFlag = true;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100))
			{
				if (hit.transform.tag == floorTag)
				{
					float X = hit.point.x;
					float Z = hit.point.z;
                    for (int i = 0; i < actor.Length; i++)
                    {
                        Vector3 target = new Vector3(X, actor[i].transform.position.y, Z);

                        actorScript[i].MoveOrder(target);
                    }
					
				}
			}
		}
	}
}
