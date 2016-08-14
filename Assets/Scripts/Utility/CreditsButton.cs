using UnityEngine;
using System.Collections;

public class CreditsButton : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject credits;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }
}
