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

    public int playerHealth;
    public int playerLives;
     int healthScore;

    public string gameOverScene;

    public bool shieldActive;

    PlayerScore playerScoreOBJ;

    PickUpManager pickUpManager;
    
    GameObject player;
    GameObject gameManager;
    PublicVariableHandler publicVariableHandler;
    bool takingDamage;
    AudioSource source;
    Image fadeOut;
    float aplh = 0;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScoreOBJ = player.GetComponent<PlayerScore>();

        gameManager = GameObject.Find("GameManager");
        pickUpManager = gameManager.GetComponent<PickUpManager>();
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        source = gameManager.GetComponent<AudioSource>();

        fadeOut = publicVariableHandler.fadeOut;
        greenHealthRing = GameObject.Find("GreenHealthRing");
        yellowHealthRing = GameObject.Find("YellowHealthRing");
        redHealthRing = GameObject.Find("RedHealthRing");
        damageIndicatorIMG = GameObject.Find("HitEffect");
        damageIndicatorIMG.SetActive(false);

        lifeImage1 = publicVariableHandler.shipIMG1;
        lifeImage2 = publicVariableHandler.shipIMG2;        

        playerHealth = publicVariableHandler.playerHealth;
        playerLives = publicVariableHandler.playerLives;
        healthScore = publicVariableHandler.healthRecoverScore;

        StartCoroutine(CheckScore());
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy Laser")
        {
            StartCoroutine(DamageIndicator());
            col.gameObject.SetActive(false);
            StartCoroutine(Immunity());
            playerHealth--;
            pickUpManager.LoseLevel();

            if (playerHealth % 3 == 0)
            {
                LoseLife();
            }

            CheckHealth();
        }
        else if (col.gameObject.tag == "Meteor" || col.gameObject.tag == "Carrier")
        {
            LoseLife();
            pickUpManager.LoseLevel();
            Instantiate(meteorExplosionPrefab, transform.position, transform.rotation);
            col.gameObject.SetActive(false);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            LoseLife();
            pickUpManager.LoseLevel();
            col.GetComponent<Enemy1Collision>().WasDestroyed();
        }
    }

    IEnumerator Immunity()
    {
        if (!takingDamage)
        {
            takingDamage = true;
            StartCoroutine(DamageIndicator());
            playerHealth--;
            pickUpManager.LoseLevel();
            yield return new WaitForSeconds(.5f);
            takingDamage = false;
        }
    }

    IEnumerator CheckScore()
    {
        if (playerScoreOBJ.score % healthScore == 0 && playerScoreOBJ.score != 0)
        {
            playerHealth++;

            CheckHealth();
            yield return new WaitForSeconds(10f);
        }
        else
        {
            CheckHealth();
            yield return new WaitForSeconds(0f);
        }

        StartCoroutine(CheckScore());
    }

    IEnumerator DamageIndicator()
    {
        source.clip = publicVariableHandler.hitSound;
        source.Play();
        if (!damageIndicatorIMG.activeInHierarchy)
        {
            damageIndicatorIMG.SetActive(true);
            yield return new WaitForSeconds(0.075f);
            damageIndicatorIMG.SetActive(false);
        }
    }

    void CheckHealth()
    {
        if (playerLives == 0)
        {
            StartCoroutine(GameOver());
        }
        else
        {
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

            //greenHealthRing.SetActive(true);
            //yellowHealthRing.SetActive(false);
            //redHealthRing.SetActive(false);

            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(explosionSound, transform.position, transform.rotation);
        }
    }

    public void GainLife()
    {
        playerLives++;
    }

    public static class CoroutineUtil
    {
        public static IEnumerator WaitForRealSeconds(float time)
        {
            float start = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup < start + time)
            {
                yield return null;
            }
        }
    }

    IEnumerator GameOver()
    {
        //yield return new WaitUntil(FadeOut);
        for (int i = 0; i < 20; i++)
        {
            aplh = aplh + .075f;
            if (Time.timeScale >= .1f)
            {
                fadeOut.color = new Color(0, 0, 0, aplh);
                Time.timeScale -= .1f;
            }
            yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(3f));
            SceneManager.LoadScene("GameOver");
        }
    }

}
