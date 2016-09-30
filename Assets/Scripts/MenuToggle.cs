using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuToggle : MonoBehaviour {

    public GameObject deactivate;
    public GameObject activate;
    public GameObject nextSelected;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
    }
    public void ToggleMenu()
    {
        deactivate.SetActive(false);
        activate.SetActive(true);
        EventSystem.current.SetSelectedGameObject(nextSelected);
    }
}
