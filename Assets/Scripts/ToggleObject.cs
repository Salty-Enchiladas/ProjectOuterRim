using UnityEngine;
using System.Collections;

public class ToggleObject : MonoBehaviour {

    public GameObject[] objects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Toggle()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(!objects[i].activeInHierarchy);
        }
    }
}
