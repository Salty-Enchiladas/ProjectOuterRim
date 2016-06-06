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
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.Translate(Vector3.forward * missileSpeed * Time.deltaTime);
        //Vector3 targetDir = target.transform.position - transform.position;

        //target.transform.position -= transform.position * missileSpeed * Time.deltaTime;

        if (transform.position.z > 60 || transform.position.z < -50)
        {
            Destroy(gameObject);
        }
    }
}
