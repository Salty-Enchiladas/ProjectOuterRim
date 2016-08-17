using UnityEngine;
using System.Collections;

public class AchievementManager : MonoBehaviour
{
    GameObject player;
    PlayerScore playerScore;

	void Start ()
    {
        player = GameObject.Find("Player");
        playerScore = player.GetComponent<PlayerScore>();
    }

	void Update ()
    {
        //Score Achievements
        switch (playerScore.score)
        {
            case 10000:
                //print("You earned 10,000 points!");
                break;

            case 20000:
                //print("You earned 20,000 points!");
                break;

            case 30000:
                //print("You earned 30,000 points!");
                break;
        }
        

    }
}
