using UnityEngine;
using System.Collections;

public class ActivateShield : MonoBehaviour 
{
    public GameObject shield;
    public bool onCooldown;

	void Update () 
    {
        if (Input.GetButtonUp("Fire2"))
        {
            if (!onCooldown)
            {
                shield.GetComponent<Shield>().currentHealth = shield.GetComponent<Shield>().startingHealth;
                shield.SetActive(true);
            }
        }
	}

    public void ShieldDestroyed()
    {
        shield.SetActive(false);
        onCooldown = true;
    }
}
