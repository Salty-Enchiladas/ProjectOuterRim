﻿using System.Collections;
using UnityEngine;

public class FireMissile : MonoBehaviour
{
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

    private float lastShot;

    private bool hasTarget;

    // Use this for initialization
    private void Start()
    {
        hasTarget = false;
        missile1Img = GameObject.Find("M1b");
        missile2Img = GameObject.Find("M2b");
        missile3Img = GameObject.Find("M3b");

        noTarget = GameObject.Find("NoTarget");
        noTarget.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("XB LockOn"))
        {
            FindEnemy();
        }

        if ((Input.GetButtonDown("Fire2") || Input.GetAxis("Missile") != 0) && Time.time > (lastShot + missileCooldown) && hasTarget && missileCount > 0)
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

    private void Missile()
    {
        lastShot = Time.time;
        Instantiate(missile, transform.position, transform.rotation);
        missileCount--;
        if (missileCount < missileMax && !(missileCount >= missileMax))
        {
            StartCoroutine(MissileRecharge(missileRechargeLength));
        }
    }

    private void FindEnemy()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");

        if (target == null)
        {
            hasTarget = false;
        }
        else if (!target.activeInHierarchy)
        {
            hasTarget = false;
        }
        else if (target.activeInHierarchy)
        {
            target.GetComponent<EnemyState>().isTarget = true;
            hasTarget = true;
        }
    }

    private IEnumerator MissileRecharge(float _missileRechargeLength)
    {
        yield return new WaitForSeconds(_missileRechargeLength);
        missileCount++;
    }

    private IEnumerator FlashNoTarget()
    {
        if (!noTarget.activeInHierarchy)
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
}