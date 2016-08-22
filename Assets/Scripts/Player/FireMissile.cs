using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FireMissile : MonoBehaviour {


    public GameObject missile;
    public GameObject missile1Img;
    public GameObject missile2Img;
    public GameObject missile3Img;
    public GameObject target;
    public GameObject noTarget;

    public float missileRechargeLength;
    public float missileCooldown;

    public int missileCount;
    public int missileMax;

    float lastShot;
    float recharge;
    bool hasTarget;

    // Use this for initialization
    void Start()
    {
        hasTarget = false;
        missile1Img = GameObject.Find("M1b");
        missile2Img = GameObject.Find("M2b");
        missile3Img = GameObject.Find("M3b");

        //noTarget = GameObject.Find("NoTarget");
        //noTarget.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            FindEnemy();
        }
        if ((Input.GetButtonUp("Fire2") && Time.time > (lastShot + missileCooldown) && hasTarget && missileCount > 0))   // || (Input.GetAxis("Secondary")) != 0)
        {
            Missile();
        }
        //else if ((Input.GetButtonDown("Fire2") && !hasTarget))   // || (Input.GetAxis("Secondary")) != 0)
        //{
        //    StartCoroutine(FlashNoTarget());
        //}

        switch (missileCount)
        {
            case 3:
                missile1Img.SetActive(true);
                missile2Img.SetActive(true);
                missile3Img.SetActive(true);
                break;
            case 2:
                missile1Img.SetActive(true);
                missile2Img.SetActive(true);
                missile3Img.SetActive(false);
                break;
            case 1:
                missile1Img.SetActive(true);
                missile2Img.SetActive(false);
                missile3Img.SetActive(false);
                break;
            case 0:
                missile1Img.SetActive(false);
                missile2Img.SetActive(false);
                missile3Img.SetActive(false);
                break;
            default:
                break;
        }
    }

    void Missile()
    {
        lastShot = Time.time;
        Instantiate(missile, transform.position, transform.rotation);
        missileCount--;
        if (missileCount < missileMax && !(missileCount >= missileMax))
        {
            StartCoroutine(MissileRecharge(missileRechargeLength));
        }
    }

    void FindEnemy()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
        if (target == null)
        {
            hasTarget = false;
        }
        else if (target.activeInHierarchy)
        {
            target.GetComponent<EnemyState>().isTarget = true;
            hasTarget = true;
        }
        else if (!target.activeInHierarchy)
        {
            hasTarget = false;
        }
    }

    IEnumerator MissileRecharge(float _missileRechargeLength)
    {
        recharge = _missileRechargeLength;
        yield return new WaitForSeconds(recharge);
        missileCount++;
    }

    public void MissileLevel1(bool levelUp)
    {

        print(levelUp + "Missile1");
        print("Old Recharge: " + recharge);
        if (levelUp)
        {
            recharge = recharge / 9;
            print("New Recharge: " + recharge);
        }
        else if (!levelUp)
        {
            recharge = recharge * 9;
            print("LostLevel Recharge " + recharge);
        }
    }

    public void MissileLevel2(bool levelUp)
    {
        print(levelUp + "Missile2");
        print("Old missileCooldown: " + missileCooldown);
        if (levelUp)
        {
            missileCooldown = missileCooldown / 3;
            print("New missileCooldown: " + missileCooldown);
        }
        else if (!levelUp)
        {
            missileCooldown = missileCooldown * 3;
            print("LostLevel missileCooldown " + missileCooldown);
        }

    }

    public void MissileLevel3(bool levelUp)
    {
        print(levelUp + "Missile3");
        print("Old missileMax: " + missileMax);
        if (levelUp)
        {
            missileMax = missileMax * 2;
            missile.GetComponent<MissileMovement>().missileSpeed = missile.GetComponent<MissileMovement>().missileSpeed * 2;
            print("New missileMax: " + missileMax);
        }
        else if (!levelUp)
        {
            missileMax = missileMax / 2;
            missile.GetComponent<MissileMovement>().missileSpeed = missile.GetComponent<MissileMovement>().missileSpeed / 2;
            print("LostLevel missileMax " + missileMax);
        }
    }
}
