using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InitialWrangler : MonoBehaviour {

    public char[] possibleInitials = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    //, 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'

    int currentCharacter;
    bool hasMoved;

    public GameObject activatePrevious;
    public GameObject activateNext;

    public int CurrentCharacter
    {
        get { return currentCharacter; }
    }

    public void NextCharacter()
    {
        if (currentCharacter == possibleInitials.Length - 1)
        {
            currentCharacter = 0;
            UpdateText();
        }
        else
        {
            currentCharacter++;
            UpdateText();
        }
    }

    public void PreviousCharacter()
    {
        if (currentCharacter == 0)
        {
            currentCharacter = possibleInitials.Length - 1;
            UpdateText();
        }
        else
        {
            currentCharacter--;
            UpdateText();
        }
    }

    public void UpdateText()
    {

        if (gameObject.GetComponent<Text>())
        {
            gameObject.GetComponent<Text>().text = possibleInitials[currentCharacter].ToString();
        }
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") < -.99f && !hasMoved)
        {
            hasMoved = true;
            PreviousCharacter();
        }
        else if (Input.GetAxis("Vertical") > .99f && !hasMoved)
        {
            hasMoved = true;
            NextCharacter();
        }
        else if (Input.GetAxis("Vertical") > -.05f && Input.GetAxis("Vertical") < .05f)
        {
            hasMoved = false;
        }

        if (Input.GetButtonDown("Fire3"))
        {
            if (activateNext.transform.parent != null)
            {
                activateNext.transform.parent.gameObject.SetActive(true);
            }
            activateNext.SetActive(true);
            enabled = false;
        }
        if (Input.GetButtonDown("Fire4"))
        {
            if (transform.name == "Initial1")
            {
                //Do nothing
            }
            else
            {
                activatePrevious.SetActive(true);
                activatePrevious.GetComponent<InitialWrangler>().enabled = true;
                gameObject.SetActive(false);
            }
        }
    }
}
