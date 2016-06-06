using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollisionRebel : MonoBehaviour {

    public GameObject explosion;
    public GameObject explosionSound;
    public GameObject healthBar1;
    public GameObject healthBar2;
    public GameObject healthBar3;
    public GameObject damageIndicatorIMG;
    public Text livesText;
    public int playerHealth = 3;
    public int playerLives = 3;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy Laser")
        {
            StartCoroutine(DamageIndicator());
            col.gameObject.SetActive(false);
            playerHealth--;

            switch (playerHealth)
            {
                case 3:
                    healthBar1.SetActive(true);
                    healthBar2.SetActive(true);
                    healthBar3.SetActive(true);
                    break;
                case 2:
                    healthBar1.SetActive(true);
                    healthBar2.SetActive(true);
                    healthBar3.SetActive(false);
                    break;
                case 1:
                    healthBar1.SetActive(true);
                    healthBar2.SetActive(false);
                    healthBar3.SetActive(false);
                    break;
                case 0:
                    healthBar1.SetActive(false);
                    healthBar2.SetActive(false);
                    healthBar3.SetActive(false);

                    playerLives--;
                    playerHealth = 3;

                    healthBar1.SetActive(true);
                    healthBar2.SetActive(true);
                    healthBar3.SetActive(true);

                    Instantiate(explosion, transform.position, transform.rotation);
                    Instantiate(explosionSound, transform.position, transform.rotation);
                    break;
                default:
                    break;
            }

            livesText.text = "x" + playerLives.ToString();

            if (playerLives == 0)
            {                
                Application.LoadLevel("RebelGO");                
            }
        }
    }

    IEnumerator DamageIndicator()
    {
        if (!damageIndicatorIMG.activeInHierarchy)
        {
            damageIndicatorIMG.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            damageIndicatorIMG.SetActive(false);
        }
    }
}
