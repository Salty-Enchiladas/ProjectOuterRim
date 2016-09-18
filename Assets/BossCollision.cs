using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        print("I hit " + other.transform.parent.transform.parent);
        if (other.transform.parent.transform.parent.name == "Player")
        {
            print("hit!");
            SceneManager.LoadScene("GameOver");
        }
    }
}
