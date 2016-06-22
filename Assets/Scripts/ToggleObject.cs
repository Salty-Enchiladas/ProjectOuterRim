using UnityEngine;
using System.Collections;

public class ToggleObject : MonoBehaviour {

    public GameObject _object;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Toggle()
    {
        _object.SetActive(!_object.activeInHierarchy);
    }
}
