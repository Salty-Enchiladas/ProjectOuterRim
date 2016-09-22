using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLimit : MonoBehaviour
{
    public float CountdownFrom;
    public Text textbox;
    public GameObject thankYou;
    public Image fadeOut;

    float aplh = 0;
    bool done;
    void Update()
    {
        float time = CountdownFrom - Time.timeSinceLevelLoad;
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = Mathf.Floor(time % 60).ToString("00");


        textbox.text = "Time left: " + string.Format("{0:00}:{1:0}", minutes, seconds);         //time.ToString("0") + "s";

        if(!done)
            if (time <= 0f)
            {
                done = true;
                TimeUp();
            }
    }

    void TimeUp()
    {
        StartCoroutine(YouWin());
    }
    IEnumerator YouWin()
    {
        //yield return new WaitUntil(FadeOut);
        for (int i = 0; i < 20; i++)
        {
            aplh = aplh + .025f;
            fadeOut.color = new Color(0, 0, 0, aplh);
            yield return new WaitForSeconds(.1f);
        }
        thankYou.SetActive(true);
        Time.timeScale = .1f;
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("GameOver");

    }

    //bool FadeOut()
    //{
    //    fadeOut.color = Vector4.Lerp(fadeOut.color, Color.black * .5f, .00008f * Time.deltaTime);
    //    if (fadeOut.color.a >= Color.black.a * .5f)
    //    {
    //        print("THIS IS YOUR FAULT SAM!");
    //        return true;
    //    }
    //    return false;
    //}
}


