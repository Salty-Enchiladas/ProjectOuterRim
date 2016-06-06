using UnityEngine;
using System.Collections;

public class ShipCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            Application.LoadLevel("RebelGO");
        }
    }
}
