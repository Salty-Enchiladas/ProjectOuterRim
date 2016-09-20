using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SwitchMenu : MonoBehaviour {

    public GameObject deactivate;
    public GameObject activate;
    public GameObject nextSelectedObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadCredits()
    {
        deactivate.SetActive(false);
        activate.SetActive(true);
        EventSystem.current.SetSelectedGameObject(nextSelectedObject);
    }
}
