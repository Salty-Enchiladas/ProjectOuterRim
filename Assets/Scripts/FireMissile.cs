﻿using UnityEngine;
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

    bool hasTarget;

    // Use this for initialization
    void Start () {
        hasTarget = false;
    }
	
	// Update is called once per frame
	void Update () {
        FindEnemy();

        if ((Input.GetButtonDown("Fire2") || (Input.GetAxis("Missile")) != 0) && Time.time > (lastShot + missileCooldown) && hasTarget && missileCount > 0)
        {
            Missile();
        }
        else if ((Input.GetButtonDown("Fire2") || (Input.GetAxis("Missile")) != 0) && !hasTarget)
        {
            StartCoroutine(FlashNoTarget());
        }

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
        if(target == null)
        {
            hasTarget = false;            
        }
        else if(!target.activeInHierarchy)
        {
            hasTarget = false;
        }
        else if(target.activeInHierarchy)
        {
            target.GetComponent<EnemyState>().isTarget = true;
            hasTarget = true;
        }
    }

    IEnumerator MissileRecharge(float _missileRechargeLength)
    {
        yield return new WaitForSeconds(_missileRechargeLength);
        missileCount++;
    }

    IEnumerator FlashNoTarget()
    {
        noTarget.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        noTarget.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        noTarget.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        noTarget.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        noTarget.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        noTarget.SetActive(false);
    }
}
