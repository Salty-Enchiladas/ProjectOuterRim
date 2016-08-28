using UnityEngine;
using System.Collections;

public class ActivateShield : MonoBehaviour
{
    GameObject shield;
    GameObject gameManager;

    public bool onCooldown;
    public float shieldCooldown;
    public float shieldLength;

    float lastUse;
    float lastActive;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        shieldCooldown = gameManager.GetComponent<PublicVariableHandler>().playerShieldCooldown;
        shieldLength = gameManager.GetComponent<PublicVariableHandler>().playerShieldLength;
        shield = GetComponent<StoreVariables>().shield;
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
