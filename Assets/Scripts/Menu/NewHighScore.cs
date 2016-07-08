using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewHighScore : MonoBehaviour {

    public GameObject newHS;
    public int highScore;
    public int oldHighScore;

	// Use this for initialization
	void Start () {
        highScore = PlayerPrefs.GetInt("HighScore");
        oldHighScore = PlayerPrefs.GetInt("OldHighScore");
    }
	
	// Update is called once per frame
	void Update () {
        if (highScore > oldHighScore)
        {
            oldHighScore = highScore;
            newHS.SetActive(true);            
        }
        else
        {
            newHS.SetActive(false);
        }

        PlayerPrefs.SetInt("OldHighScore", oldHighScore);
    }    
}
