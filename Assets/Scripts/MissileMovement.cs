using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileMovement : MonoBehaviour {

    public float missileSpeed;
    public GameObject target;
    GameObject nozzle;
    List<GameObject> possibleTargets;
    GameObject possibleTarget;

    void Start()
    {
        nozzle = GameObject.Find("MissileNozzle");
        target = nozzle.GetComponent<FireMissile>().target;
        StartCoroutine(IncreaseSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.Translate(Vector3.forward * missileSpeed * Time.deltaTime);
    }

    IEnumerator IncreaseSpeed()
    {
        missileSpeed = missileSpeed * 1.5f;
        yield return new WaitForSeconds(1);
        missileSpeed = missileSpeed * 1.5f;
        yield return new WaitForSeconds(1);
        missileSpeed = missileSpeed * 1.5f;
        yield return new WaitForSeconds(.5f);
        missileSpeed = missileSpeed * 1.5f;
        yield return new WaitForSeconds(.5f);
    }
}
