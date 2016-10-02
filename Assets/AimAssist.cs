﻿using UnityEngine;
using System.Collections;

public class AimAssist : MonoBehaviour
{
    bool foundTarget;
    RaycastHit hit;
    StoreVariables storeVariables;
    GameObject gun1;
    GameObject gun2;
    FireScript gun1Script;
    FireScript gun2Script;

    void Start()
    {
        storeVariables = GetComponent<StoreVariables>();
        gun1 = storeVariables.lasers[0];
        gun2 = storeVariables.lasers[1];
        gun1Script = gun1.GetComponent<FireScript>();
        gun2Script = gun2.GetComponent<FireScript>();
    }
	void Update ()
    {
        foundTarget = Physics.CapsuleCast(transform.position, transform.position + (transform.forward * 1), 1, transform.forward, out hit);
        if (hit.transform.tag == "Enemy")
        {
            gun1Script.target = hit.transform;
            gun2Script.target = hit.transform;
        }
	}
}
