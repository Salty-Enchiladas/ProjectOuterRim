using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
    public int shieldHealth;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy Laser")
        {
            shieldHealth--;
            if (shieldHealth == 0)
            {
                transform.parent.GetComponent<ActivateShield>().ShieldDestroyed();
            }
        }
    }
}
