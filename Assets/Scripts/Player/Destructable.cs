﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destructable : MonoBehaviour 
//This script will be reuseable to make any gameobject explode into pieces.
//This script requires that the object's pieces have a rigidbody and a mesh collider.
//The parent object needs to have a non mesh collider on it.

//Usually you will want to place this script on the parent object but if for what ever reason you can not,
//you can simply drag the parent object into the empty parent object variable in the inspector.
{
    public GameObject parentObject;
    public MeshCollider[] objectPieces;

    public bool sploded;
    
    // Use this for initialization
    void Start () 
    {        
        objectPieces = parentObject.GetComponentsInChildren<MeshCollider>();

        foreach (MeshCollider mc in objectPieces)
        {
            mc.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            mc.convex = false;
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        if (sploded)
        {
            foreach (MeshCollider mc in objectPieces)
            {
                mc.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                mc.convex = false;
            }

            sploded = false;
        }
    }

    void OnTriggerEnter (Collider other) 
    {
        foreach (MeshCollider mc in objectPieces)
        {
            mc.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            mc.convex = true;
        }
    }
}