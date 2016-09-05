using UnityEngine;
using System.Collections;

public class ToggleObject : MonoBehaviour {

    public GameObject _object;
    public GameObject lights;
    public GameObject shipLight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Toggle()
    {
        lights.SetActive(!lights.activeInHierarchy);
        shipLight.SetActive(!shipLight.activeInHierarchy);
        _object.SetActive(!_object.activeInHierarchy);
    }
}
