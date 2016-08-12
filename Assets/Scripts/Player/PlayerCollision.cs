using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionSound;
    public GameObject greenHealthRing;
    public GameObject yellowHealthRing;
    public GameObject redHealthRing;
    public GameObject lifeImage1;
    public GameObject lifeImage2;
    public GameObject damageIndicatorIMG;
    public GameObject meteorExplosionPrefab;

    public int playerHealth = 3;
    public int playerLives = 3;
    public int healthScore = 100000;
    public int shieldScore = 300000;

    public string gameOverScene;

    PlayerScore playerScoreOBJ;
    public bool shieldActive;

    void Start()
    {
        playerScoreOBJ = transform.parent.GetComponent<PlayerScore>();

        greenHealthRing = GameObject.Find("GreenHealthRing");
        yellowHealthRing = GameObject.Find("YellowHealthRing");
        redHealthRing = GameObject.Find("RedHealthRing");
        damageIndicatorIMG = GameObject.Find("HitEffect");
        damageIndicatorIMG.SetActive(false);

        lifeImage1 = GameObject.Find("ShipIMG1");
        lifeImage2 = GameObject.Find("ShipIMG2");

        StartCoroutine(CheckScore());
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy Laser")
        {
            StartCoroutine(DamageIndicator());
            col.gameObject.SetActive(false);
            playerHealth--;

            if (playerHealth % 3 == 0)
            {
                LoseLife();
            }

            CheckHealth();
        }

        else if (col.gameObject.tag == "Meteor")
        {
            LoseLife();
            Instantiate(meteorExplosionPrefab, transform.position, transform.rotation);
            col.gameObject.SetActive(false);
        }
    }

    IEnumerator CheckScore()
    {
        if (playerScoreOBJ.score % healthScore == 0 && playerScoreOBJ.score != 0)
        {
            playerHealth++;

            if (playerHealth % 3 == 1)
            {
                GainLife();
            }

            CheckHealth();
            yield return new WaitForSeconds(10f);
        }
        else
        {
            CheckHealth();
            yield return new WaitForSeconds(0f);
        }

        if (playerScoreOBJ.score % shieldScore == 0 && playerScoreOBJ.score != 0)
        {
            transform.parent.GetComponent<ActivateShield>().onCooldown = false;
        }
        StartCoroutine(CheckScore());
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

    void CheckHealth()
    {
        if (playerLives == 0)
        {
            SceneManager.LoadScene(gameOverScene);
        }
        else
        {
            if (playerHealth % 3 == 0)
            {
                greenHealthRing.SetActive(true);
                yellowHealthRing.SetActive(false);
                redHealthRing.SetActive(false);
            }
            else if (playerHealth % 3 == 2)
            {
                greenHealthRing.SetActive(false);
                yellowHealthRing.SetActive(true);
                redHealthRing.SetActive(false);
            }
            else if (playerHealth % 3 == 1)
            {
                greenHealthRing.SetActive(false);
                yellowHealthRing.SetActive(false);
                redHealthRing.SetActive(true);
            }
            else if (playerHealth % 3 == 4)
            {
                greenHealthRing.SetActive(false);
                yellowHealthRing.SetActive(false);
                redHealthRing.SetActive(false);                
            }

            if (playerLives % 3 == 0)
            {
                lifeImage1.SetActive(true);
                lifeImage2.SetActive(true);
            }
            else if (playerLives % 3 == 2)
            {
                lifeImage1.SetActive(true);
                lifeImage2.SetActive(false);
            }
            else if (playerLives % 3 == 1)
            {
                lifeImage1.SetActive(false);
                lifeImage2.SetActive(false);
            }
        }        
    }

    void LoseLife()
    {
        if (!shieldActive)
        {
            playerLives--;

            greenHealthRing.SetActive(true);
            yellowHealthRing.SetActive(false);
            redHealthRing.SetActive(false);

            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(explosionSound, transform.position, transform.rotation);
        }
    }

    void GainLife()
    {
        playerLives++;
    }
}
