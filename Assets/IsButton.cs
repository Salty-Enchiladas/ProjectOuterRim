﻿using UnityEngine;
using System.Collections;

public class IsButton : MonoBehaviour 
{
    void OnMouseOver()
    {
        gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
    }
    void OnMouseExit()
    {
        gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
    }

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Play")
                {
                    Application.LoadLevel("Game");
                }

                else if (hit.transform.name == "Quit")
                {
                    Application.Quit();
                }
                else if (hit.transform.name == "Options")
                {
                    print("Options");
                }
                else if (hit.transform.name == "Garage")
                {
                    //Shuts off other buttons
                    GameObject.Find("Play").SetActive(false);
                    GameObject.Find("Quit").SetActive(false);
                    GameObject.Find("Options").SetActive(false);
                    GameObject.Find("Garage").SetActive(false);
                    GameObject.Find("Credit").SetActive(false);
                    GameObject.Find("Leaderboard").SetActive(false);
                    GameObject.Find("Achievement").SetActive(false);

                    //Turns on buttons in Garage
                    GameObject.FindGameObjectWithTag("LeftArrow").SetActive(true);
                    GameObject.FindGameObjectWithTag("RightArrow").SetActive(true);
                }
                else if (hit.transform.name == "Credit")
                {
                    print("Credits");
                }
                else if (hit.transform.name == "Leaderboard")
                {
                    print("Leaderboards");
                }
                else if (hit.transform.name == "Achievement")
                {
                    print("Achievements");
                }
                else if (hit.transform.name == "LeftArrow")
                {
                    
                }
                else if (hit.transform.name == "RightArrow")
                {
                    
                }
            }
        }
	}
}
