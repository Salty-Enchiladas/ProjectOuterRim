﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsButton : MonoBehaviour
{
    public GameObject menuButtons;

    public bool play;
    public bool options;
    public bool quit;
    public bool achievement;
    public bool leaderboard;
    public bool garage;
    public bool credits;

    private void OnMouseOver()
    {
        transform.localScale = new Vector3(transform.localScale.x * .25f, transform.localScale.y * .25f, transform.localScale.z * .25f);
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(transform.localScale.x / .25f, transform.localScale.y / .25f, transform.localScale.z / .25f);
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.transform.name == "Play")
        //        {
                    
        //        }
        //        else if (hit.transform.name == "Quit")
        //        {
        //            Application.Quit();
        //        }
        //        else if (hit.transform.name == "Options")
        //        {
        //            print("Options");
        //        }
        //        else if (hit.transform.name == "Garage")
        //        {
        //            //Shuts off other buttons
        //            GameObject.Find("Play").SetActive(false);
        //            GameObject.Find("Quit").SetActive(false);
        //            GameObject.Find("Options").SetActive(false);
        //            GameObject.Find("Garage").SetActive(false);
        //            GameObject.Find("Credit").SetActive(false);
        //            GameObject.Find("Leaderboard").SetActive(false);
        //            GameObject.Find("Achievement").SetActive(false);

        //            //Turns on buttons in Garage
        //            GameObject.FindGameObjectWithTag("LeftArrow").SetActive(true);
        //            GameObject.FindGameObjectWithTag("RightArrow").SetActive(true);
        //        }
        //        else if (hit.transform.name == "Credit")
        //        {
        //            print("Credits");
        //        }
        //        else if (hit.transform.name == "Leaderboard")
        //        {
        //            print("Leaderboards");
        //        }
        //        else if (hit.transform.name == "Achievement")
        //        {
        //            print("Achievements");
        //        }
        //        else if (hit.transform.name == "LeftArrow")
        //        {
        //        }
        //        else if (hit.transform.name == "RightArrow")
        //        {
        //        }
        //    }
        //}
    }

    public void ButtonFunction()
    {
        if (play)
        {
            SceneManager.LoadScene("Game");
        }
        else if (options)
        {
            print("Options");
        }
        else if (quit)
        {
            Application.Quit();
        }
    }
}