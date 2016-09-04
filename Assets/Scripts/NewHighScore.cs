using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NewHighScore : MonoBehaviour {

    public GameObject newHSPanel;

    public List<Text> scoreList;
    public List<Text> nameList;

    public Text initial1;
    public Text initial2;
    public Text initial3;

    public Button restartButton;
    public Button quitButton;

    public void UpdateRank()
    {
        PlayerPrefs.SetInt("Rank" + HighScoreHandler.rankToUpdate + 1.ToString() + "Score", HighScoreHandler.currentScore);
        PlayerPrefs.SetString("Rank" + HighScoreHandler.rankToUpdate + 1.ToString() + "Name", initial1.text + initial2.text + initial3.text);

        scoreList[HighScoreHandler.rankToUpdate + 1].text = PlayerPrefs.GetInt("Rank" + HighScoreHandler.rankToUpdate + 1.ToString() + "Score").ToString();
        nameList[HighScoreHandler.rankToUpdate + 1].text = PlayerPrefs.GetInt("Rank" + HighScoreHandler.rankToUpdate + 1.ToString() + "Name").ToString();

        newHSPanel.SetActive(false);

        restartButton.interactable = true;
        quitButton.interactable = true;
    }
}
