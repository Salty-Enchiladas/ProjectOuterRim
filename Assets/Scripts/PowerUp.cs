using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        SHIELD,
        LASER,
        Missile,
    }

    public PowerUpType type = PowerUpType.SHIELD;
    PickUpManager pickUpManager;
    public int powerUpLength;
    GameObject player;
    GameObject shield;
    GameObject gameManager;
    bool hit;

    int laserLevel;
    int missileLevel;
    int shieldLevel;

    [HideInInspector]
    public string shieldType;

    [HideInInspector]
    public string laserType;

    [HideInInspector]
    public string missileType;

    void Start()
    {
        player = GameObject.Find("Player");
        shield = player.transform.FindChild("Shield").gameObject;
        gameManager = GameObject.Find("GameManager");
        pickUpManager = gameManager.GetComponent<PickUpManager>();
    }
	void ApplyPower ()
    {
        switch (type)
        {
            case PowerUpType.SHIELD:

                shieldType = "shield";
                pickUpManager.LevelUp(shieldType);
                shieldLevel = pickUpManager.shieldLevel;

                switch (shieldLevel)
                {
                    case 1:
                        print("Shield upgraded to level 1!");
                        break;
                    case 2:
                        print("Shield upgraded to level 2!");
                        break;
                    case 3:
                        print("Shield upgraded to level 3!");
                        break;
                }

                break;

            case PowerUpType.LASER:

                laserType = "laser";
                pickUpManager.LevelUp(laserType);
                laserLevel = pickUpManager.laserLevel;
                
                switch (laserLevel)
                {
                    case 1:
                        print("Laser upgraded to level 1!");
                        break;
                    case 2:
                        print("Laser upgraded to level 2!");
                        break;
                    case 3:
                        print("Laser upgraded to level 3!");
                        break;
                }

                break;

            case PowerUpType.Missile:

                missileType = "missile";
                pickUpManager.LevelUp(missileType);
                missileLevel = pickUpManager.missileLevel;
                switch (missileLevel)
                {
                    case 1:
                        print("Missile upgraded to level 1!");
                        break;
                    case 2:
                        print("Missile upgraded to level 2!");
                        break;
                    case 3:
                        print("Missile upgraded to level 3!");
                        break;
                }

                break;
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
}
