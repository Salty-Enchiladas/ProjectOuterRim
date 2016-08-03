using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
    public int startingHealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyLaser")
        {
            print("You were hit!");
            currentHealth--;
            if (currentHealth == 0)
            {
                transform.parent.GetComponent<ActivateShield>().ShieldDestroyed();
            }
        }
    }
}
