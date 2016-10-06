using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class ActivatePrevious : MonoBehaviour
{
    public GameObject[] activateNext;
    public GameObject activatePrevious;

	void Update ()
    {
        if (Input.GetButtonDown("Fire4"))
        {
            activatePrevious.SetActive(true);
            activatePrevious.GetComponent<InitialWrangler>().enabled = true;
            gameObject.SetActive(false);
        }
	}
}
