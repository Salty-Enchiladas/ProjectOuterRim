using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileZone : MonoBehaviour
{
    public GameObject target;
    public List<GameObject> targetList;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if(!targetList.Contains(other.gameObject))
            {
                targetList.Add(other.gameObject);
            }
            //target = other.gameObject;
        }
    }
}
