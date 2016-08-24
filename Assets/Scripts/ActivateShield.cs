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

    public void ShieldLevel1(bool levelUp)
    {
        print(levelUp + "Shield1");
        if (levelUp)
        {
            shield.SetActive(true);
            shield.GetComponent<Shield>().currentHealth = shield.GetComponent<Shield>().currentHealth + 3;
        }
    }

    public void ShieldLevel2(bool levelUp)
    {
        print(levelUp + "Shield2");
        if (levelUp)
        {
            shield.SetActive(true);
            shield.GetComponent<Shield>().currentHealth = shield.GetComponent<Shield>().currentHealth + 5;
        }

    }

    public void ShieldLevel3(bool levelUp)
    {
        if (levelUp)
        {
            shield.SetActive(true);
            shield.GetComponent<Shield>().currentHealth = shield.GetComponent<Shield>().currentHealth + 7;
            shield.GetComponent<Shield>().startingHealth = shield.GetComponent<Shield>().startingHealth + 3;
        }
    }
}
