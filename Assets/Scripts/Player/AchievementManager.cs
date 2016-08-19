using UnityEngine;
using System.Collections;

public class AchievementManager : MonoBehaviour
{
    PlayerScore playerScore;
    PlayerCollision playerCollision;
    PickUpManager pickUpManager;

    GameObject gameManager;
    GameObject player;
    GameObject playerCollider;

    int gameTime;

	void Start ()
    {
        player = GameObject.Find("Player");
        playerScore = player.GetComponent<PlayerScore>();
        playerCollider = GameObject.FindGameObjectWithTag("PlayerCollider");
        playerCollision = playerCollider.GetComponent<PlayerCollision>();
        gameManager = GameObject.Find("GameManager");
        pickUpManager = gameManager.GetComponent<PickUpManager>();
    }

	void Update ()
    {
        gameTime = (int)Time.timeSinceLevelLoad;
        //Score Achievements
        switch (playerScore.score)
        {
            case 10000:
                print("You earned 10,000 points!");
                break;

            case 100000:
                print("You earned 100,000 points!");
                break;

            case 250000:
                print("You earned 250,000 points!");
                break;

            case 500000:
                print("You earned 500,000 points!");
                break;

            case 1000000:
                print("You earned 1,000,000 points!");
                break;
        }

 //------------------------------------------------------------------------------------------------------------------------------------------------------------------
       
        //Stayed alive for x minutes!
        switch (gameTime)
        {
            case 1:
                print("Welcome to the Outer Rim! Stayed alive for 1 second!");
                break;

            case 60:
                print("Stayed alive for 1 minute!");
                break;

            case 300:
                print("Stayed alive for 5 minutes!");
                break;

            case 600:
                print("Stayed alive for 10 minutes!");
                break;

            case 1800:
                print("Stayed alive for 30 minutes!");
                break;
        }

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //No damage in x amount of minutes!
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 60)
        {
            print("No damage in 1 min!");
        }
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 300)
        {
            print("No damage in 5 min!");
        }
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 600)
        {
            print("No damage in 10 min!");
        }
        if (playerCollision.playerHealth >= 3 && playerCollision.playerLives >= 3 && gameTime == 1800)
        {
            print("No damage in 30 min!....... You are a god.");
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Weapons fully upgraded

        if (pickUpManager.shieldLevel == 3)
        {
            print("Shield fully upgraded!!");
        }

        if (pickUpManager.laserLevel == 3)
        {
            print("Laser fully upgraded!!");
        }

        if (pickUpManager.missileLevel == 3)
        {
            print("Missile fully upgraded!!");
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3)
        {
            print("All weapons fully upgraded!!");
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Weapons fully leveled for x amount of time

        if (pickUpManager.shieldLevel == 3 && gameTime == 60)
        {
            print("Shield fully upgraded for 1 minute!");
        }
        if (pickUpManager.shieldLevel == 3 && gameTime == 300)
        {
            print("Shield fully upgraded for 5 minutes!");
        }
        if (pickUpManager.shieldLevel == 3 && gameTime == 600)
        {
            print("Shield fully upgraded for 10 minutes!");
        }
        if (pickUpManager.shieldLevel == 3 && gameTime == 1800)
        {
            print("Shield fully upgraded for 30 minutes!");
        }



        if (pickUpManager.laserLevel == 3 && gameTime == 60)
        {
            print("Laser fully upgraded for 1 minute!");
        }
        if (pickUpManager.laserLevel == 3 && gameTime == 300)
        {
            print("Laser fully upgraded for 5 minutes!");
        }
        if (pickUpManager.laserLevel == 3 && gameTime == 600)
        {
            print("Laser fully upgraded for 10 minutes!");
        }
        if (pickUpManager.laserLevel == 3 && gameTime == 1800)
        {
            print("Laser fully upgraded for 30 minutes!");
        }



        if (pickUpManager.missileLevel == 3 && gameTime == 60)
        {
            print("Missile fully upgraded for 1 minute!");
        }
        if (pickUpManager.missileLevel == 3 && gameTime == 300)
        {
            print("Missile fully upgraded for 5 minutes!");
        }
        if (pickUpManager.missileLevel == 3 && gameTime == 600)
        {
            print("Missile fully upgraded for 10 minutes!");
        }
        if (pickUpManager.missileLevel == 3 && gameTime == 1800)
        {
            print("Missile fully upgraded for 30 minutes!");
        }


        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 60)
        {
            print("All weapons fully upgraded for 1 minute!");
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 300)
        {
            print("All weapons fully upgraded for 5 minutes!");
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 600)
        {
            print("All weapons fully upgraded for 10 minutes!");
        }
        if (pickUpManager.shieldLevel == 3 && pickUpManager.laserLevel == 3 && pickUpManager.missileLevel == 3 && gameTime == 1800)
        {
            print("All weapons fully upgraded 30 minutes!");
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------
       
        
        //Amount of enemies killed
        //Meteors destroyed
        //Fully upgraded for an amount of time
        //time alive with 1 health left


    }
}
