using UnityEngine;
using System.Collections;

public class ActivateShield : MonoBehaviour
{
    GameObject shield;
    GameObject gameManager;
    GameObject shieldLevel1Bar;
    GameObject shieldLevel2Bar;
    GameObject shieldLevel3Bar;

    public bool onCooldown;
    public float shieldCooldown;
    public float shieldLength;

    float lastUse;
    float lastActive;

    PublicVariableHandler publicVariableHandler;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        shieldCooldown = publicVariableHandler.playerShieldCooldown;
        shieldLength = publicVariableHandler.playerShieldLength;
        shield = GetComponent<StoreVariables>().shield;

        shieldLevel1Bar = publicVariableHandler.shieldLevel1Bar;
        shieldLevel2Bar = publicVariableHandler.shieldLevel2Bar;
        shieldLevel3Bar = publicVariableHandler.shieldLevel3Bar;
    }

	void Update () 
    {
        if (Input.GetButtonUp("Fire3") && Time.time > lastUse + shieldCooldown)
        {
            if (!onCooldown)
            {
                shield.SetActive(true);
                GetComponentInChildren<PlayerCollision>().shieldActive = true;
                StartCoroutine(ShieldActive());
            }
        }
	}

    public void ShieldDestroyed()
    {
        shield.SetActive(false);
        onCooldown = true;
        GetComponentInChildren<PlayerCollision>().shieldActive = false;
    }

    IEnumerator ShieldActive()
    {
        onCooldown = true;
        yield return new WaitForSeconds(shieldLength);
        lastUse = Time.time;
        shield.SetActive(false);
        GetComponentInChildren<PlayerCollision>().shieldActive = false;
        onCooldown = false;
    }

    public void ShieldLevel1(bool levelUp)
    {
        print(levelUp + "Shield1");
        if (levelUp)
        {
            shieldLevel1Bar.SetActive(levelUp);
            StartCoroutine(ShieldActive());
            shieldLength = shieldLength + 2;
            shieldCooldown = shieldCooldown - 2;
        }
        else if (!levelUp)
        {
            shieldLength = shieldLength - 2;
            shieldCooldown = shieldCooldown + 2;
        }
    }

    public void ShieldLevel2(bool levelUp)
    {
        print(levelUp + "Shield2");
        if (levelUp)
        {
            shieldLevel2Bar.SetActive(levelUp);
            StartCoroutine(ShieldActive());
            shieldLength = shieldLength + 2;
            shieldCooldown = shieldCooldown - 2;
        }
        else if (!levelUp)
        {
            shieldLength = shieldLength - 2;
            shieldCooldown = shieldCooldown + 2;
        }

    }

    public void ShieldLevel3(bool levelUp)
    {
        if (levelUp)
        {
            shieldLevel3Bar.SetActive(levelUp);
            StartCoroutine(ShieldActive());
            shieldLength = shieldLength + 2;
            shieldCooldown = shieldCooldown - 2;
        }
        else if (!levelUp)
        {
            shieldLength = shieldLength - 2;
            shieldCooldown = shieldCooldown + 2;
        }
    }
}
