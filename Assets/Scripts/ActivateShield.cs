using UnityEngine;
using System.Collections;

public class ActivateShield : MonoBehaviour
{
    GameObject shield;
    public bool onCooldown;

    void Start()
    {
        shield = GetComponent<StoreVariables>().shield;
    }
	void Update () 
    {
        if (Input.GetButtonUp("Fire3"))
        {
            if (!onCooldown)
            {
                shield.GetComponent<Shield>().currentHealth = shield.GetComponent<Shield>().startingHealth;
                shield.SetActive(true);
                GetComponentInChildren<PlayerCollision>().shieldActive = true;
            }
        }
	}

    public void ShieldDestroyed()
    {
        shield.SetActive(false);
        onCooldown = true;
        GetComponentInChildren<PlayerCollision>().shieldActive = false;
    }
}
