using UnityEngine;
using System.Collections;

public class ActivateShield : MonoBehaviour
{
    GameObject shield;
    GameObject gameManager;
    GameObject shieldLevel1Bar;
    GameObject shieldLevel2Bar;
    GameObject shieldLevel3Bar;

    GameObject shieldIcon;

    public bool onCooldown;
    public float shieldCooldown;

    PublicVariableHandler publicVariableHandler;
    Shield shieldScript;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        shieldCooldown = publicVariableHandler.playerShieldCooldown;
        shield = GetComponent<StoreVariables>().shield;
        shieldScript = shield.GetComponent<Shield>();
        shieldIcon = publicVariableHandler.shieldIcon;

        shieldLevel1Bar = publicVariableHandler.shieldLevel1Bar;
        shieldLevel2Bar = publicVariableHandler.shieldLevel2Bar;
        shieldLevel3Bar = publicVariableHandler.shieldLevel3Bar;
    }

	void Update () 
    {
        if (Input.GetButtonUp("Fire3") && !onCooldown)
        {
            ShieldActive();
        }
	}

    void ShieldActive()
    {
        shield.SetActive(true);
        onCooldown = true;
        shieldIcon.SetActive(false);
    }

    public void ShieldLevel1(bool levelUp)
    {
        if (levelUp)
        {
            shieldLevel1Bar.SetActive(levelUp);
            ShieldActive();
            shieldScript.startingHealth = shieldScript.startingHealth + 2;
            shieldScript.currentHealth = shieldScript.startingHealth;

        }
        else if (!levelUp)
        {
            shieldScript.startingHealth = shieldScript.startingHealth - 2;
        }
    }

    public void ShieldLevel2(bool levelUp)
    {
        if (levelUp)
        {
            shieldLevel2Bar.SetActive(levelUp);
            ShieldActive();
            shieldCooldown = shieldCooldown - 5;
        }
        else if (!levelUp)
        {
            shieldCooldown = shieldCooldown + 5;
        }
    }

    public void ShieldLevel3(bool levelUp)
    {
        if (levelUp)
        {
            shieldLevel3Bar.SetActive(levelUp);
            ShieldActive();
            shieldScript.startingHealth = shieldScript.startingHealth + 3;
            shieldScript.currentHealth = shieldScript.startingHealth;
            shieldCooldown = shieldCooldown - 5;
        }
        else if (!levelUp)
        {
            shieldScript.startingHealth = shieldScript.startingHealth - 3;
            shieldCooldown = shieldCooldown + 5;
        }
    }

    public void StartMyCoroutine()
    {
        StartCoroutine(StartShieldCooldown());
    }
    IEnumerator StartShieldCooldown()
    {
        yield return new WaitForSeconds(2);
        onCooldown = false;
        shieldIcon.SetActive(true);
    }
}
