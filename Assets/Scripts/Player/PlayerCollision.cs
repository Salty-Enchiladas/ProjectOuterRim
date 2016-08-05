using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

    public GameObject explosion;
    public GameObject explosionSound;
    public GameObject healthBar1;
    public GameObject healthBar2;
    public GameObject healthBar3;
    public GameObject damageIndicatorIMG;
    public Text livesText;
    public int playerHealth = 3;
    public int playerLives = 3;
    public int healthScore = 100000;
    public int shieldScore = 300000;
    public string gameOverScene;

    PlayerScore playerScoreOBJ;
    public bool shieldActive;
    GameObject _livesText;

    void Start()
    {
        playerScoreOBJ = transform.parent.GetComponent<PlayerScore>();

        healthBar1 = GameObject.Find("HealthBar1");
        healthBar2 = GameObject.Find("HealthBar2");
        healthBar3 = GameObject.Find("HealthBar3");
        damageIndicatorIMG = GameObject.Find("HitEffect");
        damageIndicatorIMG.SetActive(false);

        _livesText = GameObject.Find("LivesText");
        livesText = _livesText.GetComponent<Text>();

        StartCoroutine(CheckScore());
    }

    //void Update()
    //{
        
    //}

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
            Application.LoadLevel(gameOverScene);
        }
        else
        {
            if (playerHealth % 3 == 0)
            {
                healthBar1.SetActive(true);
                healthBar2.SetActive(true);
                healthBar3.SetActive(true);
            }
            else if (playerHealth % 3 == 2)
            {
                healthBar1.SetActive(true);
                healthBar2.SetActive(true);
                healthBar3.SetActive(false);
            }
            else if (playerHealth % 3 == 1)
            {
                healthBar1.SetActive(true);
                healthBar2.SetActive(false);
                healthBar3.SetActive(false);
            }
            else if (playerHealth % 3 == 4)
            {
                healthBar1.SetActive(false);
                healthBar2.SetActive(false);
                healthBar3.SetActive(false);                
            }

            livesText.text = "x" + playerLives.ToString();
        }        
    }

    void LoseLife()
    {
        if (!shieldActive)
        {
            playerLives--;

            healthBar1.SetActive(true);
            healthBar2.SetActive(true);
            healthBar3.SetActive(true);

            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(explosionSound, transform.position, transform.rotation);
        }
    }

    void GainLife()
    {
        playerLives++;
    }
}
