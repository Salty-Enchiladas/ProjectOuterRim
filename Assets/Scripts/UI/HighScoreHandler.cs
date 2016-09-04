using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HighScoreHandler : MonoBehaviour {

    public GameObject newHSPanel;

    public List<Text> scoreList;
    public List<Text> nameList;

    public Button restartButton;
    public Button quitButton;

    public static int rankToUpdate;
    public static int currentScore;

    public List<LeaderboardInfo> leaderboardInfo;

	// Use this for initialization
	void Start () {
        for(int i = 1; i <= 10; i++)
        {
            print(i);
            leaderboardInfo.Add(new LeaderboardInfo(PlayerPrefs.GetInt("Rank" + i.ToString() + "Score"), PlayerPrefs.GetString("Rank" + i.ToString() + "Name")));
            scoreList[i - 1].text = leaderboardInfo[i - 1].Score.ToString();
            print(leaderboardInfo[i - 1].Score.ToString());
            nameList[i - 1].text = leaderboardInfo[i - 1].Name.ToString();
            print(leaderboardInfo[i - 1].Name.ToString());
        }

        for(int j = 0; j < leaderboardInfo.Count; j++)
        {
            print("count: " + leaderboardInfo.Count);
            if (currentScore > leaderboardInfo[j].Score)
            {
                newHSPanel.SetActive(true);
                restartButton.interactable = false;
                quitButton.interactable = false;
                rankToUpdate = j;
                break;
            }
        }        
	}
	
	// Update is called once per frame
	void Update () {
	
	}    
}

public class LeaderboardInfo
{
    int score;
    string name;

    public LeaderboardInfo(int aScore, string aName)
    {
        score = aScore;
        name = aName;
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
