using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
    public int startingHealth;
    public int currentHealth;
    public GameObject meteorExplosionPrefab;

    void Start()
    {
        currentHealth = startingHealth;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy Laser")
        {
            other.gameObject.SetActive(false);
            currentHealth--;
            if (currentHealth == 0)
            {
                transform.parent.GetComponent<ActivateShield>().ShieldDestroyed();
            }
        }
        else if (other.tag == "Meteor")
        {
            transform.parent.GetComponent<ActivateShield>().ShieldDestroyed();
            Instantiate(meteorExplosionPrefab, transform.position, transform.rotation);
            other.gameObject.SetActive(false);
        }
    }
}
