using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        SHIELD,
        LASER,
        LIFE,
       // INVULNERABILITY,
    }

    public PowerUpType type = PowerUpType.SHIELD;
    public int powerUpLength;
    GameObject player;
    GameObject shield;
    bool hit;

    void Start()
    {
        player = GameObject.Find("Player");
        shield = player.transform.FindChild("Shield").gameObject;
        type = (PowerUpType)Random.Range(0, 3);
    }
	void ApplyPower ()
    {
        switch (type)
        {
            case PowerUpType.SHIELD:

                player.GetComponent<ActivateShield>().onCooldown = false;
                shield.GetComponent<Shield>().currentHealth = shield.GetComponent<Shield>().startingHealth;
                shield.SetActive(true);

                break;

            case PowerUpType.LASER:

                StartCoroutine(LaserPowerUp());

                break;

            case PowerUpType.LIFE:
                if (player.GetComponentInChildren<PlayerCollision>().playerLives < 3)
                {
                    player.GetComponentInChildren<PlayerCollision>().playerLives++;
                    print("You gained a life!");
                }

                break;

            //case PowerUpType.INVULNERABILITY:

            //    StartCoroutine(InvulnerabilityPowerUp());

            //    break;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (!hit)
        {
            if (other.name == "Colliders")
            {
                hit = true;
                ApplyPower();
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator LaserPowerUp()
    {
        foreach (GameObject go in player.GetComponent<Upgrades>().weapons)
        {
            go.SetActive(true);
        }
        yield return new WaitForSeconds(powerUpLength);
        foreach (GameObject go in player.GetComponent<Upgrades>().weapons)
        {
            go.SetActive(false);
        }
    }
    //IEnumerator InvulnerabilityPowerUp()
    //{
    //    player.GetComponentInChildren<MeshCollider>().enabled = false;
    //    print("I AM INVINCIBLE!!! MUAHHAHAHAHHHAHAH!!!!");
    //    yield return new WaitForSeconds(powerUpLength);

    //    player.GetComponentInChildren<MeshCollider>().enabled = true;
    //    print("Annnddd, it's gone.");
    //}
}
