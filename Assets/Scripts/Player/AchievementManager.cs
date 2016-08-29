using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementManager : MonoBehaviour
{    
    public RectTransform achievementContainer;
    public RectTransform achievementCap;

    public Text achievement;

    public Image badge;

    public float containerStartingX;
    public float containerEndingX;
    public float capStartingX;
    public float capEndingX;
    public float uiWaitTime;
    public float lerpSpeed;
    
    PlayerScore playerScore;
    PlayerCollision playerCollision;
    PickUpManager pickUpManager;

    GameObject gameManager;
    GameObject player;
    GameObject playerCollider;

    int gameTime;
    int totalEnemiesDied;
    int totalLaserShots;
    int enemiesHit;

    bool uiActive;
    bool waiting;
    bool atEndPos;
    bool canDeactivate;

    public Vector3 containerStartPos;
    public Vector3 containerEndPos;
    public Vector3 capStartPos;
    public Vector3 capEndPos;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScore = player.GetComponent<PlayerScore>();
        playerCollider = GameObject.FindGameObjectWithTag("PlayerCollider");
        playerCollision = playerCollider.GetComponent<PlayerCollision>();
        gameManager = GameObject.Find("GameManager");
        pickUpManager = gameManager.GetComponent<PickUpManager>();

        containerStartPos = achievementContainer.anchoredPosition;
        //containerEndPos = new Vector3(containerEndingX, achievementContainer.anchoredPosition.y, 0f);
        capStartPos = achievementCap.anchoredPosition;
        //capEndPos = new Vector3(capEndingX, achievementCap.anchoredPosition.y, 0f);
    }

    void Update()
    {
        gameTime = (int)Time.timeSinceLevelLoad;

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetAchievements();            
        }

        //Score Achievements
        switch (playerScore.score)
        {
            case 10000:
                //print("You earned 10,000 points!");
                if (PlayerPrefs.GetInt("ScoreAchievement1") == 0)
                {
                    PlayerPrefs.SetInt("ScoreAchievement1", 1);
                    PlayerPrefs.SetInt("DarkWingBlue", 1);
                    achievement.text = "You earned 10,000 points!";
                    CallWait();
                }
                break;

            case 100000:
                //print("You earned 100,000 points!");
                if (PlayerPrefs.GetInt("ScoreAchievement2") == 0)
                {
                    PlayerPrefs.SetInt("ScoreAchievement2", 1);
                    achievement.text = "You earned 100,000 points!";
                    CallWait();
                }
                break;

            case 250000:
                //print("You earned 250,000 points!");
                if (PlayerPrefs.GetInt("ScoreAchievement3") == 0)
                {
                    PlayerPrefs.SetInt("ScoreAchievement3", 1);
                    achievement.text = "You earned 250,000 points!";
                    CallWait();
                }
                break;

            case 500000:
                //print("You earned 500,000 points!");
                if (PlayerPrefs.GetInt("ScoreAchievement4") == 0)
                {
                    PlayerPrefs.SetInt("ScoreAchievement4", 1);
                    achievement.text = "You earned 500,000 points!";
                    CallWait();
                }
                break;

            case 1000000:
                //print("You earned 1,000,000 points!");
                if (PlayerPrefs.GetInt("ScoreAchievement5") == 0)
                {
                    PlayerPrefs.SetInt("ScoreAchievement5", 1);
                    achievement.text = "You earned 1,000,000 points!";
                    CallWait();
                }
                break;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Stayed alive for x minutes!
        switch (gameTime)
        {
            case 1:
                //print("Welcome to the Outer Rim! Stayed alive for 1 second!");
                if (PlayerPrefs.GetInt("StayAlive1") == 0)
                {
                    PlayerPrefs.SetInt("StayAlive1", 1);
                    achievement.text = "Welcome to the Outer Rim!";
                    CallWait();
                }
                break;

            case 60:
                //print("Stayed alive for 1 minute!");
                if (PlayerPrefs.GetInt("StayAlive2") == 0)
                {
                    PlayerPrefs.SetInt("StayAlive2", 1);
                    achievement.text = "Stayed alive for 1 minute!";
                    CallWait();
                }
                break;

            case 300:
                //print("Stayed alive for 5 minutes!");
                if (PlayerPrefs.GetInt("StayAlive3") == 0)
                {
                    PlayerPrefs.SetInt("StayAlive3", 1);
                    achievement.text = "Stayed alive for 5 minutes!";
                    CallWait();
                }
                break;

            case 600:
                //print("Stayed alive for 10 minutes!");
                if (PlayerPrefs.GetInt("StayAlive4") == 0)
                {
                    PlayerPrefs.SetInt("StayAlive4", 1);
                    achievement.text = "Stayed alive for 10 minutes!";
                    CallWait();
                }
                break;

            case 1800:
                //print("Stayed alive for 30 minutes!");
                if (PlayerPrefs.GetInt("StayAlive5") == 0)
                {
                    PlayerPrefs.SetInt("StayAlive5", 1);
                    achievement.text = "Stayed alive for 30 minutes!";
                    CallWait();
                }
                break;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //No damage in x amount of minutes!
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 60)
        {
            //print("No damage in 1 min!");
            if (PlayerPrefs.GetInt("NoDamage1") == 0)
            {
                PlayerPrefs.SetInt("NoDamage1", 1);
                achievement.text = "No damage in 1 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 300)
        {
            //print("No damage in 5 min!");
            if (PlayerPrefs.GetInt("NoDamage2") == 0)
            {
                PlayerPrefs.SetInt("NoDamage2", 1);
                achievement.text = "No damage in 5 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 600)
        {
            //print("No damage in 10 min!");
            if (PlayerPrefs.GetInt("NoDamage3") == 0)
            {
                PlayerPrefs.SetInt("NoDamage3", 1);
                achievement.text = "No damage in 10 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 1800)
        {
            //print("No damage in 30 min!....... You are a god.");
            if (PlayerPrefs.GetInt("NoDamage4") == 0)
            {
                PlayerPrefs.SetInt("NoDamage4", 1);
                achievement.text = "You are a god.";
                CallWait();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Stay alive with 1 health for x amount of time.

        if (playerCollision.playerHealth == 1 && playerCollision.playerLives == 0 && gameTime == 60)
        {
            //print("At 1 health for 1 min!");
            if (PlayerPrefs.GetInt("OneHealth1") == 0)
            {
                PlayerPrefs.SetInt("OneHealth1", 1);
                achievement.text = "At 1 health for 1 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth == 1 && playerCollision.playerLives == 0 && gameTime == 300)
        {
            //print("At 1 health for 5 min!");
            if (PlayerPrefs.GetInt("OneHealth2") == 0)
            {
                PlayerPrefs.SetInt("OneHealth2", 1);
                achievement.text = "At 1 health for 5 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth == 1 && playerCollision.playerLives == 0 && gameTime == 600)
        {
            //print("At 1 health for min!");
            if (PlayerPrefs.GetInt("OneHealth3") == 0)
            {
                PlayerPrefs.SetInt("OneHealth3", 1);
                achievement.text = "At 1 health for 10 min!";
                CallWait();
            }
        }
        if (playerCollision.playerHealth == 1 && playerCollision.playerLives == 0 && gameTime == 1800)
        {
            //print("At 1 health for 30 min!");
            if (PlayerPrefs.GetInt("OneHealth4") == 0)
            {
                PlayerPrefs.SetInt("OneHealth4", 1);
                achievement.text = "At 1 health for 30 min!";
                CallWait();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Weapons fully upgraded

        if (pickUpManager.shieldLevel == 3)
        {
            //print("Shield fully upgraded!!");
            if (PlayerPrefs.GetInt("ShieldUpgraded") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgraded", 1);
                achievement.text = "Shield fully upgraded!!";
                CallWait();
            }
        }

        if (pickUpManager.laserLevel == 3)
        {
            //print("Laser fully upgraded!!");
            if (PlayerPrefs.GetInt("LasersUpgraded") == 0)
            {
                PlayerPrefs.SetInt("LasersUpgraded", 1);
                achievement.text = "Lasers fully upgraded!!";
                CallWait();
            }
        }

        if (pickUpManager.missileLevel == 3)
        {
            //print("Missile fully upgraded!!");
            if (PlayerPrefs.GetInt("MissilesUpgraded") == 0)
            {
                PlayerPrefs.SetInt("MissilesUpgraded", 1);
                achievement.text = "Missiles fully upgraded!!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3)
        {
            //print("All weapons fully upgraded!!");
            if (PlayerPrefs.GetInt("FullyUpgraded") == 0)
            {
                PlayerPrefs.SetInt("FullyUpgraded", 1);
                achievement.text = "All weapons fully upgraded!!";
                CallWait();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Weapons fully leveled for x amount of time

        if (pickUpManager.shieldLevel == 3 && gameTime == 60)
        {
            //print("Shield fully upgraded for 1 minute!");
            if (PlayerPrefs.GetInt("ShieldUpgradedTimed1") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgradedTimed1", 1);
                achievement.text = "Shield fully upgraded for 1 minute!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && gameTime == 300)
        {
            //print("Shield fully upgraded for 5 minutes!");
            if (PlayerPrefs.GetInt("ShieldUpgradedTimed2") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgradedTimed2", 1);
                achievement.text = "Shield fully upgraded for 5 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && gameTime == 600)
        {
            //print("Shield fully upgraded for 10 minutes!");
            if (PlayerPrefs.GetInt("ShieldUpgradedTimed3") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgradedTimed3", 1);
                achievement.text = "Shield fully upgraded for 10 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && gameTime == 1800)
        {
            //print("Shield fully upgraded for 30 minutes!");
            if (PlayerPrefs.GetInt("ShieldUpgradedTimed4") == 0)
            {
                PlayerPrefs.SetInt("ShieldUpgradedTimed4", 1);
                achievement.text = "Shield fully upgraded for 30 minutes!";
                CallWait();
            }
        }



        if (pickUpManager.laserLevel == 3 && gameTime == 60)
        {
            //print("Laser fully upgraded for 1 minute!");
            if (PlayerPrefs.GetInt("LaserUpgradedTimed1") == 0)
            {
                PlayerPrefs.SetInt("LaserUpgradedTimed1", 1);
                achievement.text = "Laser fully upgraded for 1 minute!";
                CallWait();
            }
        }
        if (pickUpManager.laserLevel == 3 && gameTime == 300)
        {
            //print("Laser fully upgraded for 5 minutes!");
            if (PlayerPrefs.GetInt("LaserUpgradedTimed2") == 0)
            {
                PlayerPrefs.SetInt("LaserUpgradedTimed2", 1);
                achievement.text = "Laser fully upgraded for 5 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.laserLevel == 3 && gameTime == 600)
        {
            //print("Laser fully upgraded for 10 minutes!");
            if (PlayerPrefs.GetInt("LaserUpgradedTimed3") == 0)
            {
                PlayerPrefs.SetInt("LaserUpgradedTimed3", 1);
                achievement.text = "Laser fully upgraded for 10 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.laserLevel == 3 && gameTime == 1800)
        {
            //print("Laser fully upgraded for 30 minutes!");
            if (PlayerPrefs.GetInt("LaserUpgradedTimed4") == 0)
            {
                PlayerPrefs.SetInt("LaserUpgradedTimed4", 1);
                achievement.text = "Laser fully upgraded for 30 minutes!";
                CallWait();
            }
        }



        if (pickUpManager.missileLevel == 3 && gameTime == 60)
        {
            //print("Missile fully upgraded for 1 minute!");
            if (PlayerPrefs.GetInt("MissileUpgradedTimed1") == 0)
            {
                PlayerPrefs.SetInt("MissileUpgradedTimed1", 1);
                achievement.text = "Missile fully upgraded for 1 minute!";
                CallWait();
            }
        }
        if (pickUpManager.missileLevel == 3 && gameTime == 300)
        {
            //print("Missile fully upgraded for 5 minutes!");
            if (PlayerPrefs.GetInt("MissileUpgradedTimed2") == 0)
            {
                PlayerPrefs.SetInt("MissileUpgradedTimed2", 1);
                achievement.text = "Missile fully upgraded for 5 minutes!";
                CallWait();
            }

        }
        if (pickUpManager.missileLevel == 3 && gameTime == 600)
        {
            //print("Missile fully upgraded for 10 minutes!");
            if (PlayerPrefs.GetInt("MissileUpgradedTimed3") == 0)
            {
                PlayerPrefs.SetInt("MissileUpgradedTimed3", 1);
                achievement.text = "Missile fully upgraded for 10 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.missileLevel == 3 && gameTime == 1800)
        {
            //print("Missile fully upgraded for 30 minutes!");
            if (PlayerPrefs.GetInt("MissileUpgradedTimed4") == 0)
            {
                PlayerPrefs.SetInt("MissileUpgradedTimed4", 1);
                achievement.text = "Missile fully upgraded for 30 minute!";
                CallWait();
            }
        }


        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 60)
        {
            //print("All weapons fully upgraded for 1 minute!");
            if (PlayerPrefs.GetInt("AllWeaponsUpgradedTimed1") == 0)
            {
                PlayerPrefs.SetInt("AllWeaponsUpgradedTimed1", 1);
                achievement.text = "All weapons fully upgraded for 1 minute!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 300)
        {
           // print("All weapons fully upgraded for 5 minutes!");
            if (PlayerPrefs.GetInt("AllWeaponsUpgradedTimed2") == 0)
            {
                PlayerPrefs.SetInt("AllWeaponsUpgradedTimed2", 1);
                achievement.text = "All weapons fully upgraded for 5 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 600)
        {
            //print("All weapons fully upgraded for 10 minutes!");
            if (PlayerPrefs.GetInt("AllWeaponsUpgradedTimed3") == 0)
            {
                PlayerPrefs.SetInt("AllWeaponsUpgradedTimed3", 1);
                achievement.text = "All weapons fully upgraded for 10 minutes!";
                CallWait();
            }
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 1800)
        {
            //print("All weapons fully upgraded 30 minutes!");
            if (PlayerPrefs.GetInt("AllWeaponsUpgradedTimed4") == 0)
            {
                PlayerPrefs.SetInt("AllWeaponsUpgradedTimed4", 1);
                achievement.text = "All weapons fully upgraded for 30 minutes!";
                CallWait();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Amount of enemies destroyed!
        switch (totalEnemiesDied)
        {
            case 1:
                //print("You got one! 1 Enemy killed.");
                if (PlayerPrefs.GetInt("KilledEnemy1") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy1", 1);
                    achievement.text = "You got one! One enemy killed!";
                    CallWait();
                }
                break;

            case 50:
                //print("50 Enemies killed.");
                if (PlayerPrefs.GetInt("KilledEnemy2") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy2", 1);
                    achievement.text = "50 enemies killed!";
                    CallWait();
                }
                break;

            case 100:
                //print("100 Enemies killed.");
                if (PlayerPrefs.GetInt("KilledEnemy3") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy3", 1);
                    achievement.text = "100 enemies killed!";
                    CallWait();
                }
                break;

            case 500:
                //print("500 Enemies killed.");
                if (PlayerPrefs.GetInt("KilledEnemy4") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy4", 1);
                    achievement.text = "500 enemies killed!";
                    CallWait();
                }
                break;

            case 1000:
                //print("1000 Enemies killed.");
                if (PlayerPrefs.GetInt("KilledEnemy5") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy5", 1);
                    achievement.text = "1000 enemies killed!";
                    CallWait();
                }
                break;

            case 5000:
                //print("5000 Enemies killed.");
                if (PlayerPrefs.GetInt("KilledEnemy6") == 0)
                {
                    PlayerPrefs.SetInt("KilledEnemy6", 1);
                    achievement.text = "5000 enemies killed!";
                    CallWait();
                }
                break;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //How many lasers shot ever.

        switch (totalLaserShots)
        {
            case 100:
                //print("100 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot1") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot1", 1);
                    achievement.text = "100 Lasers shot!";
                    CallWait();
                }
                break;

            case 500:
                //print("500 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot2") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot2", 1);
                    achievement.text = "500 Lasers shot!";
                    CallWait();
                }
                break;

            case 1000:
                //print("1,000 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot3") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot3", 1);
                    achievement.text = "1,000 Lasers shot!";
                    CallWait();
                }
                break;

            case 5000:
                //print("5,000 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot4") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot4", 1);
                    achievement.text = "5,000 Lasers shot!";
                    CallWait();
                }
                break;

            case 10000:
                //print("10,000 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot5") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot5", 1);
                    achievement.text = "10,000 Lasers shot!";
                    CallWait();
                }
                break;

            case 50000:
                //print("50,000 Lasers shot!");
                if (PlayerPrefs.GetInt("LasersShot6") == 0)
                {
                    PlayerPrefs.SetInt("LasersShot6", 1);
                    achievement.text = "50,000 Lasers shot!";
                    CallWait();
                }
                break;
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------------------------------------------------------      
        //Meteors destroyed

    }

    //Methods for Enemies Killed.
    public void EnemyDied()
    {
        totalEnemiesDied++;
    }

    //Methods for Lasers Shot.
    public void LaserShot()
    {
        totalLaserShots++;
    }
    //Methods for detecting accuracy
    public void EnemyHit()
    {
        enemiesHit++;
    }

    bool ActivateUI()
    {
        achievementCap.anchoredPosition = Vector3.Lerp(achievementCap.anchoredPosition, capEndPos, Time.deltaTime * lerpSpeed);
        achievementContainer.anchoredPosition = Vector3.Lerp(achievementContainer.anchoredPosition, containerEndPos, Time.deltaTime * lerpSpeed);

        if (Vector3.Distance(achievementCap.anchoredPosition, capEndPos) <= .1f)
        {
            return true;
        }

        return false;
    }

    bool DeactivateUI()
    {
        achievementCap.anchoredPosition = Vector3.Lerp(achievementCap.anchoredPosition, capStartPos, Time.deltaTime * lerpSpeed);
        achievementContainer.anchoredPosition = Vector3.Lerp(achievementContainer.anchoredPosition, containerStartPos, Time.deltaTime * lerpSpeed);

        if (Vector3.Distance(achievementCap.anchoredPosition, capStartPos) <= .1f)
        {
            return true;
        }

        return false;
    }

    void CallWait()
    {
        StartCoroutine(UITimer(uiWaitTime));
    }

    IEnumerator UITimer(float waitTime)
    {
        if (!uiActive)
        {
            uiActive = true;
            yield return new WaitUntil(ActivateUI);
            yield return new WaitForSeconds(waitTime);
            yield return new WaitUntil(DeactivateUI);
            uiActive = false;
        }
    }

    void ResetAchievements()
    {
        print("Reset Achievments");
        PlayerPrefs.SetInt("ScoreAchievement1", 0);
        PlayerPrefs.SetInt("ScoreAchievement2", 0);
        PlayerPrefs.SetInt("ScoreAchievement3", 0);
        PlayerPrefs.SetInt("ScoreAchievement4", 0);
        PlayerPrefs.SetInt("ScoreAchievement5", 0);
        PlayerPrefs.SetInt("StayAlive1", 0);
        PlayerPrefs.SetInt("StayAlive2", 0);
        PlayerPrefs.SetInt("StayAlive3", 0);
        PlayerPrefs.SetInt("StayAlive4", 0);
        PlayerPrefs.SetInt("StayAlive5", 0);
        PlayerPrefs.SetInt("NoDamage1", 0);
        PlayerPrefs.SetInt("NoDamage2", 0);
        PlayerPrefs.SetInt("NoDamage3", 0);
        PlayerPrefs.SetInt("NoDamage4", 0);
        PlayerPrefs.SetInt("OneHealth1", 0);
        PlayerPrefs.SetInt("OneHealth2", 0);
        PlayerPrefs.SetInt("OneHealth3", 0);
        PlayerPrefs.SetInt("OneHealth4", 0);
        PlayerPrefs.SetInt("ShieldUpgraded", 0);
        PlayerPrefs.SetInt("LaserUpgraded", 0);
        PlayerPrefs.SetInt("MissileUpgraded", 0);
        PlayerPrefs.SetInt("FullyUpgraded", 0);
        PlayerPrefs.SetInt("ShieldUpgradedTimed1", 0);
        PlayerPrefs.SetInt("ShieldUpgradedTimed2", 0);
        PlayerPrefs.SetInt("ShieldUpgradedTimed3", 0);
        PlayerPrefs.SetInt("ShieldUpgradedTimed4", 0);
        PlayerPrefs.SetInt("LaserUpgradedTimed1", 0);
        PlayerPrefs.SetInt("LaserUpgradedTimed2", 0);
        PlayerPrefs.SetInt("LaserUpgradedTimed3", 0);
        PlayerPrefs.SetInt("LaserUpgradedTimed4", 0);
        PlayerPrefs.SetInt("MissileUpgradedTimed1", 0);
        PlayerPrefs.SetInt("MissileUpgradedTimed2", 0);
        PlayerPrefs.SetInt("MissileUpgradedTimed3", 0);
        PlayerPrefs.SetInt("MissileUpgradedTimed4", 0);
        PlayerPrefs.SetInt("AllWeaponsUpgradedTimed1", 0);
        PlayerPrefs.SetInt("AllWeaponsUpgradedTimed2", 0);
        PlayerPrefs.SetInt("AllWeaponsUpgradedTimed3", 0);
        PlayerPrefs.SetInt("AllWeaponsUpgradedTimed4", 0);
        PlayerPrefs.SetInt("KilledEnemy1", 0);
        PlayerPrefs.SetInt("KilledEnemy2", 0);
        PlayerPrefs.SetInt("KilledEnemy3", 0);
        PlayerPrefs.SetInt("KilledEnemy4", 0);
        PlayerPrefs.SetInt("KilledEnemy5", 0);
        PlayerPrefs.SetInt("KilledEnemy6", 0);
        PlayerPrefs.SetInt("LaserShot1", 0);
        PlayerPrefs.SetInt("LaserShot2", 0);
        PlayerPrefs.SetInt("LaserShot3", 0);
        PlayerPrefs.SetInt("LaserShot4", 0);
        PlayerPrefs.SetInt("LaserShot5", 0);
        PlayerPrefs.SetInt("LaserShot6", 0);
    }
}